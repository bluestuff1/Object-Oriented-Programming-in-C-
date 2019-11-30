using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public class LookCommand : Command
    {
        public LookCommand() :
            base(new string[] { "look", "examine", "inspect" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            if (text.Length == 3 | text.Length == 5)
            {
                if (text[0] != "look")
                {
                    return "Error in look input";
                }

                if (text[1] != "at")
                {
                    return "What do you want to look at?";
                }

                if (text.Length == 5)
                {
                    if (text[3] != "in")
                    {
                        return "What do you want to look in?";
                    }
                }

            }
            else
            {
                return "I don't know how to look like that";
            }

            IHaveInventory _container = null;

            if (text.Length == 3)
            {
                _container = p as IHaveInventory;
            }

            if (text.Length == 5)
            {
                _container = FetchContainer(p, text[4]);
            }

            if (_container == null)
            {
                return "Could not find " + text[4];
            }

            string _ItemId = text[2];

            return LookAtIn(_ItemId, _container);
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        public string LookAtIn(string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
            {
                return container.Locate(thingId).FullDescription;
            }
            return "Could not find " + thingId;
        }
    }
}
