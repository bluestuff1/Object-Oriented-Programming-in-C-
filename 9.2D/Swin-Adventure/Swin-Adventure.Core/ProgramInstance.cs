using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public enum GameState
    {
        ReadingName,
        ReadingDesc,
        Playing
    }

    public class ProgramInstance
    {
        string _output;

        GameState _gameState;
        string _name, _desc;

        Command c = new CommandProcessor();
        Player _player;
        Bag bag = new Bag(new string[] { "bag" }, "small", "A small black bag");

        Item sword = new Item(new string[] { "sword" }, "silver", "A cutting or thrusting weapon with a long blade");
        Item tome = new Item(new string[] { "tome" }, "ancient", "A large and scholarly book");
        Item gem = new Item(new string[] { "gem" }, "red", "A crystalline rock that can be cut and polished for jewellery");
        Item ring = new Item(new string[] { "ring" }, "mysterious", "Jewellery consisting of a circlet of precious metal (often set with jewels) worn on the finger");



        Location roomA = new Location("Room A", "This place smells like Room A");
        Location roomB = new Location("Room B", "This place smells like Room B");


        public ProgramInstance()
        {
            Path pathAToB = new Path(new string[] { "north", "up" }, "Portal", "A mysteriosu looking portal", roomB);
            Path pathBToA = new Path(new string[] { "south", "down" }, "Portal", "A mysteriosu looking portal", roomA);

            roomA.AddPath(pathAToB);
            roomB.AddPath(pathBToA);

            _output = "Welcome to Swin-Adventure\r\n" +
                "Swin-Adventure is a fantasy adventure game that consists of a number of interconnected locations.\r\n" +
                "Let's begin with your name";
        }

        public string InputCommand(string command)
        {
            switch (_gameState)
            {
                case GameState.ReadingName:
                    _name = command;
                    _gameState = GameState.ReadingDesc;
                    return "Right... So your name is " + _name + "\r\nHow would you describe yourself?";

                case GameState.ReadingDesc:
                    _desc = command;
                    _gameState = GameState.Playing;

                    _player = new Player(_name, _desc)
                    {
                        Location = roomA
                    };
                    _player.Inventory.Put(sword);
                    _player.Inventory.Put(tome);
                    _player.Inventory.Put(bag);
                    bag.Inventory.Put(gem);
                    roomA.Inventory.Put(ring);

                    return _name + ", " + _desc + ", your very own Swin-Adventure legend is about to unfold!";
            }

            return "\r\n" + c.Execute(_player, command.Split());
        }

        public string Output
        {
            get
            {
                return _output;
            }
        }
    }
}
