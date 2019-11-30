using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public class MoveCommand : Command
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
}
