using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public class Bag : Item, IHaveInventory
    {
        private Inventory _inventory;

        public Bag(string[] ids, string name, string desc) :
            base(ids, name, desc)
        {
            _inventory = new Inventory();
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }
            return _inventory.Fetch(id);
        }

        public GameObject Take(string id)
        {
            return Inventory.Take(id);
        }

        public void Put(Item itm)
        {
            this.Inventory.Put(itm);
        }

        public override string FullDescription
        {
            get
            {
                return "In the " + this.Name + " you can see: " + _inventory.ItemList;
            }
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
