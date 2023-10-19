using System;
using System.Collections.Generic;
using System.Text;

namespace Shop
{
    delegate void NotifyClient(IOrder order);
    internal interface IOrder
    {
        List<IItem> Items { get; }
        void Purchase();
        event NotifyClient OnOrderCreate;
    }
}
