using System;
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
            eo.evt += new EventHandler((sender, args) =>
                                           {
                                               Console.WriteLine("Inline EventHandler");
                                           });

            EventHandler e = eo.evt;
            if(e!=null)
            {
                e(eo, EventArgs.Empty);
            }
        }
    }
}