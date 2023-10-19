using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Введите текстовое сообщение:");
        string message = Console.ReadLine();

        // Разделение строки на слова по пробелам и знакам препинания
        string[] words = message.Split(new[] { ' ', ',', '.', '!', '?', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);

        int maxLength = 0;
        // Нахождение максимальной длины слова
        foreach (string word in words)
        {
            if (word.Length > maxLength)
            {
                maxLength = word.Length;
            }
        }

        Console.WriteLine("Самые длинные слова:");
        // Нахождение всех слов с максимальной длиной
        foreach (string word in words)
        {
            if (word.Length == maxLength)
            {
                Console.WriteLine(word);
            }
        }
    }
}
