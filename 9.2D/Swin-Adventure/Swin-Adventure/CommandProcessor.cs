using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Swin_Adventure
{
    class CommandProcessor : Command
    {
        public CommandProcessor() 
            : base(new string[] { "command" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            Command c;

            switch(text[0].ToLower())
            {
                case "look":
                    c = new LookCommand();
                    break;
                case "move":
                    c = new MoveCommand();
                    break;
                case "go":
                    c = new MoveCommand();
                    break;
                default:
                    c = new LookCommand();
                    break;
            }
            return c.Execute(p, text);
        }
    }


    [TestFixture]
    public class TestCommandProcessor
    {
        CommandProcessor c;
        Player p;
        Location roomA;
        Location roomB;
        Path roomAToB;
        Path roomBToA;

        [Test]
        public void TestCommandLook()
        {
            c = new CommandProcessor();
            p = new Player("Bob", "Above average");
            roomA = new Location("Room A", "This place smells like Room A");
            roomB = new Location("Room B", "This place smells like Room B");
            p.Location = roomA;

            roomAToB = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomA, roomB);
            roomA.AddPath(roomAToB);

            string expected = "This place smells like Room A";
            string actual = c.Execute(p, new string[] { "look", "at", "room" });

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

            roomAToB = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomA, roomB);
            roomBToA = new Path(new string[] { "south", "down" }, "Portal", "A mysteriosu looking portal", roomB, roomA);
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
