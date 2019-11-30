using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    class Item : GameObject
    {
        public Item(string[] idents, string name, string desc) :
            base(idents, name, desc)
        {

        }
    }

    [TestFixture]
    public class TestItem
    {
        Item sword = new Item(new string[] { "sword" }, "bronze", "This is a cheap sword");

        [Test]
        public void TestItemIsIdentifiable()
        {
            bool actual = sword.AreYou("sword");

            Assert.IsTrue(actual, "Test item is identifiable");
        }

        [Test]
        public void TestShortDescription()
        {
            string expected = "a bronze sword";
            string actual = sword.ShortDescription;

            Assert.AreEqual(expected, actual, "Test for short description");
        }

        [Test]
        public void TestFullDescription()
        {
            string expected = "This is a cheap sword";
            string actual = sword.FullDescription;

            Assert.AreEqual(expected, actual, "Test for full description");
        }
    }
}
