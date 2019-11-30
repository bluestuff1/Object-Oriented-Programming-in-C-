using System;
using System.Collections.Generic;
using System.Text;
using Swin_Adventure.Core;
using NUnit.Framework;

namespace Swin_Adventure.UnitTests
{
    [TestFixture]
    public class TestMoveCommand
    {
        MoveCommand m;
        Player p;
        Location roomA;
        Location roomB;
        Path path;

        [Test]
        public void TestPlayerMoveToDestination()
        {
            m = new MoveCommand();
            p = new Player("Bob", "Some average dude");
            roomA = new Location("Room A", "This place smells like Room A");
            roomB = new Location("Room B", "This place smells like Room B");
            p.Location = roomA;

            path = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomB);
            roomA.AddPath(path);

            string expected = "You have moved north to Room B";
            string actual = m.Execute(p, new string[] { "move", "north" });

            Assert.AreEqual(expected, actual, "Player can move to path destination test");
        }

        [Test]
        public void TestPlayerInvalidMoveNoArgs()
        {
            m = new MoveCommand();
            p = new Player("Bob", "Some average dude");
            roomA = new Location("Room A", "This place smells like Room A");
            roomB = new Location("Room B", "This place smells like Room B");
            p.Location = roomA;

            path = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomB);
            roomA.AddPath(path);

            string expected = "Move to?";
            string actual = m.Execute(p, new string[] { "move" });

            Assert.AreEqual(expected, actual, "Move command not specified test");
        }

        public void TestPlayerInvalidMoveTooManyArgs()
        {
            m = new MoveCommand();
            p = new Player("Bob", "Some average dude");
            roomA = new Location("Room A", "This place smells like Room A");
            roomB = new Location("Room B", "This place smells like Room B");
            p.Location = roomA;

            path = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomB);
            roomA.AddPath(path);

            string expected = "Error in move input";
            string actual = m.Execute(p, new string[] { "move", "to", "north" });

            Assert.AreEqual(expected, actual, "Move command is too long test");
        }

        [Test]
        public void TestPlayerInvalidPath()
        {
            m = new MoveCommand();
            p = new Player("Bob", "Some average dude");
            roomA = new Location("Room A", "This place smells like Room A");
            roomB = new Location("Room B", "This place smells like Room B");
            p.Location = roomA;

            path = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomB);
            roomA.AddPath(path);

            string expected = "Could not find west";
            string actual = m.Execute(p, new string[] { "move", "west" });

            Assert.AreEqual(expected, actual, "Invalid path test");

            expected = roomA.Name;
            actual = p.Location.Name;

            Assert.AreEqual(expected, actual, "Player remain in the same location test");
        }
    }
}
