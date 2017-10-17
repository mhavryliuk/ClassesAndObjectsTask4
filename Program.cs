using System;

namespace ClassesAndObjectsTask4
{
    class Program
    {
        static void Main()
        {
            Money purse = new Money(50,10);
            Console.WriteLine(purse);
            Console.WriteLine(purse.CheckAvailability(251));       // Указываем стоимость ед. товара
            Console.WriteLine(purse.CalculationOfQuantity(251));   // Указываем стоимость ед. товара


            Console.ReadKey();
        }
    }
}
