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
        public int bagsOfSugar;
        public int poundsOfIce;
        public int bagsOfIce;
        public int plasticCups;
        public int madeThisManyCups;
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
            todayICanMake = maxBatchArray.Min();      //figure out how to choose the smallest value from the four ingredients`
            Console.WriteLine("You can make {0} cups of lemondade with these ingredients.\n",todayICanMake);
            return todayICanMake;
        }
        public int AdjustLemonInventory(int numberOfCupsSold)
        {
            int lemonsUsed = (numberOfCupsSold + 7) *3/ 8; //must round up for any part of a lemon that was used
            Console.WriteLine("you used {0} lemons!", lemonsUsed);
            lemons -= lemonsUsed;
            if (lemons < 0)
            {
                lemons = 0;
            }
            return lemons;
        }

        public int AdjustSugarInventory(int numberOfCupsSold)
        {
            int cupsOfSugarUsed = (numberOfCupsSold +7) / 8; //1 cup of sugar makes 8 cups of lemonade
            cupsOfSugar -= cupsOfSugarUsed;
            if (cupsOfSugar < 0)
            {
                cupsOfSugar = 0;
            }
            Console.WriteLine("you used {0} cups of sugar!", cupsOfSugarUsed);
            return cupsOfSugar;
        }

        public int AdjustIceInventory(int numberOfCupsSold)
        {
            int poundsOfIceUsed = (numberOfCupsSold +9 )/ 10; //1 pound of ice for each 10 cups
            poundsOfIce -= poundsOfIceUsed;  //take the pounds used out of the ten pound bags purchased.
            if (poundsOfIce < 0)
            {
                poundsOfIce = 0;
            }
            Console.WriteLine("you used {0} pounds of ice!", poundsOfIceUsed);
            return poundsOfIce;
        }

        public int AdjustPlasticCupInventory(int numberOfCupsSold)
        {
            plasticCups -= numberOfCupsSold;
            if (plasticCups < 0)
            {
                plasticCups = 0;
            }
            Console.WriteLine("you used {0} cups!", numberOfCupsSold);
            return plasticCups;
        }

        public void GoGroceryShopping(Player _player)
        {
            
            Console.WriteLine("You need to purchase some ingedients and supplies for your\n" +
                                "lemonade stand. Let's go shopping!\n");
            Console.WriteLine("");
            BuyLemons(_player);
            Console.WriteLine("you have ${0} left to spend.\n", cashOnHand);
            BuySugar(_player);
            Console.WriteLine("you have ${0} left to spend.\n", cashOnHand);
            BuyIce(_player);
            Console.WriteLine("you have ${0} left to spend.\n", cashOnHand);
            BuyPlasticCups(_player);
                 
        }

        public void CheckCupboard(Player _player)
        {
            cashOnHand = _player.HowMuchMoneyDoIHave(cashOnHand);
            Console.WriteLine("Let's see if you have all the ingredients you need.\n");
            Console.WriteLine("You have:\n" +
                "Lemons\t Cups Sugar\t Pounds Ice\t Plastic Cups\n" +
                "{0}\t {1}\t\t {2}\t\t {3}\n", lemons, cupsOfSugar, poundsOfIce, plasticCups);
            Console.WriteLine("You have ${0} available to spend.", cashOnHand);
        }

        public int BuyLemons(Player _player)
        {
            Console.WriteLine("Large lemons cost ${0} each. You need three large lemons\n"+
                                "to make 8 cups of basic lemonade." +" How many large lemons\n"+
                                "do you want to purchase for today?\n",priceOfLemons);
            string lemonString = Console.ReadLine();
            int newItem = int.Parse(lemonString);
            decimal itemPrice = priceOfLemons;
            newItem = BuyItem(_player, newItem, itemPrice);
            lemons += newItem;
            return lemons;
        }

        public int BuySugar(Player _player)
        {
            Console.WriteLine("A 10 pound bag of sugar costs ${0} and contains 20 cups of\n"+
                                "sugar. You need one cup of sugar to " + "make 8 cups of lemonade.\n"+
                                "How many bags of sugar will you purchase today?",priceOfSugar);
            string sugarString = Console.ReadLine();
            int newItem = int.Parse(sugarString);
            decimal itemPrice = priceOfSugar;
            newItem = BuyItem(_player, newItem, itemPrice);
            cupsOfSugar += newItem * 20;
            return cupsOfSugar;
        }

        public int BuyIce(Player _player)
        {
            Console.WriteLine("A ten pound bag of ice costs ${0} and will chill 50 servings\n"+
                                "of lemonade. How many 10 pound bags of ice will you purchase today?",priceOfIce);
            string iceString = Console.ReadLine();
            int newItem = int.Parse(iceString);
            decimal itemPrice = priceOfIce;
            newItem = BuyItem(_player, newItem, itemPrice);
            poundsOfIce += newItem*10; //adding a full 10 pounds each time you purchase.
            return poundsOfIce;
        }

        public int BuyPlasticCups(Player _player)
        {
            Console.WriteLine("Your plastic cups come in packages of 100 that cost ${0}. How\n"+
                                "many packges do you want to buy today?",priceOfCups);
            string cupString = Console.ReadLine();
            int newItem = int.Parse(cupString);
            decimal itemPrice = priceOfCups;
            newItem = BuyItem(_player, newItem, itemPrice);
            plasticCups += newItem*100;
            return plasticCups;
        }

        public int SetBasicRecipe()
        {
            Console.WriteLine("Try to predict how many cups of lemonade can you sell on a day like today:");
            string cupString = Console.ReadLine();
            madeThisManyCups = int.Parse(cupString);

            bagsOfIce = (int)Math.Ceiling((double)(madeThisManyCups / 50));
            bagsOfSugar = (int)Math.Ceiling((double)madeThisManyCups / 160);
            lemons = (int)Math.Ceiling((double)madeThisManyCups * 3 / 8);

            Console.WriteLine("Let's buy {0} bags of ice, {1} bags of sugar, and {2} lemons. Thankfully, water is still " +
                "free!", bagsOfIce, bagsOfSugar, lemons);
            decimal _investment = (decimal)Math.Round(bagsOfIce * 2.49 + bagsOfSugar * 5.49 + lemons * 0.79);
            Console.WriteLine("You spent ${0} on ingredients", _investment);
            return lemons;
            

        }

        public int BuyItem(Player _player, int newItem, decimal itemPrice)
        {
            decimal amountSpent = (Decimal)newItem * itemPrice;
            if (cashOnHand - amountSpent > 0m)
            {
                cashOnHand = _player.SpendCashBox(amountSpent);
                return newItem;
            }
            else
            {
                newItem = 0;
                Console.WriteLine("Check your math. You don't have enough cash on hand to\n" +
                                    "buy that many. Let's try again. you have ${0} left to spend.", cashOnHand);
                Console.ReadKey();
                GoGroceryShopping(_player);
            }
            return newItem;
        }

            public int HowManyCupsDidIReallySell(int numberOfCupsSold, int batch)
        {
            if( batch > numberOfCupsSold)
            {
                Console.WriteLine("Great job! You sold {0} cups of lemonade today!", batch);
                return numberOfCupsSold;
            }
            else
            {
                Console.WriteLine("Too bad you didn't have more ingredients on hand.\n" +
                                    "You could have sold {0} cups but you only had enough\n" +
                                    "to make {1} before you sold out. Try to do better tomorrow.",
                                    numberOfCupsSold, batch);
                return batch;
            }

        }

        
        
    }
}
    
