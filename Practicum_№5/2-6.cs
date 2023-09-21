using System;

class Program
{
    static int CountZero(int number)
    {
        int count = 0;
        while (number != 0)
        {
            if (number % 10 == 0)
            {
                count++;
            }
            number /= 10;
        }
        return count;
    }
    
    static void Main()
    {
        Console.Write("Введите число a: ");
        int a = int.Parse(Console.ReadLine());
        
        Console.Write("Введите число b: ");
        int b = int.Parse(Console.ReadLine());

        Console.WriteLine("a) Количество значащих нулей для каждого числа на отрезке [{0}, {1}]:", a, b);
        for (int i = a; i <= b; i++)
        {
            Console.WriteLine("Число {0}: {1}", i, CountZero(i));
        }
        Console.WriteLine();

        Console.WriteLine("b) Числа на отрезке [{0}, {1}] с нечетным количеством значащих нулей:", a, b);
        for (int i = a; i <= b; i++)
        {
            if (CountZero(i) % 2 != 0)
            {
                Console.WriteLine(i);
            }
        }
        Console.WriteLine();

        Console.WriteLine("c) Числа на отрезке [{0}, {1}] с максимальным количеством значащих нулей:", a, b);
        int maxZero = 0;
        for (int i = a; i <= b; i++)
        {
            int zeroes = CountZero(i);
            if (zeroes > maxZero)
            {
                maxZero = zeroes;
            }
        }
        for (int i = a; i <= b; i++)
        {
            if (CountZero(i) == maxZero)
            {
                Console.WriteLine(i);
            }
        }
        Console.WriteLine();

        Console.Write("Введите число A: ");
        int A = int.Parse(Console.ReadLine());

        Console.Write("Введите число B: ");
        int B = int.Parse(Console.ReadLine());

        int closestNumber = int.MaxValue;
        int minDistance = int.MaxValue;
        for (int i = A + 1; i <= int.MaxValue; i++)
        {
            int zeroes = CountZero(i);
            if (zeroes == B)
            {
                closestNumber = i;
                break;
            }
            else if (zeroes > B && zeroes - B < minDistance)
            {
                closestNumber = i;
                minDistance = zeroes - B;
            }
        }
        if (closestNumber == int.MaxValue)
        {
            Console.WriteLine("На отрезке от {0} до бесконечности нет чисел с количеством значащих нулей равным {1}.", A, B);
        }
        else
        {
            Console.WriteLine("Ближайшее число к {0} с количеством значащих нулей равным {1}: {2}", A, B, closestNumber);
        }
    }
}
