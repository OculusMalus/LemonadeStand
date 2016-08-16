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
        public string cupPriceString;
        public decimal cupPrice;
            

        public string SetName()
        {
            Console.WriteLine("Hello, welcome to the world of Lemonade Stand! Please enter your name: \n");
            name = Console.ReadLine();
            Console.WriteLine("Hello, {0}! Let's check the weather for today.\n", name);
            Console.WriteLine("Press a key to continue\n");
            Console.ReadKey();
            return name;
        }

        public decimal SetPrice()
        {
            Console.WriteLine("How much will you charge per cup?\n");
            cupPriceString = Console.ReadLine();
            cupPrice = decimal.Parse(cupPriceString);
            return cupPrice;
        }

       
    }
     
    
}
