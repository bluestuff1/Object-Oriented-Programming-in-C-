using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public class Inventory
    {
        private List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public bool HasItem(string id)
        {
            if (_items.Count != 0)
            {
                foreach (Item i in _items)
                {
                    if (i.AreYou(id))
                    {
                        return true;
                    }
                }
            }
            return false;

        }

        public void Put(Item itm)
        {
            _items.Add(itm);
        }

        public Item Take(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    Item ItemFound = i;
                    _items.Remove(i);
                    return ItemFound;
                }
            }
            return null;
        }

        public Item Fetch(string id)
        {
            foreach (Item i in _items)
            {
                if (i.AreYou(id))
                {
                    return i;
                }
            }
            return null;
        }

        public string ItemList
        {
            get
            {
                string list = "";
                foreach (Item i in _items)
                {
                    list += "   " + i.ShortDescription + Environment.NewLine;
                }
                return list;
            }
        }


        public int Count
        {
            get
            {
                return _items.Count;
            }
        }
    }
}
