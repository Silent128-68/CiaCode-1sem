using System;
using System.IO;

class Program
{
    // Метод для сравнения компонент файлов попарно
    static bool Compare(string file1Path, string file2Path)
    {
        // Открываем файлы с помощью StreamReader
        using (StreamReader reader1 = new StreamReader(file1Path))
        using (StreamReader reader2 = new StreamReader(file2Path))
        {
            int char1;
            int char2;

            // Считываем символы из обоих файлов пока не достигнем конца файла
            while ((char1 = reader1.Read()) != -1 && (char2 = reader2.Read()) != -1)
            {
                // Если символы не совпадают, возвращаем false
                if (char1 != char2)
                {
                    return false;
                }
            }

            // Если все символы совпадают, возвращаем true
            return true;
        }
    }
    
    // Метод для нахождения индекса первой компоненты, в которой файлы отличаются
    static int FindFirstDifference(string file1Path, string file2Path)
    {
        // Открываем файлы с помощью StreamReader
        using (StreamReader reader1 = new StreamReader(file1Path))
        using (StreamReader reader2 = new StreamReader(file2Path))
        {
            int char1;
            int char2;
            int index = 0;

            // Считываем символы из обоих файлов пока не достигнем конца файла
            while ((char1 = reader1.Read()) != -1 && (char2 = reader2.Read()) != -1)
            {
                // Если символы не совпадают, возвращаем текущий индекс
                if (char1 != char2)
                {
                    return index;
                }

                // Увеличиваем индекс для перехода к следующей компоненте
                index++;
            }

            // Если все символы совпадают, возвращаем текущий индекс
            return index;
        }
    }
    
    static void Main()
    {
        Console.WriteLine("Введите путь к первому файлу:");
        string file1Path = Console.ReadLine();

        Console.WriteLine("Введите путь ко второму файлу:");
        string file2Path = Console.ReadLine();

        bool filesMatch = Compare(file1Path, file2Path);

        if (filesMatch)
        {
            Console.WriteLine("Компоненты файлов попарно совпадают.");
        }
        else
        {
            Console.WriteLine("Файлы отличаются в компоненте с индексом: " + FindFirstDifference(file1Path, file2Path));
        }
    }
}
