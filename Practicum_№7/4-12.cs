using System;

class Program
{
    static void Main()
    {
        Console.Write("Введите размерность массива: ");
        int n = int.Parse(Console.ReadLine()); 

        int[,] array = new int[n, n]; // создаем двумерный массив размером n x n

        Console.WriteLine("Введите элементы массива:");

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split(); // считываем строку с элементами массива

            for (int j = 0; j < n; j++)
            {
                array[i, j] = int.Parse(input[j]); // преобразуем и записываем элементы в массив
            }
        }

        int[] result = new int[n]; // массив для хранения номеров последних нечетных элементов

        for (int j = 0; j < n; j++)
        {
            int lastnumber = -1; 

            for (int i = 0; i < n; i++)
            {
                if (array[i, j] % 2 != 0) 
                {
                    lastnumber = i; // обновляем номер последнего нечетного элемента
                }
            }

            result[j] = lastnumber; // записываем номер последнего нечетного элемента в новый массив
        }

        // Выводим результат
        Console.WriteLine("Номера последних нечетных элементов в каждом столбце:");
        for (int j = 0; j < n; j++)
        {
            Console.WriteLine($"Столбец {j + 1}: {result[j]}");
        }
    }
}
