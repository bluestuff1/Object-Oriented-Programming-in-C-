using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public class PutCommand : Command
    {
        public PutCommand() :
            base(new string[] { "put", "drop" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container = null;

            if (text.Length == 4)
            {
                if (text[0] != "put")
                {
                    return "What do you want to put?";
                }

                if (text[2] != "in")
                {
                    return "What do you want to put in?";
                }
                _container = FetchContainer(p, text[3]);

                string _itemid = text[1];

                if (_container == null)
                {
                    return "Could not find " + text[3];
                }

                return PutItemIn(p, _itemid, _container);
            }

            return "I don't know how to put like that";
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }

        public string PutItemIn(Player p, string thingId, IHaveInventory container)
        {
            if (p.Locate(thingId) != null)
            {
                Item _item = p.Take(thingId) as Item;
                if (_item == null)
                {
                    return "Could not put " + thingId;
                }
                container.Put(_item);
                return "You have put the " + thingId + " in " + container.Name + ".\r\n";
            }
            return "Could not find " + thingId;
        }
    }
}
