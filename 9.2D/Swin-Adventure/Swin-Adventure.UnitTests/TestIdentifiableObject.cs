using System;
using System.Collections.Generic;
using System.Text;
using Swin_Adventure.Core;
using NUnit.Framework;

namespace Swin_Adventure.UnitTests
{
    [TestFixture]
    public class TestIdentifiableObject
    {
        IdentifiableObject c = new IdentifiableObject(new string[] { "first", "second" });

        [Test]
        public void TestAreYou()
        {
            bool actual = c.AreYou("first");
            Assert.IsTrue(actual, "Are You Test");
        }

        [Test]
        public void TestNotAreYou()
        {
            bool actual = c.AreYou("third");
            Assert.IsFalse(actual, "Not Are You Test");
        }

        [Test]
        public void TestCaseSensitive()
        {
            bool actual = c.AreYou("FIRST");
            Assert.IsTrue(actual, "Case Sensitive Test");
        }

        [Test]
        public void TestFirstId()
        {
            string actual = c.FirstId;
            Assert.AreEqual("first", actual, "First Id Test");
        }

        [Test]
        public void TestAddId()
        {
            c.AddIdentifier("fourth");
            int actual = c.NumberIdentifiers;
            Assert.AreEqual(3, actual, "Add Id Test");
        }
    }
}