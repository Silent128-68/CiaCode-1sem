using System;
using System.Collections.Generic;

class Program
{
    // Метод для генерации двумерного массива
    static int[][] Generate(int n, int m)
    {
        int[][] arr = new int[n][];

        for (int i = 0; i < n; i++)
        {
            arr[i] = new int[m];
            for (int j = 0; j < m; j++)
            {
                Console.Write($"arr[{i}][{j}]: ");
                // Ввод значения с клавиатуры, обработка ошибок
                if (int.TryParse(Console.ReadLine(), out int value))
                {
                    arr[i][j] = value;
                }
                else
                {
                    Console.WriteLine("Введите целое число.");
                    j--;  
                }
            }
        }

        return arr;
    }

    // Метод для вывода двумерного массива в консоль
    static void Print(int[][] arr)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            for (int j = 0; j < arr[i].Length; j++)
            {
                Console.Write(arr[i][j] + "\t");
            }
            Console.WriteLine();
        }
    }

    // Метод для проверки, есть ли отрицательные элементы в столбце
    static bool HasNegatives(int[][] arr, int column)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i][column] < 0)
            {
                return true;
            }
        }
        return false;
    }

    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("m = ");
        int m = int.Parse(Console.ReadLine());

        int[][] matrix = Generate(n, m);
        Print(matrix);

        List<int> withoutNegatives = new List<int>();
        for (int i = 0; i < m; i++)
            if (!HasNegatives(matrix, i))
                withoutNegatives.Add(i);

        if (withoutNegatives.Count == 0)
        {
            Console.WriteLine("Нет столбцов без отрицательных элементов");
        }
        else
        {
            // Обработка строк и вставка пустого столбца после столбца без отрицательных элементов с использованием сдвига
            for (int i = 0; i < n; i++)
            {
                // Создание новой строки в новой матрице
                int[] newRow = new int[m + withoutNegatives.Count];
                int index = 0;  

                // Копирование значений из начальной матрицы в новую строку с учетом сдвига
                for (int j = 0; j < m; j++)
                {
                    newRow[index++] = matrix[i][j];

                    // Вставка пустого столбца с значением 0 после столбца без отрицательных элементов
                    if (withoutNegatives.Contains(j))
                    {
                        newRow[index++] = 0;
                    }
                }
                matrix[i] = newRow;
            }
            Console.WriteLine();
            Print(matrix);
        }
    }
}
