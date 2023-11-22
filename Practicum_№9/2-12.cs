using System; // Подключение пространства имен System для работы с базовыми типами данных и ввода/вывода
using System.IO; // Подключение пространства имен System.IO для работы с файлами

class Program
{
    // Метод для вывода позиций несовпадающих символов
    static void PrintDifferencePositions(string line1, string line2, int lineIndex)
    {
        Console.Write($"Различие в символах строки {lineIndex + 1}: "); // Вывод номера строки с различиями
        for (int i = 0; i < Math.Min(line1.Length, line2.Length); i++) // Цикл по минимальной длине строк
        {
            if (line1[i] != line2[i]) // Проверка символов на несовпадение
            {
                Console.Write($"{i + 1} "); // Вывод позиции несовпадающего символа
            }
        }
        Console.WriteLine(); // Переход на новую строку после вывода всех позиций несовпадений
    }

    // Метод для нахождения различий между файлами
    static void FindDifferences(string file1Path, string file2Path)
    {
        // Проверка на существование файлов
        if (!File.Exists(file1Path) || !File.Exists(file2Path))
        {
            Console.WriteLine("Один или оба файла не существуют."); // Вывод сообщения об отсутствии файлов
            return;
        }

        // Открываем файлы с помощью StreamReader
        using (StreamReader reader1 = new StreamReader(file1Path))
        using (StreamReader reader2 = new StreamReader(file2Path))
        {
            string line1; // Переменная для хранения строки из первого файла
            string line2; // Переменная для хранения строки из второго файла
            int lineIndex = 0; // Счетчик строк для вывода номера строки с различиями

            // Сравниваем строки поочередно
            while ((line1 = reader1.ReadLine()) != null)
            {
                line2 = reader2.ReadLine(); // Считываем строку из второго файла

                // Если один файл короче другого, выводим сообщение и прекращаем сравнение
                if (line2 == null)
                {
                    Console.WriteLine($"Файл 2 короче файла 1. Различие начинается с строки {lineIndex + 1}");
                    break;
                }

                // Выводим различия в символах, если строки не совпадают
                if (line1 != line2)
                {
                    PrintDifferencePositions(line1, line2, lineIndex); // Вызов метода для вывода позиций различий
                }

                lineIndex++; // Увеличение номера текущей строки
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
        Console.WriteLine("Введите путь к первому файлу:"); // Приглашение к вводу пути к первому файлу
        string file1Path = Console.ReadLine(); // Чтение пути к первому файлу с консоли

        Console.WriteLine("Введите путь ко второму файлу:"); // Приглашение к вводу пути ко второму файлу
        string file2Path = Console.ReadLine(); // Чтение пути ко второму файлу с консоли

        FindDifferences(file1Path, file2Path); // Вызов метода для поиска различий между файлами
    }
}
