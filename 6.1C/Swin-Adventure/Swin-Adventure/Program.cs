using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swin_Adventure
{
    class Program
    {
        static void Main(string[] args)
        {
            IdentifiableObject id = new IdentifiableObject(new string[] { "id1", "id2" });

            Console.WriteLine("Welcome to Swin-Adventure");
            Console.WriteLine("Swin-Adventure is a fantasy adventure game that consists of a number of interconnected locations.");           
            Console.WriteLine();
            Console.WriteLine("Let's begin with your name");
            string name = Console.ReadLine();
            Console.WriteLine("Right... So your name is " + name);
            Console.WriteLine("How would you describe yourself?");
            string description = Console.ReadLine();
            Console.WriteLine(name + ", " + description + ", your very own Swin-Adventure legend is about to unfold!");

            Player p = new Player(name, description);
            Bag bag = new Bag(new string[] { "small", "black", "bag" }, "bag", "A small black bag");
            Item sword = new Item(new string[] { "sword" }, "bronze", "This is a very cheap sword");
            Item coin = new Item(new string[] { "coin" }, "ancient", "This coin holds no value at all");
            Item gem = new Item(new string[] { "gem" }, "red", "This is a very red gem");
            Location start = new Location("room", "This place stinks");

            p.Inventory.Put(sword);
            p.Inventory.Put(bag);
            bag.Inventory.Put(gem);
            start.Inventory.Put(coin);
            p.Location = start;

            Command l = new LookCommand();

            Console.WriteLine();
            Console.WriteLine("Please enter your command");

            while (true)
            {
                string input = Console.ReadLine();


                if (input.Equals("exit"))
                {
                    break;
                }

                Console.WriteLine(l.Execute(p, input.Split()));
                Console.WriteLine();
            }

        }
    }
}
