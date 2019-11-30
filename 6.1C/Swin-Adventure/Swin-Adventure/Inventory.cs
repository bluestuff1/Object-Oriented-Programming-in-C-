using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Swin_Adventure
{
    class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            if (_items.Count != 0)
            {
                foreach (Item i in _items)
                {
                    if (i.AreYou(id))
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    Item ItemFound = i;
                    _items.Remove(i);
                    return ItemFound;
                }
            }
            return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string list = "";
                foreach (Item i in _items)
                {
                    list += "   " + i.ShortDescription + Environment.NewLine;
                }
                return list;
            }
        }
    }

    [TestFixture]
    public class TestInventory
    {
        Inventory inventory;
        Item AncientCoin = new Item(new string[] { "coin" }, "ancient", "This is a very ancient coin");
        Item sword = new Item(new string[] { "sword" }, "bronze", "This is a cheap sword");

        [Test]
        public void TestFindItem()
        {
            inventory = new Inventory();
            inventory.Put(AncientCoin);
            bool actual = inventory.HasItem(AncientCoin.FirstId);

            Assert.IsTrue(actual, "Test to find item");
        }

        [Test]
        public void TestNoItemFound()
        {
            inventory = new Inventory();
            bool actual = inventory.HasItem(AncientCoin.FirstId);

            Assert.IsFalse(actual, "Test for when inventory does not contain item");
        }

        [Test]
        public void TestFetchItem()
        {
            inventory = new Inventory();
            inventory.Put(AncientCoin);
            Item actual = inventory.Fetch(AncientCoin.FirstId);

            Assert.AreEqual(AncientCoin, actual, "Returns item and item remains in the inventory");
        }

        [Test]
        public void TestTakeItem()
        {
            inventory = new Inventory();
            inventory.Put(AncientCoin);
            inventory.Take(AncientCoin.FirstId);

            Assert.IsFalse(inventory.HasItem(AncientCoin.FirstId), "Returns the item, no longer in inventory");
        }

        [Test]
        public void TestItemList()
        {
            inventory = new Inventory();
            inventory.Put(AncientCoin);
            inventory.Put(sword);
            string expected = "   a ancient coin\r\n   a bronze sword\r\n";
            string actual = inventory.ItemList;

            Assert.AreEqual(expected, actual, "Returns a list of strings with one row per item");

        }
    }



}
