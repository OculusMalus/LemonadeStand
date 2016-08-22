using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Customer 
    {
        public int _lemonadeFervor;
        public int _thirstLevel;
        public int _preferredPriceInteger;
        public int customerCount = 0;
        Random rnd = new Random();

            
        public Customer()                           
        {
            SetLemonadeFervor();
            SetPreferredPrice();
        }

        public void PrintCustomer()
        {
            Console.WriteLine("customer\t fervor {0}\t preferred price{1}\t" ,_lemonadeFervor, _preferredPriceInteger);
        }

        public int SetLemonadeFervor()
        {
            _lemonadeFervor = rnd.Next(1, 101);
            return _lemonadeFervor;
        }

        public int SetPreferredPrice()
        {
            _preferredPriceInteger = rnd.Next(100, 151);
            return _preferredPriceInteger;
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
    }
}
