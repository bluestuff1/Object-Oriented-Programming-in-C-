using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Swin_Adventure
{
    class Location : GameObject, IHaveInventory
    {
        private Inventory _inventory;
        private List<Path> _paths;

        public Location(string name, string desc) :
            base(new string[] { "location", "room" }, name, desc)
        {
            _inventory = new Inventory();
            _paths = new List<Path>();
        }

        public Location(string name, string desc, List<Path> paths):
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

            foreach(Path p in _paths)
            {
                if(p.AreYou(id))
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
            foreach(Path p in _paths)
            {
                if(p.FirstId.ToLower() == destination.ToLower())
                {
                    return true;
                }
            }
            return false;
        }

        public Inventory Inventory
        {
            get
            {
                return _inventory;
            }
        }
    }
    [TestFixture]
    class TestLocation
    {
        Location l;
        Player p;
        Item sword = new Item(new string[] { "sword" }, "bronze", "This is a cheap sword");

        [Test]
        public void TestLocationIdentifyItself()
        {
            p = new Player("player1", "This is player 1");
            l = new Location("toilet", "This place stinks");

            bool actual = l.AreYou("location");

            Assert.IsTrue(actual, "Locations can identify themselves");
        }

        [Test]
        public void TestLocationLocateItems()
        {
            p = new Player("player1", "This is player 1");
            l = new Location("toilet", "This place stinks");
            l.Inventory.Put(sword);

            GameObject expected = sword;
            GameObject actual = l.Locate(sword.FirstId);

            Assert.AreEqual(expected, actual, "Locations can locate items they have");
        }

        [Test]
        public void TestPlayerLocateItemsInLocation()
        {
            p = new Player("player1", "This is player 1");
            l = new Location("toilet", "This place stinks");

            p.Location = l;
            l.Inventory.Put(sword);
            
            GameObject expected = sword;
            GameObject actual = p.Locate(sword.FirstId);

            Assert.AreEqual(expected, actual, "Players can locate items in their location");
        }
    }
}
