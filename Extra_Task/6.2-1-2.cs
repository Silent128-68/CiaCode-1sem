using System;
using System.Diagnostics;
using System.IO;

class Program
{
    // Функция прямого поиска подстроки в строке
    static int DirectSearch(string text, char target)
    {
        for (int i = 0; i < text.Length; i++)
        {
            // Если символ равен целевому символу, возвращаем текущую позицию
            if (text[i] == target)
                return i;
        }
        return -1; // Буква не найдена
    }

    // Функция поиска подстроки методом Рабина-Карпа
    static int RabinKarpSearch(string text, char target)
    {
        int targetHash = target; // Преобразование символа в числовое значение

        // Вычисление хеша для первого окна текста
        int windowHash = 0;
        for (int i = 0; i < 1; i++) // Используем 1, так как ищем одиночный символ
        {
            windowHash += text[i];
        }

        // Проход по тексту с использованием сдвига окна и пересчета хеша
        for (int i = 0; i <= text.Length - 1; i++)
        {
            // Если хеш окна совпадает с хешем целевого символа
            if (windowHash == targetHash)
            {
                // Проверка символов в случае совпадения хешей
                int j;
                for (j = 0; j < 1; j++) // Используем 1, так как ищем одиночный символ
                {
                    if (text[i + j] != target)
                        break;
                }

                // Если символ найден, возвращаем индекс начала подстроки
                if (j == 1)
                    return i;
            }

            // Сдвиг окна и пересчет хеша
            if (i < text.Length - 1)
            {
                windowHash = (windowHash - text[i]) + text[i + 1];
            }
        }

        return -1; // Подстрока не найдена
    }

    // Точка входа в программу
    static void Main()
    {
        string filePath = "text.txt";
        string sourceText = File.ReadAllText(filePath); 
        char targetChar = 'ф';

        // Прямой поиск подстроки в строке
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        int indexDirectSearch = DirectSearch(sourceText, targetChar);

        stopwatch.Stop();
        Console.WriteLine($"Прямой поиск: Искомая буква найдена на позиции {indexDirectSearch}, время выполнения: {stopwatch.Elapsed}");

        // Алгоритм Карпа-Рабина
        stopwatch.Restart();

        int indexRabinKarp = RabinKarpSearch(sourceText, targetChar);

        stopwatch.Stop();
        Console.WriteLine($"Алгоритм Карпа-Рабина: Искомая буква найдена на позиции {indexRabinKarp}, время выполнения: {stopwatch.Elapsed}");
    }
}

// Если подстрока состоит из 1го символа, а исходная строка состоит из большого количества символо, зачастую алгоритм прямого поиска будет более эффективным, т.к. прямой поиск будет последовательно
// сравнивать каждый символ подстроки с каждым символом текста и алгоритм будет иметь линейную временную сложность O(n), а алгоритм Рабина-Карпа будет более избыточным, т.к он включает допольнительные
// вычисления хэша, что делает его менее эффективным при поиске одиночных символов
