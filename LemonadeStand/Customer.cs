using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer
    {
        //member variables
        public int _lemonadeFervor;
        public int _thirstLevel;
        public int _chanceOfPurchase;
        public int customerCount = 0;
        Random rnd = new Random();

        //public int _actualTemperature = 80; //set this variable in this location for testing purposes only
                                            //remove this vaiable and put it in the weather class when it's ready to go

        //need a constructor?
       
        public Customer ()
        {
            customerCount++;
        }
        public void Print()
        {
            Console.WriteLine("Lemonade Fervor is {0}", _lemonadeFervor,"\n");
            Console.WriteLine("Thirst Level is {0}", _thirstLevel,"\n");
            Console.WriteLine("Chance of Purchase is {0},", _chanceOfPurchase, "\n");

        }

        public int SetLemonadeFervor()
        {
            _lemonadeFervor = rnd.Next(1, 101);
            return _lemonadeFervor;
        }

        public int CalculateThirst(int _actualTemperature, bool sunshine)
        {
            _thirstLevel = _actualTemperature - 55;
            if (sunshine == true)
            {
                _thirstLevel = _thirstLevel + _thirstLevel;
            }
            return _thirstLevel;
        }

        public int CalculateChanceOfPurchase(int _actualTemperature)
        {
            int chance = _lemonadeFervor + _thirstLevel + (_actualTemperature-80);
            if (chance > 100)
            {
                _chanceOfPurchase = 100;
            }
            else
            {
                _chanceOfPurchase = chance;
            }
            return _chanceOfPurchase;
        }
    }
}
