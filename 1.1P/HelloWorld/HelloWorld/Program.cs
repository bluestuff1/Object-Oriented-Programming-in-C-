using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelloWorld
{
    class Program
    {
        public static void Main(string[] args)
        {
            Message myMessage;
            Message[] messages = new Message[4];

            string name;

            while (true)
            {
                messages[0] = new Message("Did you know your name backwards is Milk?");
                messages[1] = new Message("Welcome back oh great educator!");
                messages[2] = new Message("Git Gud");
                messages[3] = new Message("Yeah...We can't be friends");

                Console.WriteLine("Enter name: ");
                name = Console.ReadLine().ToLower();

                switch (name)
                {
                    case "klim":
                        messages[0].Print();
                        break;
                    case "jimmy":
                        messages[1].Print();
                        break;
                    case "danny":
                        messages[2].Print();
                        break;
                    default:
                        messages[3].Print();
                        break;
                }

                myMessage = new Message("Hello World - from Message Object");
                myMessage.Print();

                Console.ReadLine();
            }
        }
    }
}
