using System;

class Program
{
    static void PrintNumbersDescending(int num)
    {
        if (num <= 0)
            return;
        
        Console.Write(num + " ");
        PrintNumbersDescending(num - 1);
    }
    static void Main(string[] args)
    {
        Console.Write("Введите натуральное число N (N >= 1000): ");
        int n = int.Parse(Console.ReadLine());

        if (n >= 1000)
        {
            PrintNumbersDescending(n);
        }
        else
        {
            Console.WriteLine("Введенное число меньше 1000");
        }
    }
}
