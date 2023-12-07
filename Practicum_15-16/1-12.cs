using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        string inputFileName = "input.txt";
        string outputFileName = "output.txt";

        var numbers = from line in File.ReadAllLines(inputFileName) // обработка строк из входного файла.
                      where int.Parse(line) < 0 && int.Parse(line) > -1000 && int.Parse(line) < -99  // фильтрация строк по условию
                      select -int.Parse(line); //преобразование выбранных строк в числа с инверсией знака

//        var numbers = File.ReadAllLines(inputFileName)
//                      .Where(line => int.Parse(line) < 0 && int.Parse(line) > -1000 && int.Parse(line) < -99)
//                      .Select(line => -int.Parse(line));
        Console.WriteLine("Результат:");
        Console.WriteLine(string.Join(", ", numbers));

        File.WriteAllLines(outputFileName, from n in numbers select n.ToString());
    }
}
