using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Kitchen
    {
        int lemons;
        decimal lemonJuice;
        int bagsOfSugar;
        decimal cupOfSugar;
        int tenPoundBagOfIce;
        decimal cupOfIce;
        int willMakeThisManyCups;

        public void GoGroceryShopping()
        {
            Console.WriteLine("You need to purchase some ingedients and supplies for your lemonade stand. Let's go shopping!\n");

        }

        public int BuyLemons()
        {
            Console.WriteLine("Large lemons cost $0.79 each. You need three large lemons to make 8 cups of basic lemonade." +
                " How many large lemons do you want to purchase for today?\n");
            string lemonString = Console.ReadLine();
            lemons = int.Parse(lemonString);
            return lemons;
        }

        public int BuySugar()
        {
            Console.WriteLine("A 10 pound bag of sugar costs $5.49 and contains 20 cups of sugar. You need one cup of sugar to " +
                "make 8 cups of lemonade. How many bags of sugar will you purchase today?");
            string sugarString = Console.ReadLine();
            bagsOfSugar = int.Parse(sugarString);
            return bagsOfSugar;
        }

        public int BuyIce()
        {
            Console.WriteLine("A ten pound bag of ice costs $2.49 and will chill 50 servings of lemonade. How many 10 pound bags of ice will" +
                " you purchase today?");
            string iceString = Console.ReadLine();
            tenPoundBagOfIce = int.Parse(iceString);
            return tenPoundBagOfIce;
        }

        public int SetBasicRecipe()
        {
            Console.WriteLine("How many cups of lemonade can you sell on a day like today?");
            string cupString = Console.ReadLine();
            willMakeThisManyCups = int.Parse(cupString);

            tenPoundBagOfIce = (int)Math.Ceiling((double)(willMakeThisManyCups / 50));
            bagsOfSugar = (int)Math.Ceiling((double)willMakeThisManyCups / 160);
            lemons = (int)Math.Ceiling((double)willMakeThisManyCups *3 / 8);

            Console.WriteLine("Let's buy {0} bags of ice, {1} bags of sugar, and {2} lemons. Thankfully, water is still " +
                "free!", tenPoundBagOfIce, bagsOfSugar, lemons);
            decimal _investment = (decimal)Math.Round(tenPoundBagOfIce * 2.49 + bagsOfSugar * 5.49 + lemons * 0.79);
            Console.WriteLine("You spent ${0} on ingredients",_investment);
            return lemons;
            //return tenPoundBagOfIce;
                
        }

        
    }
}
