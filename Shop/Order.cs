using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Shop
{
    internal class Order:IOrder
    {
        List<IItem> _items;
        public List<IItem> Items {  get { return _items; } }
        public Order()
        {
            _items = new List<IItem>();
        }
        public event NotifyClient OnOrderCreate;
        public void Purchase()
        {
            ToFile();
            OnOrderCreate?.Invoke(this);
            RemoveOrderItems();
        }
        void ToFile()
        {
            using(StreamWriter sw = new StreamWriter("Check.txt", false, System.Text.Encoding.Default))
            {
                foreach(IItem item in Items)
                {
                    sw.WriteLine(item.Show());
                    sw.WriteLine("---------------------");
                }
                sw.WriteLine($"Suma: {Items.Sum(x => x.Price)}");
            }
        }
        void RemoveOrderItems()
        {
            Items.Clear();
        }
    }
}
