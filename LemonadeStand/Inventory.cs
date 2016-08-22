using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        public int lemons;
        public int cupsOfSugar;
       //public int bagsOfSugar;
        public int poundsOfIce;
        //public int bagsOfIce;
        public int plasticCups;
        //public int madeThisManyCups;
        public int todayICanMake;
        public decimal cashOnHand;
        public decimal priceOfLemons = 0.59m;
        public decimal priceOfSugar = 5.49m;
        public decimal priceOfIce = 1.99m;
        public decimal priceOfCups = 2.19m;
        int[] inventoryItems = new int[5];

               

        public void AdjustInventory(int numberOfCupsSold)
        {
            AdjustLemonInventory(numberOfCupsSold);
            AdjustSugarInventory(numberOfCupsSold);
            AdjustIceInventory(numberOfCupsSold);
            AdjustPlasticCupInventory(numberOfCupsSold);
        }

        public int HowMuchLemonadeCanIMakeToday()
        {
            int lemonsCanMake = lemons * 8/3;
            int sugarCanMake = cupsOfSugar * 8;
            int iceCanMake = (poundsOfIce +9)* 10;
            int cupsCanServe = plasticCups;
            int[] maxBatchArray = { lemonsCanMake, sugarCanMake, iceCanMake, cupsCanServe };
            todayICanMake = maxBatchArray.Min();      
            Console.WriteLine("You can make {0} cups of lemondade with these ingredients.\n",todayICanMake);
            return todayICanMake;
        }
        public int AdjustLemonInventory(int numberOfCupsSold)
        {
            int lemonsUsed = (numberOfCupsSold*3+7) / 8; //must round up for any part of a lemon that was used
            //Console.WriteLine("you used {0} lemons!", lemonsUsed);
            lemons -= lemonsUsed;
            return lemons;
        }

        public int AdjustSugarInventory(int numberOfCupsSold)
        {
            int cupsOfSugarUsed = (numberOfCupsSold +7) / 8; //1 cup of sugar makes 8 cups of lemonade
            //Console.WriteLine("you used {0} cups of sugar!", cupsOfSugarUsed);
            cupsOfSugar -= cupsOfSugarUsed;
            return cupsOfSugar;
        }

        public int AdjustIceInventory(int numberOfCupsSold)
        {
            int poundsOfIceUsed = (numberOfCupsSold +9 )/ 10; //1 pound of ice for each 10 cups
            poundsOfIce -= poundsOfIceUsed;  //take the pounds used out of the ten pound bags purchased.
            //Console.WriteLine("you used {0} pounds of ice!", poundsOfIceUsed);
            return poundsOfIce;
        }

        public int AdjustPlasticCupInventory(int numberOfCupsSold)
        {
            plasticCups -= numberOfCupsSold;
            //Console.WriteLine("you used {0} cups!", numberOfCupsSold);
            return plasticCups;
        }

        public void GoGroceryShopping(Player _player)
        {
            Console.WriteLine("Let's go shopping!\n");
            Console.WriteLine("");
            BuyLemons(_player);
            Console.WriteLine("you have ${0} left to spend.\n", cashOnHand);
            BuySugar(_player);
            Console.WriteLine("you have ${0} left to spend.\n", cashOnHand);
            BuyIce(_player);
            Console.WriteLine("you have ${0} left to spend.\n", cashOnHand);
            BuyPlasticCups(_player);
            Console.WriteLine("\nYou have ${0} left after purchasing ingredients.\n", cashOnHand);
        }

        public void CheckCupboard(Player _player)
        {
            cashOnHand = _player.HowMuchMoneyDoIHave();
            Console.WriteLine("Let's see if you have all the ingredients you need.\n");
            Console.WriteLine("You now have:\n" +
                "Lemons\t\t Cups Sugar\t\t Pounds Ice\t\t Plastic Cups\n" +
                "{0}\t\t {1}\t\t\t {2}\t\t\t {3}\n\n"+
                "${4} each\t ${5}/10lbs\t\t ${6}/10lbs\t\t${7}/100ct\n"+
                "3 make 8 cups\t 10lb makes 160 cups\t 10lb for 50 cups:", lemons, cupsOfSugar, poundsOfIce, 
                plasticCups, priceOfLemons, priceOfSugar, priceOfIce, priceOfCups);
            Console.WriteLine("");
            Console.WriteLine("You have ${0} available to spend.\n\nYou'll need to buy lemons, sugar, ice and cups."+
                                " Plan carefully.\nThree lemons and one cup of sugar are needed to make eight cups\n"+
                                "of lemonade. You'll need 10 pounds of ice for every 50 cups.", cashOnHand);
         }

        public int BuyLemons(Player _player)
        {
            int numberOfNewItem;
            Console.WriteLine("Large lemons cost ${0} each. You need three large lemons\n"+
                                "to make 8 cups of basic lemonade." +" How many large lemons\n"+
                                "do you want to purchase for today?\n",priceOfLemons);
            string lemonString = Console.ReadLine();
            try
            {
                numberOfNewItem = int.Parse(lemonString);
            }
            catch
            {
                Console.WriteLine("Please type a number");
                return BuyLemons(_player);
            }
            decimal itemPrice = priceOfLemons;
            numberOfNewItem = BuyItem(_player, numberOfNewItem, itemPrice);
            if (numberOfNewItem >= 9999)
            {
                Console.Clear();
                CheckCupboard(_player);
                return BuyLemons(_player);
            }
            else
            {
                lemons += numberOfNewItem;
                return lemons;
            }
        }

        public int BuySugar(Player _player)
        {
            int numberOfNewItem;
            Console.WriteLine("A 10 pound bag of sugar costs ${0} and contains 20 cups of\n"+
                                "sugar. You need one cup of sugar to " + "make 8 cups of lemonade.\n"+
                                "How many bags of sugar will you purchase today?",priceOfSugar);
            string sugarString = Console.ReadLine();
            try
            {
                numberOfNewItem = int.Parse(sugarString);
            }
            catch
            {
                Console.WriteLine("Please type a number");
                return BuySugar(_player);
            }
            decimal itemPrice = priceOfSugar;
            numberOfNewItem = BuyItem(_player, numberOfNewItem, itemPrice);
            if (numberOfNewItem >= 9999)
            {
                Console.Clear();
                CheckCupboard(_player);
                return BuySugar(_player);
            }
            else
            {
                cupsOfSugar += numberOfNewItem * 20;
                return cupsOfSugar;
            }
        }

        public int BuyIce(Player _player)
        {
            int numberOfNewItem;
            Console.WriteLine("A ten pound bag of ice costs ${0} and will chill 50 servings\n"+
                                "of lemonade. How many 10 pound bags of ice will you purchase today?",priceOfIce);
            string iceString = Console.ReadLine();
            try
            {
                numberOfNewItem = int.Parse(iceString);
            }
            catch
            {
                Console.WriteLine("Please type a number");
                return BuyIce(_player);
            }
            decimal itemPrice = priceOfIce;
            numberOfNewItem = BuyItem(_player, numberOfNewItem, itemPrice);
            if (numberOfNewItem >= 9999)
            {
                Console.Clear();
                CheckCupboard(_player);
                return BuyIce(_player);
            }
            else
            {
                poundsOfIce += numberOfNewItem * 10; //adding a full 10 pounds each time you purchase.
                return poundsOfIce;
            }
        }

        public int BuyPlasticCups(Player _player)
        {
            int numberOfNewItem;
            Console.WriteLine("Your plastic cups come in packages of 100 that cost ${0}. How\n"+
                                "many packges do you want to buy today?",priceOfCups);
            string cupString = Console.ReadLine();
            try
            {
                numberOfNewItem = int.Parse(cupString);
            }
            catch
            {
                Console.WriteLine("Please type a number");
                return BuyPlasticCups(_player);
            }
            decimal itemPrice = priceOfCups;
            numberOfNewItem = BuyItem(_player, numberOfNewItem, itemPrice);
            if (numberOfNewItem >= 9999)
            {
                Console.Clear();
                CheckCupboard(_player);
                return BuyPlasticCups(_player);
            }
            else
            {
                plasticCups += numberOfNewItem * 100;
                return plasticCups;
            }
        }

        

        public int BuyItem(Player _player, int numberOfNewItem, decimal itemPrice)
        {
            decimal amountSpent = (Decimal)numberOfNewItem * itemPrice;
            if (cashOnHand - amountSpent > 0m)
            {
                cashOnHand = _player.SpendCashBox(amountSpent);
                return numberOfNewItem;
            }
            else
            {
                numberOfNewItem = 9999;
                Console.Clear();
                Console.WriteLine("Check your math. You don't have enough cash on hand to\n" +
                                    "buy that many. Did you buy too many items? You can return\n"+
                                    "them to the store by purchasing a negative amount. Press any"+
                                    "key to check your inventory and try again.\nYou have ${0} " +
                                    "left to spend.\n\n", cashOnHand);
                Console.ReadKey();
                Console.Clear();
                }
            return numberOfNewItem;
        }

            public int HowManyCupsDidIReallySell(int numberOfCupsSold, int batch)
        {
            if( batch >= numberOfCupsSold)
            {
                Console.WriteLine("Great job! You sold all {0} cups today!\n"+"", numberOfCupsSold);
                return numberOfCupsSold;
            }
            else
            {
                Console.WriteLine("Too bad you didn't have more ingredients on hand.\n" +
                                    "You only had enough to make {1} cups before you sold out.\n\n"+
                                    "It's ok, though. You will to do better tomorrow.\n\n"+
                                    "Press any key to continue.",
                                    numberOfCupsSold, batch);
                return batch;
            }
        }
    }
}
    
