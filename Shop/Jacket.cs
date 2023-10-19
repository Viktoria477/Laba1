using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    internal class Jacket:IClothes
    {
        string _name;
        decimal _price;
        SizeLetters _size;
        public string Name {  get { return _name; } }
        public decimal Price { get { return _price; } }
        public SizeLetters Size { get { return _size; } }
        public Jacket(string name, decimal price, SizeLetters size)
        {
            _name = name;
            _price = price;
            _size = size;
        }
        public string Show()
        {
            return $"Kurtka {_name} - {_price}₴\nRozmir: {_size}";
        }
    }
}
