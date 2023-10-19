using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    enum SizeLetters
    {
        XS,
        S,
        M,
        L,
        XL
    }
    internal interface IClothes:IItem
    {
        SizeLetters Size { get; }
    }
}
