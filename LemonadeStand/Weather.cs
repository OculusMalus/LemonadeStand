using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Weather
    {
        public int _forecastHighTemperature;
        public int _actualHighTemperature;
        public bool _willTheSunShine;
        string _sunshine;
        Random rnd = new Random();

        public void PrintForecast()
        {
            if (_willTheSunShine == true)
            {
                _sunshine = "sunshine";
            }
            else _sunshine = "clouds";
            Console.WriteLine("The forecast for today is {0} with a high of {1}F.", _sunshine, _forecastHighTemperature, "\n");

        }

        public void PrintActualWeather()
        {
            Console.WriteLine("The actual high temperature was {0}", _actualHighTemperature, "\n");
        }

        public int CheckForecast()
        {

            _forecastHighTemperature = rnd.Next(69, 111);
            int _fiftyPercentOfTheTime = rnd.Next(0, 2);
            if (_fiftyPercentOfTheTime == 0)
            {
                SetActualHighTemperature();
                return _actualHighTemperature;
            }
            else
            {
                _actualHighTemperature = _forecastHighTemperature;
                return _actualHighTemperature;
            }
            
        

        }

        int SetActualHighTemperature()
        {
            int _fiftyPercentOfTheTime = rnd.Next(0, 2);
            if (_fiftyPercentOfTheTime == 0)
            {
                _actualHighTemperature = _forecastHighTemperature + rnd.Next(1, 6);
            }
            else _actualHighTemperature = _forecastHighTemperature - rnd.Next(1, 6);
            return _actualHighTemperature;        
        }

        public bool CheckForSunshine()
        {
            int _fiftyPercentOfTheTime = rnd.Next(0, 2);
            if (_fiftyPercentOfTheTime == 0)
            {
                _willTheSunShine = true;
            }
            else
            {
                _willTheSunShine = false;
            }
            return _willTheSunShine;
        }


    }

    
}
