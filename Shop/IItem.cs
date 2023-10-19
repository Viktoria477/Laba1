using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    internal interface IItem
    {
        string Name { get; }
        decimal Price { get; }
        string Show();
    }
}
