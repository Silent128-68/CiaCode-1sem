using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размерность массива: ");
        int n;
        
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
        {
            Console.WriteLine("Пожалуйста, введите положительное целое число.");
        }

        int[,] array = new int[n, n];

        Console.WriteLine("Введите элементы массива:");

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();

            for (int j = 0; j < n; j++)
            {
                array[i, j] = int.Parse(input[j]);
            }
        }

        int[] result = new int[n];

        for (int j = 0; j < n; j++)
        {
            int lastnumber = -1;

            for (int i = n - 1; i >= 0; i--)
            {
                if (array[i, j] % 2 != 0)
                {
                    lastnumber = i;
                    break; // прерываем цикл после нахождения первого нечетного элемента
                }
            }

            result[j] = lastnumber;
        }

        Console.WriteLine("Номера последних нечетных элементов в каждом столбце:");

        for (int j = 0; j < n; j++)
        {
            Console.WriteLine($"Столбец {j + 1}: {result[j]}");
        }
    }
}
