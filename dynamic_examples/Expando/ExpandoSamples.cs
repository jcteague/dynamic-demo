using System;
using System.Dynamic;
using NUnit.Framework;

namespace dynamic_examples.Expando
{
    [TestFixture]
    public class ExpandoSamples
    {
        dynamic eo = new ExpandoObject();
        
        [SetUp]
        public void SetUp()
        {
            
            eo.FirstName = "Mark";
            eo.LastName = "Wahlburg";
            eo.CatchPhrase = "Say Hi to your Mother for me.";
        }
        [Test]
        public void adding_properties()
        {

            eo.FirstName = "Mark";
            eo.LastName = "Wahlburg";
            Console.WriteLine("Hi, I'm {0} {1}", eo.FirstName, eo.LastName);
        }

        [Test]
        public void add_a_method()
        {
            eo.FirstName = "Mark";
            eo.LastName = "Wahlburg";
            eo.CatchPhrase = "Say Hi to your Mother for me.";
            eo.FullName = eo.FirstName + " " + eo.LastName;
            eo.Greet = new Func<string, string>((string person) => String.Format("Hi {0}, I'm {1}. {2}", person,eo.FullName, eo.CatchPhrase));
            Console.WriteLine(eo.Greet("Andy"));
        }
    }
}