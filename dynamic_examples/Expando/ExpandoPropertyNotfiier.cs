using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using NUnit.Framework;

namespace dynamic_examples.Expando
{
    [TestFixture]
    public class ExpandoPropertyNotfiier
    {
        void EventHandler1(object sender, EventArgs args)
        {
            Console.WriteLine("Event Handler 1 Activated");
        }
        
        [Test]
        public void dynamic_event_handlers()
        {
            dynamic eo = new ExpandoObject();
            eo.evt = null;
            eo.evt += new EventHandler(EventHandler1);
            eo.evt += new EventHandler((sender, args) => Console.WriteLine("Inline EventHandler"));

            EventHandler e = eo.evt;
            if(e!=null)
            {
                e(eo, EventArgs.Empty);
            }
        }
        void OnExpandoPropertyChanged(object sender,PropertyChangedEventArgs args)
        {
            var sender_eo = (IDictionary<string,Object>) sender;
            Console.WriteLine("{0} set to {1}", args.PropertyName, sender_eo[args.PropertyName] );
        }
        [Test]
        public void notify_property_changed()
        {
            dynamic eo = new ExpandoObject();
            ((INotifyPropertyChanged) eo).PropertyChanged += new PropertyChangedEventHandler(OnExpandoPropertyChanged);
            eo.FirstName = "Arnold";
            eo.CatchPhrose = "I'll Be Back";
        }
    }

}