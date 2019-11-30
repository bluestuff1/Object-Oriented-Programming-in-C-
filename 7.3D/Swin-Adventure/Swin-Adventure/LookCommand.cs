using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Swin_Adventure
{
    class LookCommand : Command
    {
        public LookCommand() :
            base(new string[] {"look"})
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

                if(text[1] != "at")
                {
                    return "What do you want to look at?";
                }

                if(text.Length == 5)
                {
                    if(text[3] != "in")
                    {
                        return "What do you want to look in?";
                    }
                }

            } else
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
            if(container.Locate(thingId) != null)
            {
                return container.Locate(thingId).FullDescription;
            }
            return "Could not find " + thingId;
        }
    }

    [TestFixture]
    class TestLookCommand
    {
        Command l;
        Player p;
        Bag b;

        Item sword = new Item(new string[] { "sword" }, "bronze", "This is a cheap sword");
        Item gem = new Item(new string[] { "gem" }, "red", "This is a red gem");

        [Test]
        public void TestLookAtMe()
        {
            p = new Player("Player 1", "This is player 1");
            l = new LookCommand();

            string expected = "You are carrying: ";
            string actual = l.Execute(p, new string[] { "look", "at", "inventory" });

            Assert.AreEqual(expected, actual, "Look at me test");
        }

        [Test]
        public void TestLookAtGem()
        {
            p = new Player("Player 1", "This is player 1");
            l = new LookCommand();
            p.Inventory.Put(gem);


            string expected = "This is a red gem";
            string actual = l.Execute(p, new string[] { "look", "at", "gem" });

            Assert.AreEqual(expected, actual, "Look at gem test");
        }

        [Test]
        public void TestLookAtUnk()
        {
            p = new Player("Player 1", "This is player 1");
            l = new LookCommand();

            string expected = "Could not find gem";
            string actual = l.Execute(p, new string[] { "look", "at", "gem" });

            Assert.AreEqual(expected, actual, "Can't find gem test");
        }

        [Test]
        public void TestLookAtGemInMe()
        {
            p = new Player("Player 1", "This is player 1");
            l = new LookCommand();
            p.Inventory.Put(gem);


            string expected = "This is a red gem";
            string actual = l.Execute(p, new string[] { "look", "at", "gem", "in", "me" });

            Assert.AreEqual(expected, actual, "Look at gem test");
        }

        [Test]
        public void TestLookAtGemInBag()
        {
            p = new Player("Player 1", "This is player 1");
            b = new Bag(new string[] { "big", "gold", "bag" }, "bag", "A big gold bag");
            b.Inventory.Put(gem);
            p.Inventory.Put(b);
            l = new LookCommand();

            string expected = "This is a red gem";
            string actual = l.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });

            Assert.AreEqual(expected, actual, "Look at gem test");
        }

        [Test]
        public void TestLookAtGemInNoBag()
        {
            p = new Player("Player 1", "This is player 1");
            p.Inventory.Put(gem);
            l = new LookCommand();

            string expected = "Could not find bag";
            string actual = l.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });

            Assert.AreEqual(expected, actual, "Look at gem test");
        }

        [Test]
        public void TestLookAtNoGemInBag()
        {
            p = new Player("Player 1", "This is player 1");
            b = new Bag(new string[] { "big", "gold", "bag" }, "bag", "A big gold bag");
            p.Inventory.Put(b);
            l = new LookCommand();

            string expected = "Could not find gem";
            string actual = l.Execute(p, new string[] { "look", "at", "gem", "in", "bag" });

            Assert.AreEqual(expected, actual, "Look at no gem in bag test");

        }

        [Test]
        public void TestInvalidLook()
        {
            p = new Player("Player 1", "This is player 1");
            l = new LookCommand();
            p.Inventory.Put(gem);


            string expected = "I don't know how to look like that";
            string actual = l.Execute(p, new string[] { "look", "around" });

            Assert.AreEqual(expected, actual, "Look at gem test");
        }
    }
}
