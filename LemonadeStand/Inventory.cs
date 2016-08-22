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
        public int lemonsPerRecipe=3;
        public int cupsOfSugar;
        public int sugarDividerPerRecipe=8;
        public int poundsOfIce;
        public int plasticCups;
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

        public void SetRecipe()
        {
            Console.WriteLine("\nCustomize your lemonade recipe here. A standard recipe uses 3 lemons\n" +
                                "and one cup of sugar for eight servings. Make your lemonade extra sour\n" +
                                "with more lemon, or extra sweet with more sugar.\n\n");
            Console.WriteLine("Enter '1' for a standard recipe, '2' for sour, or'3' for sweet.\n");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": lemonsPerRecipe = 3;
                    break;
                case "2": lemonsPerRecipe = 4;
                    break;
                case "3": sugarDividerPerRecipe = 5;
                    break;
                default:
                    break;
            }
        }

        public int HowMuchLemonadeCanIMakeToday() 
        {
            int lemonsCanMake = lemons * 8/lemonsPerRecipe;
            int sugarCanMake = cupsOfSugar * sugarDividerPerRecipe;
            int iceCanMake = (poundsOfIce +9)* 10;
            int cupsCanServe = plasticCups;
            int[] maxBatchArray = { lemonsCanMake, sugarCanMake, iceCanMake, cupsCanServe };
            todayICanMake = maxBatchArray.Min();      
            Console.WriteLine("You can make {0} cups of lemonade with these ingredients.\n",todayICanMake);
            return todayICanMake;
        }
        public int AdjustLemonInventory(int numberOfCupsSold)
        {
            int lemonsUsed = (numberOfCupsSold*lemonsPerRecipe+7) / 8; //must round up for any part of a lemon that was used
            Console.WriteLine("You used {0} lemons!", lemonsUsed);
            lemons -= lemonsUsed;
            return lemons;
        }

        public int AdjustSugarInventory(int numberOfCupsSold)

        {
            int cupsOfSugarUsed = (numberOfCupsSold +7) / sugarDividerPerRecipe; //1 cup of sugar makes 8 cups of lemonade
            Console.WriteLine("You used {0} cups of sugar!", cupsOfSugarUsed);
            cupsOfSugar -= cupsOfSugarUsed;
            return cupsOfSugar;
        }

        public int AdjustIceInventory(int numberOfCupsSold)
        {
            int poundsOfIceUsed = (numberOfCupsSold +9 )/ 10; //1 pound of ice for each 10 cups
            poundsOfIce -= poundsOfIceUsed;  //take the pounds used out of the ten pound bags purchased.
            Console.WriteLine("You used {0} pounds of ice!", poundsOfIceUsed);
            return poundsOfIce;
        }

        public int AdjustPlasticCupInventory(int numberOfCupsSold)
        {
            plasticCups -= numberOfCupsSold;
            Console.WriteLine("You used {0} cups!", numberOfCupsSold);
            return plasticCups;
        }

        public void GoGroceryShopping(Player _player)
        {
           Console.WriteLine("What would you like to buy? Enter:\n" +
                                "1 - for lemons\n" +
                                "2 - for sugar\n" +
                                "3 - for ice\n" +
                                "4 - for plastic cups\n"+ 
                                "5 - ready to sell lemonade!" + "\nYou have ${0} left to spend.\n", cashOnHand);

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": Console.WriteLine("");
                    BuyLemons(_player);
                    GoGroceryShopping(_player);
                    break;
                case "2":
                    BuySugar(_player);
                    GoGroceryShopping(_player);
                    break;
                case "3":
                    BuyIce(_player);
                    GoGroceryShopping(_player);
                    break;
                case "4":
                    BuyPlasticCups(_player);
                    GoGroceryShopping(_player);
                    break;
                case "5":
                    break;
                default:
                    GoGroceryShopping(_player);
                    break;
            }
            
                    
        }

        public void CheckCupboard(Player _player)
        {
            cashOnHand = _player.HowMuchMoneyDoIHave();
            Console.WriteLine("Let's see if you have all the ingredients you need.\n");
            Console.WriteLine("You now have:\n" +
                "Lemons\t\t Cups Sugar\t\t Pounds Ice\t\t Plastic Cups\n" +
                "{0}\t\t {1}\t\t\t {2}\t\t\t {3}\n\nCurrent Prices\n" +
                "${4} each\t ${5}/10lbs\t\t ${6}/10lbs\t\t${7}/100ct\n" +
                "\nStandard recipe amounts:\n"+
                "3 make 8 cups\t 10lb makes 160 cups\t 10lb for 50 cups:", lemons, cupsOfSugar, poundsOfIce, 
                plasticCups, priceOfLemons, priceOfSugar, priceOfIce, priceOfCups);
            Console.WriteLine("");
            Console.WriteLine("You have ${0} available to spend.", cashOnHand);
         }

        public int BuyLemons(Player _player)
        {
            int numberOfNewItem;
            Console.Clear();
            CheckCupboard(_player);
            Console.WriteLine("Large lemons cost ${0} each. You need three large lemons\n"+
                                "to make 8 cups of standard lemonade." +" How many large lemons\n"+
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
            Console.Clear();
            CheckCupboard(_player);
            Console.WriteLine("A 10 pound bag of sugar costs ${0} and contains 20 cups of\n"+
                                "sugar. You need one cup of sugar to make 8 cups of lemonade.\n"+
                                "One cup of sugar for 5 servings of extra sweet lemonade."+
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
            Console.Clear();
            CheckCupboard(_player);
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
            Console.Clear();
            CheckCupboard(_player);

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
                                    "It's ok, though. You will to do better tomorrow.\n\n",numberOfCupsSold, batch);
                return batch;
            }
        }
    }
}
    
