// Подключение необходимых пространств имен
using System;
using System.Collections.Generic;

class Program
{
    // Метод для генерации двумерного массива случайных чисел
    static int[][] Generate(int n, int m, int min, int max)
    {
        // Создание объекта Random для генерации случайных чисел
        Random random = new Random();
        // Создание двумерного массива arr размером n x m
        int[][] arr = new int[n][];

        // Заполнение двумерного массива случайными числами
        for (int i = 0; i < n; i++)
        {
            // Создание одномерного массива размером m
            arr[i] = new int[m];
            // Заполнение одномерного массива случайными числами
            for (int j = 0; j < m; j++)
                arr[i][j] = random.Next(min, max + 1);
        }

        // Возврат сгенерированного двумерного массива
        return arr;
    }

    // Метод для печати двумерного массива на консоль
    static void Print(int[][] arr)
    {
        // Перебор строк двумерного массива
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            // Получение количества столбцов в текущей строке
            int cols = arr[i].Length;
            // Перебор столбцов текущей строки
            for (int j = 0; j < cols; j++)
                // Вывод элемента массива на консоль с табуляцией
                Console.Write(arr[i][j] + "\t");

            // Переход на новую строку
            Console.WriteLine();
        }
    }

    // Метод для проверки наличия отрицательных элементов в столбце двумерного массива
    static bool Negative(int[][] arr, int column)
    {
        // Перебор строк двумерного массива
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            // Если текущий элемент в столбце меньше нуля, возвращается значение true
            if (arr[i][column] < 0)
                return true;
        }
        // Если отрицательных элементов не найдено, возвращается значение false
        return false;
    }

    static void Main()
    {
        // Ввод значений переменных n, m, min и max с консоли
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("m = ");
        int m = int.Parse(Console.ReadLine());
        Console.Write("min = ");
        int min = int.Parse(Console.ReadLine());
        Console.Write("max = ");
        int max = int.Parse(Console.ReadLine());

        // Генерация двумерного массива matrix с помощью метода Generate
        int[][] matrix = Generate(n, m, min, max);
        // Вывод сгенерированного массива на консоль с помощью метода Print
        Print(matrix);

        // Создание списка WithoutNegatives для хранения номеров столбцов без отрицательных элементов
        List<int> WithoutNegatives = new List<int>();
        // Перебор столбцов двумерного массива
        for (int i = 0; i < m; i++)
        {
            // Переменная foundNegative для проверки наличия отрицательных элементов в текущем столбце
            bool foundNegative = false;
            // Перебор строк двумерного массива
            for (int j = 0; j < n; j++)
            {
                // Если текущий элемент в столбце меньше нуля, foundNegative присваивается значение true и происходит выход из цикла
                if (matrix[j][i] < 0)
                {
                    foundNegative = true;
                    break;
                }
            }
            // Если отрицательных элементов в текущем столбце не найдено, его номер добавляется в список WithoutNegatives
            if (!foundNegative)
                WithoutNegatives.Add(i);
        }

        // Если список WithoutNegatives пуст, выводится сообщение о том, что нет столбцов без отрицательных элементов
        if (WithoutNegatives.Count == 0)
            Console.WriteLine("Нет столбцов без отрицательных элементов");
        else
        {
            // Вычисление нового количества столбцов newColumnsCount после добавления столбцов без отрицательных элементов
            int newColumnsCount = m + WithoutNegatives.Count;
            // Перебор строк двумерного массива
            for (int i = 0; i < n; i++)
            {
                // Создание новой строки newRow размером newColumnsCount
                int[] newRow = new int[newColumnsCount];
                // Индекс текущего элемента в новой строке
                int index = 0;
                // Перебор столбцов текущей строки
                for (int j = 0; j < m; j++)
                {
                    // Копирование значения текущего элемента в новую строку
                    newRow[index] = matrix[i][j];
                    // Увеличение индекса
                    index++;
                    // Если текущий столбец находится в списке WithoutNegatives, в новую строку добавляется нулевой элемент
                    if (WithoutNegatives.Contains(j))
                    {
                        newRow[index] = 0;
                        // Увеличение индекса
                        index++;
                    }
                }
                // Замена текущей строки в двумерном массиве на новую строку
                matrix[i] = newRow;
            }

            // Вывод измененного массива на консоль с помощью метода Print
            Console.WriteLine();
            Print(matrix);
        }
    }
}
