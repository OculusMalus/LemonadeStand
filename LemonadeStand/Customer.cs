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
        public int _priceBoost;
        public int customerCount = 0;
        Random rnd = new Random();

            
        public Customer()                           //constructor sets fervor upon instantiation
        { 
            SetLemonadeFervor();
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
            int chance = _lemonadeFervor + _thirstLevel + (_actualTemperature-80) + _priceBoost ;
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

        public int CalculatePricePointPreference(decimal cupPrice)
        {
            int _cupPriceInteger = Decimal.ToInt32(cupPrice * 100);
            _priceBoost = -(_cupPriceInteger - 100);
            return _priceBoost;
        }

    }
}
