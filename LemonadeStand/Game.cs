using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        public int customerCount = 0;
        public int numberOfCupsSold = 0;
        public int lemonadeFervor;
        public int preferredPriceInteger;
        public int priceBoost;
        public int batch;
        Player _player = new Player();
        Inventory _kitchen = new Inventory();

        public void RunGame()
        {
            string name = _player.SetName();
            decimal[] sales = new decimal[7];
            decimal salesGrandTotal = 0;
            decimal salesNet = 0;

            InitializeGame(name);

            for (int i = 0; i < 7; i++)
            {
                sales[i] = TakeTurn(_player);
            }

            Console.WriteLine("");
            Console.WriteLine("Congratulations on building your business!\n");

            for (int i = 0; i < 7; i++)
            {
                Console.WriteLine("Sales for day {0}: ${1}", i+1, sales[i]);
            }
            for (int i = 0; i < 7; i++)
            {
                salesGrandTotal += sales[i];
            }
            salesNet = _player.HowMuchMoneyDoIHave();
            Console.WriteLine("\nYour sales totaled ${0}", salesGrandTotal);
            Console.WriteLine("\nAfter expenses, you pocket ${0}!", salesNet);
        }

        public decimal TakeTurn(Player _player)
        {
            Day day = new Day();
            Weather _today = new Weather();
            int actualHighTemperature = _today.CheckForecast();
            int thirstIndex = _today.thirstIndex;
            bool sunshine = _today._willTheSunShine;
            int numberOfPotentialCustomers = _today.CalculateNumberOfPotentialCustomers();

            Console.Clear();
            _today.PrintForecast();
            _kitchen.SetRecipe();
            GoShopping();
                        
            decimal cupPrice = _player.SetPrice();
            List<Customer> customers = day.CreateCustomers(numberOfPotentialCustomers);

            int listCount = customers.Count;
            numberOfCupsSold = 0;
            foreach (Customer customer in customers)
            {
                lemonadeFervor = customer._lemonadeFervor;
                preferredPriceInteger = customer._preferredPriceInteger;
                CheckForSale(customer, _today, thirstIndex, cupPrice);
            }
            
            Console.Clear();
            Console.WriteLine("The actual high temperature today was {0}F. You could have\n"+
                                "sold {1} cups of lemonade today, based on demand at the price you set.\n" +
                                "", actualHighTemperature,numberOfCupsSold);

            numberOfCupsSold = _kitchen.HowManyCupsDidIReallySell(numberOfCupsSold, batch);
            decimal dailyGross = CalculateDailySales(_player,numberOfCupsSold, cupPrice);
            _kitchen.AdjustInventory(numberOfCupsSold);

            Console.WriteLine("You brought in ${0}!\nPress any key to continue.", dailyGross);
            Console.ReadKey();


            return dailyGross;
        }


        //methods go down here
        public void InitializeGame(string name)
        {
            Console.Clear();
            Console.WriteLine("Hello, {0}! You will start with $25 to purchase supplies\n" +
                               "for your lemonade stand. You will have a chance to check\n" +
                               "your inventory and purchase any additional needed supplies\n" +
                               "each day based on the funds you have earned. Try to accurately\n" +
                               "predict how much lemonade to make based on the weather forecast.\n\n" +
                               "You will make more money if you don't run out! On the other hand,\n" +
                               "you don't waste your hard earned money on ingredients that you\n"+
                               "don't use. You will keep an inventory of ingredients, but will\n"+
                               "make a new batch of lemonade each day.\n", name); 
                               
            Console.WriteLine("Let's start by checking the weather for today.\n", name);
            Console.WriteLine("Press a key to continue\n");
            Console.ReadKey();
        }

        public int CheckForSale(Customer customer, Weather _today, int thirstIndex, decimal cupPrice)
        {
            priceBoost = -((Decimal.ToInt32(cupPrice*100)) - preferredPriceInteger);
            int chanceOfPurchase = lemonadeFervor + thirstIndex + priceBoost;
            if (chanceOfPurchase > 100)
            {
                numberOfCupsSold++;
                return numberOfCupsSold;
            }
            else return numberOfCupsSold;
        }

        public void GoShopping()
        {
            _kitchen.CheckCupboard(_player);
            _kitchen.GoGroceryShopping(_player);
            batch = _kitchen.HowMuchLemonadeCanIMakeToday();
        }

        public decimal CalculateDailySales(Player _player,int numberOfCupsSold, decimal cupPrice)
        {
            decimal dailyGross = numberOfCupsSold * cupPrice;
            _player.StashCashBox(dailyGross);
            return dailyGross;
        }
    }
}
