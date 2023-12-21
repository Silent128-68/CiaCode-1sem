using System; 
using System.IO; 
using System.Diagnostics; 

class Program 
{
    static int CustomIndexOf(string source, string pattern, int start) // Определение метода для прямого поиска подстроки в строке.
    {
        int sourceLength = source.Length; // Получение длины исходной строки.
        int patternLength = pattern.Length; // Получение длины искомой подстроки.
        int i, j; // Объявление переменных для использования в циклах.

        for (i = start; i < sourceLength;) // Цикл для итерации по исходной строке, начиная с указанной позиции.
        {
            if (source[i] == pattern[0]) // Проверка, совпадает ли первый символ подстроки с текущим символом исходной строки.
            {
                for (j = 1; j < patternLength && i + j < sourceLength; j++) // Вложенный цикл для сравнения остальных символов подстроки.
                {
                    if (pattern[j] != source[i + j]) // Если символы не совпадают, выходим из внутреннего цикла.
                    {
                        break;
                    }
                }

                if (j == pattern.Length) // Если вложенный цикл дошел до конца подстроки, значит, подстрока найдена.
                {
                    return i; // Возвращаем индекс начала найденной подстроки в исходной строке.
                }
                else
                {
                    i++; // Иначе, увеличиваем индекс и продолжаем поиск.
                }
            }
            else
            {
                i++; // Если текущие символы не совпадают, увеличиваем индекс и продолжаем поиск.
            }
        }

        return -1; // Если подстрока не найдена, возвращаем -1.
    }

    static void RabinKarpAlgorithm(string substring, string sourceString, StreamWriter writer) // Определение метода для алгоритма Рабина-Карпа.
    {
        int substringLength = substring.Length; 
        int sourceLength = sourceString.Length; 
        const long P = 37; // Константа для вычисления хеша.

        long[] pwp = new long[sourceLength]; // Массив для хранения степеней P.
        pwp[0] = 1; // Первая степень P.

        for (int i = 1; i < sourceLength; i++) // Цикл для вычисления степеней P.
        {
            pwp[i] = pwp[i - 1] * P;
        }

        long[] h = new long[sourceLength]; // Массив для хранения хешей префиксов исходной строки.

        for (int i = 0; i < sourceLength; i++) // Цикл для вычисления хешей префиксов.
        {
            h[i] = (sourceString[i] - 'a' + 1) * pwp[i];
            if (i > 0)
                h[i] += h[i - 1];
        }

        long h_s = 0; // Хеш искомой подстроки.

        for (int i = 0; i < substringLength; i++) // Цикл для вычисления хеша искомой подстроки.
        {
            h_s += (substring[i] - 'a' + 1) * pwp[i];
        }

        for (int i = 0; i + substringLength - 1 < sourceLength; i++) // Цикл для поиска подстроки в строке.
        {
            long cur_h = h[i + substringLength - 1];
            if (i > 0)
            {
                cur_h -= h[i - 1];
            }

            if (cur_h == h_s * pwp[i]) // Если хеши совпадают, значит, подстрока найдена.
            {
                break;
            }
        }
    }

    static void Main() 
    {
        using (StreamReader fileIn = new StreamReader("text.txt")) 
        using (StreamWriter writer = new StreamWriter("output.txt")) 
        {
            string substring = fileIn.ReadLine();
            string sourceString = fileIn.ReadToEnd(); 

            Stopwatch timer = new Stopwatch(); // Создание объекта для измерения времени.
            timer.Start(); // Начало отсчета времени.

            RabinKarpAlgorithm(substring, sourceString, writer); // Вызов метода для алгоритма Рабина-Карпа.

            timer.Stop(); // Остановка отсчета времени.
            writer.WriteLine("{0, -15} {1, -30}", "Алгоритм Рабина-Карпа\t\t\t", timer.ElapsedTicks); 

            timer.Start();
            CustomIndexOf(sourceString, substring, 0); // Вызов метода для прямого поиска.
            timer.Stop(); 
            writer.WriteLine("{0, -15} {1, -30}", "Прямой поиск подстроки в строке ", timer.ElapsedTicks); 

            Console.WriteLine("Результаты записаны в файл output.txt"); 
        }
    }
}
