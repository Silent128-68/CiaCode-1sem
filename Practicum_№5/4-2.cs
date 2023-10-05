using System;

class Program
{
    static void PrintNumbers(int num)
    {
        if (num <= 0)
            return;
        
        Console.Write(num + " ");
        PrintNumbers(num - 1);
    }
    static void Main(string[] args)
    {
        Console.Write("Введите натуральное число N (N >= 1000): ");
        int n = int.Parse(Console.ReadLine());

        if (n >= 1000)
        {
            PrintNumbers(n);
        }
        else
        {
            Console.WriteLine("Введенное число меньше 1000");
        }
    }
}
