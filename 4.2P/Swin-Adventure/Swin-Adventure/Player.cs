using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    class Player : GameObject
    {
        private Inventory _inventory;

        public Player(string name, string desc) :
            base(new string[] { "me", "inventory" }, name, desc)
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
                return "You are carrying: " + _inventory.ItemList;
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
    public class TestPlayer
    {
        Item sword = new Item(new string[] { "sword" }, "bronze", "This is a cheap sword");

        [Test]
        public void TestPlayerIdentifiable()
        {
            Player player = new Player("player1", "This is player 1");
            bool actual = player.AreYou("me");
            Assert.IsTrue(actual);

            actual = player.AreYou("inventory");
            Assert.IsTrue(actual, "Player Identifiable Test");
        }

        [Test]
        public void TestPlayerLocatesItems()
        {
            Player player = new Player("player1", "This is player 1");

            player.Inventory.Put(sword);
            GameObject expected = sword;
            GameObject actual = player.Locate(sword.FirstId);

            Assert.AreEqual(expected, actual, "Player Locates Items Test");
        }

        [Test]
        public void TestPlayerLocatesItself()
        {
            Player player = new Player("player1", "This is player 1");
            GameObject expected = player;
            GameObject actual = player.Locate("me");

            Assert.AreEqual(expected, actual, "Player Locates Itself Test");
        }

        [Test]
        public void TestPlayerLocatesNothing()
        {
            Player player = new Player("player1", "This is player 1");
            GameObject expected = null;
            GameObject actual = player.Locate(sword.FirstId);

            Assert.AreEqual(expected, actual, "Player Locates Nothing Test");
        }

        [Test]
        public void TestPlayerFullDescription()
        {
            Player player = new Player("player1", "This is player1");
            player.Inventory.Put(sword);
            string expected = "You are carrying:    a bronze sword\r\n";
            string actual = player.FullDescription;

            Assert.AreEqual(expected, actual, "Player Full Description Test");
        }
    }
}
