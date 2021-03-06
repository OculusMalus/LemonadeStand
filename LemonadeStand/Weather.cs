﻿using System;
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
        string sunshine;
        public int numberOfPotentialCustomers;
        public int thirstIndex;
        Random rnd = new Random();

        public Weather()
        {
            CheckForecast();
            CheckForSunshine();
            SetActualHighTemperature();
            CalculateThirstIndex();
        }


        public void PrintForecast()
        {
            CheckForSunshine();
            if (_willTheSunShine == true)
            {
                sunshine = "sunny";
            }
            else sunshine = "cloudy";
            Console.WriteLine("The forecast for today is {0} with a high of {1}F.", sunshine, _forecastHighTemperature, "\n");

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

        int CalculateThirstIndex()
        {
            thirstIndex = _actualHighTemperature - 55;
            if (_willTheSunShine == true)
            {
                thirstIndex += thirstIndex/2;
            }
            return thirstIndex;
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

        public int CalculateNumberOfPotentialCustomers()
        {
            numberOfPotentialCustomers = 50 + (_actualHighTemperature - 60) * 5;
            return numberOfPotentialCustomers;
        }

       
    }

    
}
