using System;
using System.Collections.Generic;

class Program
{
    // Метод для генерации двумерного массива заданного размера с вводом значений с клавиатуры
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
                    j--;  // Повтор ввода для того же столбца
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

        int[][] matrix = Generate(n, m);  // Генерация и ввод двумерного массива
        Print(matrix);  // Вывод начальной матрицы

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
            int newColumnsCount = m + withoutNegatives.Count;  // количество столбцов в новой матрице с пустыми

            for (int i = 0; i < n; i++)
            {
                int[] newRow = new int[newColumnsCount];  // новая строка в новой матрице

                int index = 0;  // индекс для заполнения элементов в новой строке

                for (int j = 0; j < m; j++)
                {
                    newRow[index] = matrix[i][j];  // копирование значения из начальной матрицы в новую строку
                    index++;

                    if (withoutNegatives.Contains(j))
                    {
                        newRow[index] = 0;  // добавление пустого столбца с значением 0
                        index++;
                    }
                }

                matrix[i] = newRow;  // замена текущей строки в начальной матрице на новую строку с пустыми столбцами
            }

            Console.WriteLine();
            Print(matrix);  // Вывод измененной матрицы
        }
    }
}
