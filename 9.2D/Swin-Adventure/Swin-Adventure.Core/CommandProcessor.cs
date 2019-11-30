using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public class CommandProcessor : Command
    {
        private List<Command> _commands;

        public CommandProcessor()
            : base(new string[] { "command" })
        {
            _commands = new List<Command>();
            _commands.Add(new LookCommand());
            _commands.Add(new MoveCommand());
            _commands.Add(new TakeCommand());
            _commands.Add(new PutCommand());
        }

        public override string Execute(Player p, string[] text)
        {
            foreach (Command c in _commands)
            {
                if (c.AreYou(text[0].ToLower()))
                {
                    return c.Execute(p, text);
                }
            }
            return "Invalid command\r\n";
        }
    }
}
