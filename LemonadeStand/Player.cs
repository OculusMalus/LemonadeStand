using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Player
    {
        public string name;


        public void Print()
        {
            Console.WriteLine("Hello, {0}! Let's check the weather for today.\n", name);
        }

        public string SetName()
        {
            Console.WriteLine("Hello, welcome to the world of Lemonade Stand! Please enter your name: \n");
            name = Console.ReadLine();
            Console.ReadKey();
            return name;        }
    }
     
    
}
