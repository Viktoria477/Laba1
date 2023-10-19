using System;

namespace Shop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleManager.StartProgram();
        }
        public static void OuterMethod(IOrder order)
        {
            Console.WriteLine($"Email sent to [user email]!");
            //Відправка списку товарів з order на пошту
            Console.ReadKey();
        }
    }
}
