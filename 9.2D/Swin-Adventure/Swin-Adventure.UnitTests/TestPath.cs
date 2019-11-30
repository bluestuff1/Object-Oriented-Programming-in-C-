using System;
using System.Collections.Generic;
using System.Text;
using Swin_Adventure.Core;
using NUnit.Framework;

namespace Swin_Adventure.UnitTests
{
    [TestFixture]
    public class TestPath
    {

        Player p;
        Location roomA;
        Location roomB;
        Path path;

        [Test]
        public void TestPathDestination()
        {
            p = new Player("Bob", "Average dude");
            roomA = new Location("Room A", "Smells like Room A");
            roomB = new Location("Room B", "Smells like Room B");
            p.Location = roomA;

            path = new Path(new string[] { "north", "up" }, "Portal", "A mysterious looking portal", roomB);
            roomA.AddPath(path);

            Location expected = roomB;
            Location actual = path.Destination;

            Assert.AreEqual(expected, actual, "Locate path destination test");
        }

        [Test]
        public void TestPathLocation()
        {
            p = new Player("Player 1", "Actually Bob");
            roomA = new Location("Room A", "Smells like Room A");
            roomB = new Location("Room B", "Smells like Room B");
            p.Location = roomA;

            path = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomB);
            roomA.AddPath(path);

            GameObject expected = roomA.Locate("north");
            GameObject actual = path;

            Assert.AreEqual(expected, actual, "Locate path location test");
        }
    }
}
