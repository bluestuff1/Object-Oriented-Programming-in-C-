using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure.Core
{
    public class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Location(string name, string desc) :
            base(new string[] { "location", "room" }, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public Location(string name, string desc, List<Path> paths) :
            this(name, desc)
        {
            _paths = paths;
        }

        public GameObject Locate(string id)
        {
            if (this.AreYou(id))
            {
                return this;
            }

            foreach (Path p in _paths)
            {
                if (p.AreYou(id))
                {
                    return p;
                }
            }
            return _inventory.Fetch(id);
        }

        public void AddPath(Path path)
        {
            _paths.Add(path);
        }

        public string ItemList
        {
            get
            {
                if (_inventory.Count != 0)
                {
                    return "This room contains: \r\n" + _inventory.ItemList;
                }
                return "";
            }
        }

        public bool HasPath(string destination)
        {
            foreach (Path p in _paths)
            {
                if (p.FirstId.ToLower() == destination.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public GameObject Take(string id)
        {
            return Inventory.Take(id);
        }

        public void Put(Item itm)
        {
            this.Inventory.Put(itm);
        }

        public override string FullDescription => base.FullDescription + "\r\nIn the " + this.Name + " you can see: " + _inventory.ItemList;

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
}
