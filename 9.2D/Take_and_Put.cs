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


    public class TakeCommand : Command
    {
        public TakeCommand() :
            base(new string[] { "pickup", "take", "grab" })
        {

        }

        public override string Execute(Player p, string[] text)
        {
            IHaveInventory _container = null;

            if (text.Length == 2 | text.Length == 4)
            {
                if (text[0] != "take")
                {
                    return "What do you want to take?";
                }

                if (text.Length == 4)
                {
                    if (text[2] != "from")
                    {
                        return "What do you want to take from?";
                    }
                }

            }
            else
            {
                return "I don't know how to take like that";
            }

            string _itemid = text[1];

            switch (text.Length)
            {
                case 2:
                    _container = p.Location as IHaveInventory;
                    break;
                case 4:
                    _container = FetchContainer(p, text[3]);
                    break;
            }

            if(_container == null)
            {
                return "Could not find " + text[3];
            }

            return TakeItemFrom(p, _itemid, _container);
        }

        public IHaveInventory FetchContainer(Player p, string containerId)
        {
            return p.Locate(containerId) as IHaveInventory;
        }   

        public string TakeItemFrom(Player p, string thingId, IHaveInventory container)
        {
            if (container.Locate(thingId) != null)
            {
                Item _item = container.Take(thingId) as Item;
                if(_item == null)
                {
                    return "Could not take " + thingId;
                }
                p.Inventory.Put(_item);

                return "You have taken the " + thingId + ".\r\n";
            }
            return "Could not find " + thingId;
        }
    }

}