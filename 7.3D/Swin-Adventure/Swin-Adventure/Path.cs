using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Swin_Adventure
{
    class Path : GameObject
    {
        private bool _isBlocked;
        private Location _destination;

        public Path(string[] idents, string name, string desc, Location destination) :
            base(idents, name, desc)
        {
            AddIdentifier("path");
            foreach(string s in name.Split(new char[] {' '}))
            {
                AddIdentifier(s);
            }
            _isBlocked = false;
            _destination = destination;
        }

        public Location Destination
        {
            get
            {
                return _destination;
            }
        }

        public bool isBlocked
        {
            get
            {
                return _isBlocked;
            }
            set
            {
                value = _isBlocked;
            }
        }
    }

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

            path = new Path(new string[] { "north","up" }, "Portal", "A mysterious looking portal", roomB);
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

            path = new Path(new string[] { "north","up" }, "Portal", "A mysteriosu looking portal", roomB);
            roomA.AddPath(path);

            GameObject expected = roomA.Locate("north");
            GameObject actual = path;

            Assert.AreEqual(expected, actual, "Locate path location test");
        }
    }
}
