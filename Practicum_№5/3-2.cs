using System;

class Program
{
    static double[] cache; // кэш для хранения уже вычисленных значений

    static double GetN(int n)
    {
        if (n== 1)
        {
            return 5;
        }

        if (cache[n] != 0) // если значение уже было вычислено, возвращаем его из кэша
        {
            return cache[n];
        }

        double previous = GetN(n - 1);
        double current = previous / (Math.Pow(n, 2) + n + 1);
        
        cache[n] = current; // сохраняем вычисленное значение в кэше
        
        return current;
    }

    static void Main() 
    {
        Console.Write("Введите число n: ");
        int n = int.Parse(Console.ReadLine());
        
        cache = new double[n + 1]; // инициализируем кэш с размером n + 1
        
        double nthTerm = GetN(n);
        
        Console.WriteLine($"Значение {n}-го члена последовательности: {nthTerm}");
    }
}
