using System;

class Program
{
    static void Main()
    {
        // первое задание
        Console.WriteLine("сравнение циклов while и dowhile");
        int num = 0;
        while (num < 3)
        {
            Console.WriteLine("while: " + num);
            num++;
        }
        do
        {
            Console.WriteLine("dowhile: " + num);
            num++;
        } while (num < 3);
        Console.WriteLine("while проверяет условие до тела, а dowhile после тела");
        // второе задание
        Console.WriteLine("введите число");
        int i = int.Parse(Console.ReadLine());
        int value = 1;
        while (value < i)
        {
            Console.WriteLine(value);
            value *= 2;
        }
        // третье задание
        Console.WriteLine("введите сколько чисел фибоначчи вывести");
        int n = int.Parse(Console.ReadLine());
        int a = 0, b = 1, c = 0, k = 0;
        while (k < n)
        {
            Console.Write(a + " ");
            c = a + b;
            a = b;
            b = c;
            k++;
        }
    }
}