using System;
using System.Collections.Generic;
using System.Text;
using Swin_Adventure.Core;
using NUnit.Framework;

namespace Swin_Adventure.UnitTests
{
    [TestFixture]
    public class TestCommandProcessor
    {
        CommandProcessor c;
        Player p;
        Item sword;
        Location roomA;
        Location roomB;
        Path roomAToB;
        Path roomBToA;

        [Test]
        public void TestCommandLook()
        {
            c = new CommandProcessor();
            p = new Player("Bob", "Above average");
            sword = new Item(new string[] { "sword" }, "bronze", "This is a very cheap sword");
            p.Inventory.Put(sword);

            string expected = "This is a very cheap sword";
            string actual = c.Execute(p, new string[] { "look", "at", "sword" });

            Assert.AreEqual(expected, actual, "Look command works through command processor");
        }

        [Test]
        public void TestCommandMove()
        {
            c = new CommandProcessor();
            p = new Player("Bob", "Above average");
            roomA = new Location("Room A", "This place smells like Room A");
            roomB = new Location("Room B", "This place smells like Room B");
            p.Location = roomA;

            roomAToB = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomB);
            roomBToA = new Path(new string[] { "south", "down" }, "Portal", "A mysteriosu looking portal", roomA);
            roomA.AddPath(roomAToB);
            roomB.AddPath(roomBToA);

            string expected = "You have moved north to Room B";
            string actual = c.Execute(p, new string[] { "move", "north" });

            Assert.AreEqual(expected, actual, "Move command works through command processor");

            expected = "You have moved south to Room A";
            actual = c.Execute(p, new string[] { "go", "down" });

            Assert.AreEqual(expected, actual, "Same as above except this time using keyword 'go'");
        }
    }
}
