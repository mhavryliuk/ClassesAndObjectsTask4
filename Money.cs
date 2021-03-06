﻿/*
Классы и Объекты.
Задание 4. Создать класс Money, содержащий следующие члены класса:
1. Поля:
· int first; //номинал купюры
· int second; //количество купюр
2. Конструктор, позволяющий создать экземпляр класса с заданными значениям полей.
3. Методы, позволяющие:
· вывести номинал и количество купюр;
· определить, хватит ли денежных средств на покупку товара на сумму N гривен.
· определить, сколько штук товара стоимости n гривен можно купить на имеющиеся денежные средства.
4. Свойство:
· позволяющее получить-установить значение полей (доступное для чтения и записи);
· позволяющее рассчитать сумму денег (доступное только для чтения).
5. Индексатор, позволяющий по индексу 0 обращаться к полю first, по индексу 1 – к полю second, при других значениях индекса выдается сообщение об ошибке.
6. Перегрузку:
· операции ++ (--): одновременно увеличивает(уменьшает) значение полей first и second;
· операции !: возвращает значение true, если поле second не нулевое, иначе false;
· операции бинарный +: добавляет к значению поля second значение скаляра.

Продемонстрировать работу класса.
*/

namespace ClassesAndObjectsTask4
{
    class Money
    {
        // Поля:
        int nominal;         // Номинал купюры
        int quantityNotes;   // Количество купюр
        int totalCash = 0;

        // Конструктор, позволяющий создать экземпляр класса с заданными значениям полей.
        public Money()
        {
            nominal = 0;
            quantityNotes = 0;
        }

        public Money(int nominal, int quantityNotes)
        {
            this.nominal = nominal;
            this.quantityNotes = quantityNotes;
        }

        // Метод для вывода номинала и количества купюр;
        public override string ToString() => $"У Вас в кармане {quantityNotes} куп. номиналом {nominal} грн.";

        // Метод, определяющий, хватит ли денежных средств на покупку товара на сумму N гривен.
        public string CheckAvailability(double costOfGoods)
        {
            totalCash = nominal * quantityNotes;   // Общая сумма наличных
            if (costOfGoods < totalCash)
            {
                return $"У Вас достаточно наличных ({totalCash} грн.) для покупки товара стоимость {costOfGoods} грн.";
            }
            else
            {
                return $"К сожалению, для покупки товара стоимостью {costOfGoods} Вам не хватает {costOfGoods - totalCash} грн. " +
                    $"\nПопробуйте одолжить их у Вашего коллеги.";
            }
        }

        // Метод, определяющий, сколько штук товара стоимости n гривен можно купить на имеющиеся денежные средства.
        public string CalculationOfQuantity(double costOfGoods)
        {
            int quantityGoods = (int)(totalCash / costOfGoods);
            return $"На имеющиеся {totalCash} грн. можно купить {quantityGoods} ед. товара стоимостью {costOfGoods} грн.";
        }

        // Свойство, позволяющее получить-установить значение полей (доступное для чтения и записи).
        public int Nominal
        {
            get => nominal;
            set => nominal = value;
        }

        public int QuantityNotes
        {
            get => quantityNotes;
            set => quantityNotes = value;
        }

        // Свойство, позволяющее рассчитать сумму денег (доступное только для чтения).
        public int TotalCash
        {
            get => totalCash;
        }

        // Индексатор, позволяющий по индексу 0 обращаться к полю first, по индексу 1 – к полю second, 
        // при других значениях индекса выдается сообщение об ошибке.
        public string this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0:
                        return $"Индексу {index} соответствует купюра номиналом {nominal} грн.";
                    case 1:
                        return $"Индексу {index} соответствуют купюры в количестве {quantityNotes} шт.";
                    default:
                        return $"Внимание, индекс {index} является недействительным.";
                }
            }
        }

        // Перегрузка операции ++: одновременно увеличивает значение полей first и second;
        public static Money operator ++(Money m)
        {
            return new Money(++m.nominal, ++m.quantityNotes);
        }

        // Перегрузка операции --: одновременно уменьшает значение полей first и second;
        public static Money operator --(Money m) => new Money(--m.nominal, --m.quantityNotes);

        // Перегрузка операции !: возвращает значение true, если поле second не нулевое, иначе false;
        public static bool operator !(Money qn)
        {
            if (qn.quantityNotes != 0)
            {
                return true;
            }
            return false;
        }

        // Перегрузка операции бинарный +: добавляет к значению поля second значение скаляра.
        public static Money operator +(Money m, int scalar) => new Money(m.nominal, m.quantityNotes + scalar);
    }
}
