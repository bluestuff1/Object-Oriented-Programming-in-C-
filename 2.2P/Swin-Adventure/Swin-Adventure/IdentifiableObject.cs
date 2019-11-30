using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Swin_Adventure
{
    class IdentifiableObject
    {
        private List<string> _identifiers;

        public IdentifiableObject(string[] idents)
        {
            _identifiers = new List<String>();
            foreach (string id in idents)
            {
                _identifiers.Add(id.ToLower());
            }
        }

        public bool AreYou(string id)
        {
            return _identifiers.Contains(id.ToLower());
        }

        public string FirstId
        {
            get
            {
                return _identifiers[0];
            }
        }

        public void AddIdentifier(string id)
        {
            _identifiers.Add(id.ToLower());
        }

        public int NumberIdentifiers
        {
            get
            {
                return _identifiers.Count();
            }
        }
    }
    [TestFixture]
    public class TestIdentifiableObject
    {
        IdentifiableObject c = new IdentifiableObject(new string[] { "first", "second" });

        [Test]
        public void TestAreYou()
        {
            bool actual = c.AreYou("first");
            Assert.IsTrue(actual,"Are You Test");
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
