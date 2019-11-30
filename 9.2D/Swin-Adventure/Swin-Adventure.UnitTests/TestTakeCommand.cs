using System;
using System.Collections.Generic;
using System.Text;
using Swin_Adventure.Core;
using NUnit.Framework;

namespace Swin_Adventure.UnitTests
{
    [TestFixture]
    public class TestTakeCommand
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
        public void TestTakeFromLocation()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            bag = new Bag(new string[] { "bag" }, "small", "A small black bag");
            _player.Location = roomA;
            roomA.Inventory.Put(ring);

            string expected = "You have taken the ring.\r\n";
            string actual = c.Execute(_player, new string[] { "take", "ring"}); ;

            Assert.AreEqual(expected, actual, "Player can take item from location");
        }

        [Test]
        public void TestTakeUnknownFromLocation()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            bag = new Bag(new string[] { "bag" }, "small", "A small black bag");
            _player.Location = roomA;
            roomA.Inventory.Put(ring);

            string expected = "Could not find gem";
            string actual = c.Execute(_player, new string[] { "take","gem"}); ;

            Assert.AreEqual(expected, actual, "Can not take unknown item from location");
        }


        [Test]
        public void TestTakeFromBag()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            bag = new Bag(new string[] { "bag" }, "small", "A small black bag");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(tome);
            _player.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            _player.Location = roomA;
            roomA.Inventory.Put(ring);

            string expected = "You have taken the gem.\r\n";
            string actual = c.Execute(_player, new string[] { "take", "gem", "from", "bag" }); ;

            Assert.AreEqual(expected, actual, "Player can take item from bag");
        }

        [Test]
        public void TestTakeUnknownFromBag()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            bag = new Bag(new string[] { "bag" }, "small", "A small black bag");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(tome);
            _player.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            _player.Location = roomA;
            roomA.Inventory.Put(ring);

            string expected = "Could not find ring";
            string actual = c.Execute(_player, new string[] { "take", "ring", "from", "bag" }); ;

            Assert.AreEqual(expected, actual, "Player can not take unknown item from bag");
        }

        [Test]
        public void TestTakeGemFromNoBag()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(tome);

            _player.Location = roomA;
            roomA.Inventory.Put(ring);

            string expected = "Could not find bag";
            string actual = c.Execute(_player, new string[] { "take", "gem", "from", "bag" }); ;

            Assert.AreEqual(expected, actual, "Player can not take item from bag if there is no bag");
        }

        [Test]
        public void TestTakeFromMe()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(tome);

            _player.Location = roomA;
            roomA.Inventory.Put(ring);

            string expected = "You have taken the sword.\r\n";
            string actual = c.Execute(_player, new string[] { "take", "sword", "from", "me" }); ;

            Assert.AreEqual(expected, actual, "Player can not take unknown item from bag");
        }

        [Test]
        public void TestInvalidTake()
        {
            c = new CommandProcessor();
            _player = new Player("Bob", "This man is superior");
            bag = new Bag(new string[] { "bag" }, "small", "A small black bag");
            _player.Inventory.Put(sword);
            _player.Inventory.Put(tome);
            _player.Inventory.Put(bag);
            bag.Inventory.Put(gem);

            _player.Location = roomA;
            roomA.Inventory.Put(ring);

            string expected = "I don't know how to take like that";
            string actual = c.Execute(_player, new string[] { "take", "it", "all" });

            Assert.AreEqual(expected, actual, "Invalid take test");
        }





    }
}
    