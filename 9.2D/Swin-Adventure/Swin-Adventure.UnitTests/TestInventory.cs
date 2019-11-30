using System;
using System.Collections.Generic;
using System.Text;
using Swin_Adventure.Core;
using NUnit.Framework;

namespace Swin_Adventure.UnitTests
{
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
