using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    internal class Beer:IAlcohol
    {
        string _name;
        decimal _price;
        int _volume;
        float _strength;


        public string Name { get { return _name; } }
        public decimal Price { get { return _price; } }
        public int Volume { get { return _volume; } }
        public float Strength { get { return _strength; } }
        public Beer(string name, decimal price, int volume, float strength)
        {
            _name = name;
            _price = price;
            _volume = volume;
            _strength = strength;
        }

        public string Show()
        {
            return $"Pyvo {_name} - {_price}₴\nMicnist`: {_strength}%\nOb`yem: {_volume}ml";
        }
    }
}
