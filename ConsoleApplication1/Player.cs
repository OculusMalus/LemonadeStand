using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
           class Player
        {
            public string name;
            public string cupPriceString;
            public decimal cupPrice;
            public decimal cashBox = 25.00m;


            public string SetName()
            {
                Console.WriteLine("Hello, welcome to Lemonade Stand! You will have the opportunity\n" +
                                    "to build a lemonade empire over the next seven days.\nPlease enter your name: \n");
                name = Console.ReadLine();
                return name;
            }
        }
}
