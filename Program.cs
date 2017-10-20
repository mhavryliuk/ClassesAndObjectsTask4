using System;

namespace ClassesAndObjectsTask4
{
    class Program
    {
        static void Main()
        {
            Money purse = new Money(50,15);                        // Номинал купюры, количество купюр
            Console.WriteLine(purse);
            Console.WriteLine(purse.CheckAvailability(251));       // Указываем стоимость ед. товара
            Console.WriteLine(purse.CalculationOfQuantity(251));   // Указываем стоимость ед. товара

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nДемонстрация работы индексатора");
            Console.ResetColor();
            Console.WriteLine(purse[0]);
            Console.WriteLine(purse[1]);
            Console.WriteLine(purse[2]);

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\nДемонстрация перегрузки операций");
            Console.ResetColor();
            Console.WriteLine(++purse);                            // Перегрузка операции ++
            Console.WriteLine(--purse);                            // Перегрузка операции --
            Console.WriteLine(purse+50);                           // Добавление к координатам значения скаляра

            if (!purse)                                             // Перегрузка операции !
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("Количество купюр не равно 0, Вы счачтливчик!");
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Количество купюр равно 0, печалька :(");
                Console.ResetColor();
            }

            Console.ReadKey();
        }
    }
}
