using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace P3._2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Clock myClock = new Clock();

            while (true)
            {
                myClock.PrintTime();
                Thread.Sleep(1000);
                myClock.Tick();
            }
        }
    }
}
