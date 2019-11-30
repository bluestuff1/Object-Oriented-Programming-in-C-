using System;
using System.Collections.Generic;
using System.Text;
using Swin_Adventure.Core;
using NUnit.Framework;

namespace Swin_Adventure.UnitTests
{
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
