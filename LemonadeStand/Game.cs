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


        Player _player = new Player();
        Kitchen _kitchen = new Kitchen();
        List<Day> days = new List<Day>();
        

        public void RunGame()
        {

            _player.SetName();
           
            for (int i = 0; i < 7; i++)
            {
                TakeTurn();
            }
            
        }

        public void TakeTurn()
        {
            Day day = new Day();
            Weather _today = new Weather();

            int actualHighTemperature = _today.CheckForecast();
            bool sunshine = _today._willTheSunShine;
            decimal cupPrice = _player.SetPrice();
            int numberOfPotentialCustomers = _today.CalculateNumberOfPotentialCustomers();

            _today.PrintForecast();

            //Console.WriteLine("number of potential customers is {0}", numberOfPotentialCustomers);

            day.CreateCustomers(numberOfPotentialCustomers, cupPrice, actualHighTemperature, sunshine);        

           // _player.SetPrice();
            Console.WriteLine("Price is ${0}", _player.cupPrice);

            //customer.CalculateChanceOfPurchase();
            //customer.CalculateThirstLevel();
            //customer._thirstLevel = customer.CalculateThirst();
            //customer._chanceOfPurchase = customer._chanceOfPurchase();

            

            _today.PrintForecast();
            _kitchen.SetBasicRecipe();

            //Customer _customer = new Customer(_today.numberOfPotentialCustomers);

            //for (int i = 0; i < _today.numberOfPotentialCustomers; i++)
            //{
            //    _customer.SetLemonadeFervor();
            //    _customer.CalculateThirst(_today._actualHighTemperature, _today._willTheSunShine);
            //    //_customer.CalculatePricePointPreference();
            //    _customer.CalculateChanceOfPurchase(_today._actualHighTemperature);
            //    if (_customer._chanceOfPurchase == 100)
            //    {
            //        numberOfCupsSold++;
            //    }

                //customerCount++;
                //_customer.Print(); //un-comment to see each instance of a customer and their preferences
                ////Console.ReadKey();

            //}
            //_today.PrintActualWeather();
            //Console.WriteLine("\nYou sold {0} cups of lemonade to {1} potential customers.", numberOfCupsSold, customerCount);
            //dailyProfit = (_player.cupPrice * (numberOfCupsSold));
            //Console.WriteLine("Your gross profit is ${0}", dailyProfit); 
            //Console.WriteLine("\nPress a key to continue\n");
            //Console.ReadKey();


        }
    }
}
