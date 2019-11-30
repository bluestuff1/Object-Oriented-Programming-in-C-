using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public class Player : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private Location _location;

        public Player(string name, string desc) :
            base(new string[] { "me", "inventory" }, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }

            GameObject item = _inventory.Fetch(id);
            if (item != null) {
                return item;
            }
            if (_location != null)
            {
                item = _location.Locate(id);
                return item;
            } else
            {
                return null;
            }
        }

        public GameObject Take(string id)
        {
            return Inventory.Take(id);
        }

        public void Put(Item itm)
        {
            this.Inventory.Put(itm);
        }


        public void Move(Path path)
        {
            if(path.Destination != null)
            {
                _location = path.Destination;
            }
        }

        public override string FullDescription
        {
            get
            {
                return "You are carrying: " + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }

        public Location Location
        {
            get
            {
                return _location;
            }
            set
            {
                _location = value;
            }
        }

    }
}
