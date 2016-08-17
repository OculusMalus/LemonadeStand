using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        public decimal dailyProfit = 0;
        public int customerCount = 0;
        public int numberOfCupsSold = 0;
        public int lemonadeFervor;
        public int priceBoost;
        Player _player = new Player();
        Inventory _kitchen = new Inventory();
           
        public void RunGame()
        {

            string name = _player.SetName();
            InitializeGame(name);
            

            for (int i = 0; i < 2; i++)
            {
                TakeTurn();
            }
            
        }

        public void TakeTurn()
        {
            Day day = new Day();
            Weather _today = new Weather();
            int actualHighTemperature = _today.CheckForecast();
            int thirstIndex = _today.thirstIndex;
            bool sunshine = _today._willTheSunShine;
            int numberOfPotentialCustomers = _today.CalculateNumberOfPotentialCustomers();

            Console.Clear();

            _today.PrintForecast();
            GoShopping();
                        
            decimal cupPrice = _player.SetPrice();

            List<Customer> customers = day.CreateCustomers(numberOfPotentialCustomers);

            int listCount = customers.Count;
            foreach(Customer customer in customers)
            {
                lemonadeFervor = customer._lemonadeFervor;
                CheckForSale(thirstIndex, cupPrice);
            }
            Console.WriteLine("cups sold = {0}", numberOfCupsSold);
            _kitchen.AdjustInventory(numberOfCupsSold);
            Console.WriteLine("You made ${0}", numberOfCupsSold * cupPrice, " today!");
            Console.ReadKey();
        }


        //methods go down here
        public void InitializeGame(string name)
        {
            Console.Clear();
            Console.WriteLine("Hello, {0}! You will start with $20 to purchase supplies\n"+
                               "for your lemonade stand. You will have a chance to check\n"+
                               "your inventory and purchase any additional needed supplies\n"+
                               "each day based on the funds you have earned.\n", name);

            Console.WriteLine("Let's start by checking the weather for today.\n", name);
            Console.WriteLine("Press a key to continue\n");
            Console.ReadKey();
        }

        public int CheckForSale(int thirstIndex, decimal cupPrice)
        {
            int _cupPriceInteger = Decimal.ToInt32(cupPrice * 100);
            priceBoost = -(_cupPriceInteger - 150);

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
            _kitchen.CheckCupboard();

            _kitchen.GoGroceryShopping();
        }

        
    }
}
