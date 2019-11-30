using System;
using System.Collections.Generic;
using System.Text;
using Swin_Adventure.Core;
using NUnit.Framework;

namespace Swin_Adventure.UnitTests
{
    [TestFixture]
    public class TestPutCommand
    {
        CommandProcessor c;
        Player _player;
        Bag bag;
        Location roomA = new Location("Room A", "This place smells like Room A");
        Item sword = new Item(new string[] { "sword" }, "silver", "A cutting or thrusting weapon with a long blade");
        Item tome = new Item(new string[] { "tome" }, "ancient", "A large and scholarly book");
        Item gem = new Item(new string[] { "gem" }, "red", "A crystalline rock that can be cut and polished for jewellery");
        Item ring = new Item(new string[] { "ring" }, "mysterious", "Jewellery consisting of a circlet of precious metal (often set with jewels) worn on the finger");

        [Test]
        public void TestPutInLocation()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            _player.Inventory.Put(sword);
            bag = new Bag(new string[] { "bag" }, "small", "A small black bag");
            _player.Location = roomA;

            string expected = "You have put the sword in Room A.\r\n";
            string actual = c.Execute(_player, new string[] { "put", "sword", "in", "room" });

            Assert.AreEqual(expected, actual, "Player can put item in location test");
        }

        [Test]
        public void TestPutInBag()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            bag = new Bag(new string[] { "bag" }, "bag", "A small black bag");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(bag);
            _player.Location = roomA;

            string expected = "You have put the sword in bag.\r\n";
            string actual = c.Execute(_player, new string[] { "put", "sword", "in", "bag" });

            Assert.AreEqual(expected, actual, "Player can put item in bag test");
        }

        [Test]
        public void TestPutUnknownInBag()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            bag = new Bag(new string[] { "bag" }, "bag", "A small black bag");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(bag);
            _player.Location = roomA;

            string expected = "Could not find ring";
            string actual = c.Execute(_player, new string[] { "put", "ring", "in", "bag" });

            Assert.AreEqual(expected, actual, "Player cannot put unknown item in bag test");
        }

        [Test]
        public void TestPutUnknownInLocation()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            bag = new Bag(new string[] { "bag" }, "bag", "A small black bag");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(bag);
            _player.Location = roomA;

            string expected = "Could not find ring";
            string actual = c.Execute(_player, new string[] { "put", "ring", "in", "room" });

            Assert.AreEqual(expected, actual, "Player cannot put unknown item in room test");
        }

        [Test]
        public void TestPutInUnknown()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            bag = new Bag(new string[] { "bag" }, "bag", "A small black bag");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(bag);
            _player.Location = roomA;

            string expected = "Could not find turtle";
            string actual = c.Execute(_player, new string[] { "put", "ring", "in", "turtle" });

            Assert.AreEqual(expected, actual, "Player cannot put item in unknown container test");
        }

        [Test]
        public void TestInvalidPut()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            bag = new Bag(new string[] { "bag" }, "bag", "A small black bag");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(bag);
            _player.Location = roomA;

            string expected = "I don't know how to put like that";
            string actual = c.Execute(_player, new string[] { "put", "ring", "outside", });

            Assert.AreEqual(expected, actual, "Invalid put test");
        }
    }
}