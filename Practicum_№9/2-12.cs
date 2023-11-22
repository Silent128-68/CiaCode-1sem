using System;
using System.IO;

class Program
{
    // Метод для сравнения компонент файлов попарно
    static bool Compare(string file1Path, string file2Path)
    {
        // Проверка на существование файлов
        if (!File.Exists(file1Path) || !File.Exists(file2Path))
        {
            return false;
        }

        // Открываем файлы с помощью StreamReader
        using (StreamReader reader1 = new StreamReader(file1Path))
        using (StreamReader reader2 = new StreamReader(file2Path))
        {
            string line1;
            string line2;
            bool filesMatch = true;

            // Сравниваем строки поочередно
            while ((line1 = reader1.ReadLine()) != null && (line2 = reader2.ReadLine()) != null)
            {
                if (line1 != line2)
                {
                    // Выводим различия в строках, если они не совпадают
                    Console.WriteLine($"Различие в строках:\nФайл 1: {line1}\nФайл 2: {line2}");
                    filesMatch = false;
                }
            }

            // Выводим сообщение, если строки совпадают
            if (filesMatch)
            {
                Console.WriteLine("Строки файлов попарно совпадают.");
            }

            return filesMatch;
        }
    }

    // Метод для вывода позиций несовпадающих символов
    static void PrintDifferencePositions(string line1, string line2, int lineIndex)
    {
        Console.Write($"Различие в символах строки {lineIndex + 1}: ");
        for (int i = 0; i < Math.Min(line1.Length, line2.Length); i++)
        {
            if (line1[i] != line2[i])
            {
                Console.Write($"{i + 1} ");
            }
        }
        Console.WriteLine();
    }

    // Метод для нахождения различий между файлами
    static void FindDifferences(string file1Path, string file2Path)
    {
        // Проверка на существование файлов
        if (!File.Exists(file1Path) || !File.Exists(file2Path))
        {
            Console.WriteLine("Один или оба файла не существуют.");
            return;
        }

        // Открываем файлы с помощью StreamReader
        using (StreamReader reader1 = new StreamReader(file1Path))
        using (StreamReader reader2 = new StreamReader(file2Path))
        {
            string line1;
            string line2;
            int lineIndex = 0;

            // Сравниваем строки поочередно
            while ((line1 = reader1.ReadLine()) != null)
            {
                line2 = reader2.ReadLine();

                // Если один файл короче другого, выводим сообщение и прекращаем сравнение
                if (line2 == null)
                {
                    Console.WriteLine($"Файл 2 короче файла 1. Различие начинается с строки {lineIndex + 1}");
                    break;
                }

                // Выводим различия в символах, если строки не совпадают
                if (line1 != line2)
                {
                    PrintDifferencePositions(line1, line2, lineIndex);
                }

                lineIndex++;
            }

            // Если файл 2 имеет больше строк, чем файл 1, выводим дополнительные строки
            while ((line2 = reader2.ReadLine()) != null)
            {
                Console.WriteLine($"Файл 1 короче файла 2. Дополнительная строка в файле 2: {line2}");
            }
        }
    }

    static void Main()
    {
        Console.WriteLine("Введите путь к первому файлу:");
        string file1Path = Console.ReadLine();

        Console.WriteLine("Введите путь ко второму файлу:");
        string file2Path = Console.ReadLine();

        FindDifferences(file1Path, file2Path);
    }
}
