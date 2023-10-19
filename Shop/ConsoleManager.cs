using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shop
{
    delegate void Manager(IItem item,IOrder order);
    internal class ConsoleManager
    {
        public static void StartProgram()
        {
            IOrder order = new Order();
            MainMenu(order);
        }
        static void MainMenu(IOrder order)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            while (true)
            {
                Console.WriteLine("0. Pokazaty vsi tovary\n" +
                                  "1. Pokazaty koshyk\n" +
                                  new string(order.Items.Count>0?"2.Kupyty koshyk\n":"") +
                                  "3. Pidpysatys` na rozsylku\n" +
                                  "4.Exit");
                int choose = ChooseOption(4);
                switch (choose)
                {
                    case 0:
                        do
                        {
                            Console.Clear();
                            ShowItems(ItemMocks.GetItems());
                        }
                        while (ManageShown(ChooseOption(ItemMocks.GetItems().Count), order,ManageSelectedAll,ItemMocks.GetItems()) != 0);
                        break;
                    case 1:
                        do
                        {
                            Console.Clear();
                            ShowItems(order.Items);
                        }
                        while (ManageShown(ChooseOption(order.Items.Count), order, ManageSelectedOrder, order.Items) != 0);
                        break;
                    case 2:
                        if (order.Items.Count > 0)
                        {
                            Summary(order);
                            order.Purchase();
                        }
                        break;
                    case 3:
                        order.OnOrderCreate += Program.OuterMethod;
                        break;
                    case 4:
                        return;
                }
                Console.Clear();
            }
        }
        static int ChooseOption(int count) 
        {
            while (true)
            {
                if (uint.TryParse(Console.ReadKey(intercept: true).KeyChar.ToString(), out uint choose) && choose <= count)
                {
                    return (int)choose;
                }
            }
        }
        static void ShowItems(List<IItem> items)
        {
            Console.WriteLine("0. Nazad");
            foreach (IItem item in items)
            {
                Console.Write($"{items.IndexOf(item)+1}.");
                Console.WriteLine(item.Show());
            }
        }
        static int ManageShown(int select,IOrder order,Manager manageSelected,List<IItem> items)
        {
            if(select == 0)
            {
                return 0;
            }
            IItem item = items[select-1];
            manageSelected(item,order);
            return 1;
        }
        static void ManageSelectedAll(IItem item,IOrder order)
        {
            Console.Clear();
            int select = 1;
            while (select != 0)
            {
                Console.WriteLine(item.Show());
                Console.WriteLine("0. Nazad.\n" +
                                  "1. Dodaty v koshyk.");
                select = ChooseOption(1);
                if(select == 1)
                {
                    order.Items.Add(item);
                    Console.WriteLine("================\nDodano v koshyk. Natysnit` klavishu...");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void ManageSelectedOrder(IItem item, IOrder order)
        {
            Console.Clear();
            int select = 1;
            while (select != 0)
            {
                Console.WriteLine(item.Show());
                Console.WriteLine("0. Nazad.\n" +
                                  "1. Zabraty z koshyka.");
                select = ChooseOption(1);
                if (select == 1)
                {
                    order.Items.Remove(item);
                    Console.WriteLine("================\nVydaleno z koshyka. Natysnit` klavishu...");
                    Console.ReadKey();
                    break;
                }
            }
        }
        static void Summary(IOrder order)
        {
            Console.Clear();
            Console.WriteLine("Vashe zamovlenya:");
            ShowItems(order.Items);
            Console.WriteLine("----------------------------");
            Console.WriteLine($"Suma: {order.Items.Sum(x=>x.Price)}");
            Console.WriteLine("----------------------------\n" +
                              "Dodano check u Check.txt!!!");
            Console.ReadKey();
        }
    }
}
