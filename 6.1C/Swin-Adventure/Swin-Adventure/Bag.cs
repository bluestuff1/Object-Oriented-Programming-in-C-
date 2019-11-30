using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Swin_Adventure
{
    class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) :
            base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public override string FullDescription
        {
            get
            {
                return "In the " + this.Name + " you can see: " + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }

    [TestFixture]
    public class TestBag
    {
        Bag b1;
        Item sword = new Item(new string[] { "sword" }, "bronze", "This is a cheap sword");
        Item AncientCoin = new Item(new string[] { "coin" }, "ancient", "This is a very ancient coin");

        [Test]
        public void TestBagLocatesItems()
        {
            b1 = new Bag(new string[] { "small", "black" }, "bag", "A small black bag");
            b1.Inventory.Put(sword);
            GameObject expected = sword;
            GameObject actual = b1.Locate(sword.FirstId);

            Assert.AreEqual(expected, actual, "Bag Locates Items Test");
        }

        [Test]
        public void TestBagLocatesItself()
        {
            b1 = new Bag(new string[] { "small", "black" }, "bag", "A small black bag");
            GameObject expected = b1;
            GameObject actual = b1.Locate(b1.FirstId);

            Assert.AreEqual(expected, actual, "Bag Locates Itself Test");
        }

        [Test]
        public void TestBagLocatesNothing()
        {
            b1 = new Bag(new string[] { "small", "black" }, "bag", "A small black bag");
            GameObject expected = null;
            GameObject actual = b1.Locate(sword.FirstId);

            Assert.AreEqual(expected, actual, "Bag Locates Nothing Test");
        }

        [Test]
        public void TestBagFullDescription()
        {
            b1 = new Bag(new string[] { "small", "black" }, "bag", "A small black bag");
            b1.Inventory.Put(sword);

            string expected = "In the bag you can see:    a bronze sword\r\n";
            string actual = b1.FullDescription;

            Assert.AreEqual(expected, actual, "Bag Full Description Test");
        }

        [Test]
        public void TestBagInBag()
        {
            b1 = new Bag(new string[] { "small", "black" }, "bag", "A small black bag");
            Bag b2 = new Bag(new string[] { "big", "gold" }, "bag", "A big gold bag");

            b1.Inventory.Put(b2);
            b1.Inventory.Put(sword);
            b2.Inventory.Put(AncientCoin);

            GameObject expected = b2;
            GameObject actual = b1.Locate(b2.FirstId);

            Assert.AreEqual(expected, actual, "b1 can locate b2 test");

            expected = sword;
            actual = b1.Locate(sword.FirstId);

            Assert.AreEqual(expected, actual, "b1 can locate others in b1 test");

            expected = null;
            actual = b1.Locate(AncientCoin.FirstId);

            Assert.AreEqual(expected, actual, "b1 can not locates items in b2 test");
        }
    }
}
