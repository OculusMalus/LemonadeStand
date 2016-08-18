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
                Console.Clear();
                Console.WriteLine("Selling delicious lemonade to happy people...be patient...");
                customerCount++;
                customers.Add(customer);
                Thread.Sleep(25);
            }
            return customers;
        }
    }
}
