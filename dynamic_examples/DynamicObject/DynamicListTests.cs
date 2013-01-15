using NUnit.Framework;

namespace dynamic_examples.DynamicObjectSamples
{
    [TestFixture]
    public class DynamicListTests
    {
        [Test]
        public void can_get_and_set_by_name()
        {
            dynamic lb = new ListBag();
            lb.Name = "John";
            Assert.AreEqual(lb.Name,"John");
        }

        [Test]
        public void can_get_by_index()
        {
            dynamic lb = new ListBag();
            lb.Name = "John";
            Assert.That(lb[0], Is.EqualTo("John"));
            
        }

        [Test]
        public void can_create_new_bag_with_list()
        {
            dynamic lb = new ListBag();
            lb <<= new {Name = "John", Email="email"};
            Assert.That(lb.Name, Is.EqualTo("John"));
            Assert.That(lb.Email, Is.EqualTo("email"));
        }
    }
}