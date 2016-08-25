using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LemonadeStand;
using System.Collections;
using System.Collections.Generic;

namespace LemonadeStandUnitTest
{
    [TestClass]
    public class UnitTest1

    {
        Random rnd = new Random();
        Player _player = new Player();
        Inventory _kitchen = new Inventory();

        [TestMethod]
        public void Validate_SpendCashBox(decimal amount)
        {
            //arrange
            decimal cashBox = 25m;
            amount = 1.67m;
            decimal expectedresult = 23.33m;
            //act
            _player.SpendCashBox(amount);

            //assert
            Assert.AreEqual(cashBox, expectedresult);
        }

        public void Validate_CustomersListSize(int numberOfPotentialCustomers)
        {
            //arrange
            Day day = new Day();
            List<Customer> customers = new List<Customer>();
            numberOfPotentialCustomers = 10;

            //act
            day.CreateCustomers(numberOfPotentialCustomers);

            //assert
            Assert.AreEqual(customers.Count, numberOfPotentialCustomers);
        }

        public void Validate_CustomerListExists(int numberOfPotentialCustomers)
        {
            Day day = new Day();
            List<Customer> customers = new List<Customer>();
            numberOfPotentialCustomers = 10;

            day.CreateCustomers(numberOfPotentialCustomers);

            for (int i = 0; i < numberOfPotentialCustomers; i++)
            {
                Assert.IsNotNull(customers[i]);
            }
        }



        public void Validate_ThirstIndexWithinRange(int numberOfPotentialCustomers)
        {
            Day day = new Day();
            List<Customer> customers = new List<Customer>();
            numberOfPotentialCustomers = 10;

            day.CreateCustomers(numberOfPotentialCustomers);

            foreach (Customer customer in customers)
            {
                int lemonadeFervor = customer._lemonadeFervor;
                Assert.IsTrue(lemonadeFervor < 101);
            }
        }

        public void Validate_CustomerCount(int numberOfPotentialCustomers)
        {
            Day day = new Day();
            List<Customer> customers = new List<Customer>();
            numberOfPotentialCustomers = 10;

            day.CreateCustomers(numberOfPotentialCustomers);

            Assert.AreEqual(day.customerCount, numberOfPotentialCustomers);
        }

        public void Validate_CustomerListReturnType(int numberOfPotentialCustomers)
        {
            Day day = new Day();
            List<Customer> customers = new List<Customer>();
            numberOfPotentialCustomers = 10;

            day.CreateCustomers(numberOfPotentialCustomers);

            foreach (Customer customer in customers)
            {
                int lemonadeFervor = customer._lemonadeFervor;
                Assert.IsInstanceOfType(customers, typeof(Customer));
            }
        }

        public void Validate_BatchSizeLimitation()
        {
            _kitchen.lemons = 24;
            _kitchen.lemonsPerRecipe = 4;
            _kitchen.cupsOfSugar = 32;
            _kitchen.sugarDividerPerRecipe = 8;
            _kitchen.poundsOfIce = 71;
            _kitchen.plasticCups = 43;

            int result = _kitchen.HowMuchLemonadeCanIMakeToday();
            Assert.AreEqual(result, 43);
        }

        public void Validate_BatchReturn()
        {
            _kitchen.lemons = 24;
            _kitchen.lemonsPerRecipe = 4;
            _kitchen.cupsOfSugar = 32;
            _kitchen.sugarDividerPerRecipe = 8;
            _kitchen.poundsOfIce = 71;
            _kitchen.plasticCups = 0;
            
            int result = _kitchen.HowMuchLemonadeCanIMakeToday();
            Assert.IsNotNull(result);
        }

        public void Validate_BatchReturnType()
        {
            _kitchen.lemons = 24;
            _kitchen.lemonsPerRecipe = 4;
            _kitchen.cupsOfSugar = 32;
            _kitchen.sugarDividerPerRecipe = 8;
            _kitchen.poundsOfIce = 71;
            _kitchen.plasticCups = 0;

            int result = _kitchen.HowMuchLemonadeCanIMakeToday();
            Assert.IsInstanceOfType(result, typeof(int));
        }
    }


}
