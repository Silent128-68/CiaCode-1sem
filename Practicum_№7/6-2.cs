using System;
using System.Collections.Generic;

class Program
{
    static void Print(int[][] arr)
    {
        for (int i = 0; i < arr.GetLength(0); i++)
        {
            int cols = arr[i].Length;
            for (int j = 0; j < cols; j++)
                Console.Write(arr[i][j] + "\t");

            Console.WriteLine();
        }
    }

    static bool Negative(int[][] arr, int column)
    {
        for (int i = 0; i < arr.GetLength(0); i++) 
            if (arr[i][column] < 0) // Если найден отрицательный элемент в столбце
                return true;        // Возвращаем true и прекращаем проверку столбца

        return false; 
    }
    
    static void Main()
    {
        Console.Write("n = ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("m = ");
        int m = int.Parse(Console.ReadLine()); 

        int[][] matrix = new int[n][]; 
        for (int i = 0; i < n; i++)
        {
            matrix[i] = new int[m]; // Создание нового массива для каждой строки матрицы
            for (int j = 0; j < m; j++)
            {
                Console.Write("Введите элемент [{0}][{1}]: ", i, j);
                matrix[i][j] = int.Parse(Console.ReadLine()); 
            }
        }

        Print(matrix); 

        List<int> WithoutNegatives = new List<int>(); // Создание списка для хранения индексов столбцов без отрицательных элементов
        for (int i = 0; i < m; i++)
            if (!Negative(matrix, i))       // Если столбец не содержит отрицательных элементов
                WithoutNegatives.Add(i);    // Добавляем индекс столбца в список

        if (WithoutNegatives.Count == 0)
            Console.WriteLine("Нет столбцов без отрицательных элементов"); 
        else
        {
            int newColumnsCount = m + WithoutNegatives.Count; // Вычисление нового количества столбцов матрицы с учетом добавленных столбцов
            for (int i = 0; i < n; i++)
            {
                int[] newRow = new int[newColumnsCount]; // Создание новой строки с учетом нового количества столбцов
                int index = 0;
                for (int j = 0; j < m; j++)
                {
                    newRow[index] = matrix[i][j]; // Копирование элемента из исходной матрицы в новую строку
                    index++;
                    if (WithoutNegatives.Contains(j)) // Если текущий столбец был добавлен в список WithoutNegatives
                    {
                        newRow[index] = 0; // Добавляем нулевой элемент в новую строку
                        index++;
                    }
                }
                matrix[i] = newRow; // Замена старой строки на новую в матрице
            }

            Console.WriteLine();
            Print(matrix);
        }
    }
}
