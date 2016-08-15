using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Game
    {
        Player _player = new Player();
        Weather _today = new Weather();
        public int customerCount = 0;
        public int numberOfCupsSold = 0;

        public void RunGame()
        {
            _player.SetName();
            _player.Print();

            Console.WriteLine("Press a key to continue\n");
            Console.ReadKey();
                        
            _today.CheckForecast();
            _today.CalculateNumberOfPotentialCustomers();

            Console.WriteLine("\nYou have {0} potential customers today", _today.numberOfPotentialCustomers);
            _today.PrintForecast();

            Console.WriteLine("How many cups of lemonade can you sell on a day like today?");
            //set up recipe, buy supplies, make batch

            //for (int i=0; i < 7; i++) **Seven days**
            TakeTurn();

            Console.ReadKey();
            
        }

        public void TakeTurn()
        {
            Customer _customer = new Customer();
            for (int i = 0; i < _today.numberOfPotentialCustomers; i++)
            {
                _customer.SetLemonadeFervor();
                _customer.CalculateThirst(_today._actualHighTemperature, _today._willTheSunShine);
                _customer.CalculateChanceOfPurchase(_today._actualHighTemperature);
                if (_customer._chanceOfPurchase == 100)
                {
                    numberOfCupsSold++;
                }

                customerCount++;
                //_customer.Print(); //un-comment to see each instance of a customer and their preferences
                //Console.ReadKey();

            }
            _today.PrintActualWeather();
            Console.WriteLine("\nYou sold {0} cups of lemonade to {1} potential customers.", numberOfCupsSold, customerCount);
            Console.WriteLine("\nPress a key to continue\n");
            Console.ReadKey();


        }
    }
}
