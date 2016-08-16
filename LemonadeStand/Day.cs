using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        int customerCount = 0;
        int numberOfCupsSold = 0;
        int _priceBoost;
        List<Customer> customers = new List<Customer>();

        public List<Customer> CreateCustomers(int numberOfPotentialCustomers, decimal cupPrice, int actualTemperature, bool sunshine)
        {

            for (int i = 0; i < numberOfPotentialCustomers; i++)
            {
                Customer customer = new Customer();
                customer._lemonadeFervor = customer.SetLemonadeFervor();
                _priceBoost = customer.CalculatePricePointPreference(cupPrice);
                customer._thirstLevel = customer.CalculateThirst(actualTemperature, sunshine);
                customer._chanceOfPurchase = customer.CalculateChanceOfPurchase(actualTemperature);
                if (customer._chanceOfPurchase == 100)
                {
                    numberOfCupsSold++;
                }

                customerCount++;
                //customer.Print();
                Thread.Sleep(5);
                customers.Add(customer);



                //_today.PrintActualWeather();
                //Console.WriteLine("\nYou sold {0} cups of lemonade to {1} potential customers.", numberOfCupsSold, customerCount);
                //dailyProfit = (_player.cupPrice * (numberOfCupsSold));
                //Console.WriteLine("Your gross profit is ${0}", dailyProfit);
                //Console.WriteLine("\nPress a key to continue\n");
                Console.ReadKey();
            }
            return customers;
        }
    }
}
