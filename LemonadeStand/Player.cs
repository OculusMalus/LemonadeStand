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
