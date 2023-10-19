using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    internal class WashingMachine:IHomeAppliance
    {
        string _name;
        decimal _price;
        private float _height;
        float _lenght;
        float _width;

        public string Name {  get { return _name; } }
        public decimal Price { get { return _price; } }
        public float[] Dimensions
        {
            get
            {
                return new float[]
                {
                    _height,
                    _lenght,
                    _width
                };
            }
        }
        public WashingMachine(string name, decimal price, float height, float lenght, float width)
        {
            _name = name;
            _price = price;
            _height = height;
            _lenght = lenght;
            _width = width;
        }

        public string Show()
        {
            return $"Pralka {_name} - {_price}₴\nGabaryty: {Dimensions[0]}cm*{Dimensions[1]}cm*{Dimensions[2]}cm";
        }
    }
}
