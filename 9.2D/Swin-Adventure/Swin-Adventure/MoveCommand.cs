using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Swin_Adventure
{
    class MoveCommand : Command
    {
        public MoveCommand() :
            base(new string[] { "move", "go", "head", "leave" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            string _dest;

            switch (text.Length)
            {
                case 1:
                    return "Move to?";
                case 2:
                    _dest = text[1].ToLower();
                    break;
                default:
                    return "Error in move input";
            }

            GameObject _path = p.Location.Locate(_dest);

            
            if (_path != null)
            {
                p.Move((Path)_path);
                return "You have moved " + _path.FirstId + " to " + p.Location.Name;
            }

            return "Could not find " + _dest;
        }
    }

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

            path = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomA, roomB);
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

            path = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomA, roomB);
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

            path = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomA, roomB);
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

            path = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomA, roomB);
            roomA.AddPath(path);

            string expected = "Could not find west" ;
            string actual = m.Execute(p, new string[] { "move", "west" });

            Assert.AreEqual(expected, actual, "Invalid path test");

            expected =  roomA.Name;
            actual = p.Location.Name;

            Assert.AreEqual(expected, actual, "Player remain in the same location test");
        }
    }
}
