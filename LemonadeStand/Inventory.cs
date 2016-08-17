using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Inventory
    {
        public int batchSize = 200;//please change when done testing
        public int lemons=50;//please change to test
        public int cupsOfSugar;
        public int bagsOfSugar;
        public int poundsOfIce;
        public int bagsOfIce;
        public int plasticCups;
        public int madeThisManyCups;
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
            int lemonsCanMake = lemons * 8 / 3;
            return lemonsCanMake;
        }
        public int AdjustLemonInventory(int numberOfCupsSold)
        {
            int lemonsUsed = (numberOfCupsSold + 7) *3/ 8; //must round up for any part of a lemon that was used
            Console.WriteLine("you used {0} lemons!", lemonsUsed);
            lemons -= lemonsUsed;
            return lemons;
        }

        public int AdjustSugarInventory(int numberOfCupsSold)
        {
            int cupsOfSugarUsed = (numberOfCupsSold +7) / 8; //1 cup of sugar makes 8 cups of lemonade
            cupsOfSugar -= cupsOfSugarUsed;
            Console.WriteLine("you used {0} cups of sugar!", cupsOfSugarUsed);
            return cupsOfSugar;
        }

        public int AdjustIceInventory(int numberOfCupsSold)
        {
            int poundsOfIceUsed = (numberOfCupsSold +9 )/ 10; //1 pound of ice for each 10 cups
            poundsOfIce -= poundsOfIceUsed;  //take the pounds used out of the ten pound bags purchased.
            Console.WriteLine("you used {0} pounds of ice!", poundsOfIceUsed);
            return poundsOfIce;
        }

        public int AdjustPlasticCupInventory(int numberOfCupsSold)
        {
            plasticCups -= numberOfCupsSold;
            Console.WriteLine("you used {0} cups!", numberOfCupsSold);
            return plasticCups;
        }

        public void GoGroceryShopping()
        {
            Console.WriteLine("You need to purchase some ingedients and supplies for your lemonade stand. Let's go shopping!\n");
            BuyLemons();
            
        }

        public void CheckCupboard()
        {
            Console.WriteLine("Let's see if you have all the ingredients you need.\n");
            Console.WriteLine("You have {0} lemons, {1} cups of sugar, {2} bags of ice, and {3} plastic cups on hand right now.\n", lemons, cupsOfSugar, poundsOfIce, plasticCups);
        }

        public int BuyLemons()
        {
            Console.WriteLine("Large lemons cost $0.79 each. You need three large lemons to make 8 cups of basic lemonade." +
                " How many large lemons do you want to purchase for today?\n");
            string lemonString = Console.ReadLine();
            int newLemons = int.Parse(lemonString);
            lemons = lemons + newLemons;
            return lemons;
        }

        public int BuySugar()
        {
            Console.WriteLine("A 10 pound bag of sugar costs $5.49 and contains 20 cups of sugar. You need one cup of sugar to " +
                "make 8 cups of lemonade. How many bags of sugar will you purchase today?");
            string sugarString = Console.ReadLine();
            bagsOfSugar = int.Parse(sugarString);
            cupsOfSugar = bagsOfSugar * 20;
            return cupsOfSugar;
        }

        public int BuyIce()
        {
            Console.WriteLine("A ten pound bag of ice costs $2.49 and will chill 50 servings of lemonade. How many 10 pound bags of ice will" +
                " you purchase today?");
            string iceString = Console.ReadLine();
            bagsOfIce = int.Parse(iceString);
            poundsOfIce = bagsOfIce/10; //adding a full 10 pounds each time you purchase.
            return poundsOfIce;
        }

        public int BuyPlasticCups()
        {
            Console.WriteLine("Your plastic cups come in packages of 100. How many packges do you want to buy today?");
            string cupString = Console.ReadLine();
            plasticCups = int.Parse(cupString);
            return plasticCups;

        }

        public int SetBasicRecipe()
        {
            Console.WriteLine("How many cups of lemonade can you sell on a day like today?");
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
            //return tenPoundBagOfIce;

        }
    }
}
    
