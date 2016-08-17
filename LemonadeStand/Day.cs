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
        List<Customer> customers = new List<Customer>();

        public List<Customer> CreateCustomers(int numberOfPotentialCustomers)
        {
            for (int i = 0; i < numberOfPotentialCustomers; i++)
            {
                Customer customer = new Customer();

                customerCount++;
                customers.Add(customer);
                Thread.Sleep(25);
            }
            return customers;



            // customer._thirstLevel = customer.CalculateThirst(actualTemperature, sunshine);
            // customer._chanceOfPurchase = customer.CalculateChanceOfPurchase(actualTemperature);

            // if (customer._chanceOfPurchase == 100)
            // {
            // numberOfCupsSold++;
            //}



            //}

            //Console.WriteLine("\nYou sold {0} cups of lemonade to {1} potential customers.", numberOfCupsSold, customerCount);
            //decimal dailyDeposit = numberOfCupsSold * cupPrice;
            //Console.WriteLine("Your gross profit is ${0}", dailyDeposit);

        }


    }
}
