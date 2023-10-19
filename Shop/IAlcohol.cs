using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    internal interface IAlcohol:IItem
    {
        int Volume {  get; }
        float Strength {  get; }
    }
}
