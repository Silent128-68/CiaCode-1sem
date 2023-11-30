using System;
using System.Collections.Generic;
using System.IO;

// Определение структуры SPoint для хранения трехмерных координат точки
struct SPoint
{
    public double X;
    public double Y;
    public double Z;

    // Статическое свойство Zero, возвращающее новый экземпляр SPoint с нулевыми координатами
    public static SPoint Zero => new SPoint();
}

class Program
{
    // Метод для считывания точек из файла
    static List<SPoint> ReadPointsFromFile(string filePath)
    {
        List<SPoint> points = new List<SPoint>();

        foreach (var line in File.ReadLines(filePath))
        {
            // Попытка парсинга строки в структуру SPoint
            if (TryParseCoordinates(line, out SPoint point))
            {
                points.Add(point);
            }
        }

        return points;
    }

    // Метод для парсинга строки с координатами в структуру SPoint
    static bool TryParseCoordinates(string line, out SPoint point)
    {
        string[] coordinates = line.Split(' ');

        // Новый экземпляр SPoint с нулевыми координатами
        point = SPoint.Zero;

        // Проверка наличия трех координат и их успешного парсинга
        if (coordinates.Length == 3 &&
            double.TryParse(coordinates[0], out point.X) &&
            double.TryParse(coordinates[1], out point.Y) &&
            double.TryParse(coordinates[2], out point.Z))
        {
            return true;
        }
        return false;
    }

    // Метод для считывания радиуса с клавиатуры
    static bool TryReadRadius(out double radius)
    {
        return double.TryParse(Console.ReadLine(), out radius);
    }

    // Метод для поиска оптимальных центров шара с минимальным числом точек внутри
    static List<SPoint> FindOptimalCenters(List<SPoint> points, double radius, ref double minPointsCount)
    {
        List<SPoint> optimalCenters = new List<SPoint>(points.Count);

        if (points.Count == 0)
        {
            Console.WriteLine("Ошибка: Множество точек не может быть пустым.");
            Environment.Exit(1);
        }

        foreach (SPoint center in points)
        {
            // Подсчет текущего числа точек внутри шара для данного центра
            double currentPointsCount = CountPointsInsideSphere(center, points, radius);

            if (currentPointsCount < minPointsCount)
            {
                minPointsCount = currentPointsCount;

                // Очистка списка оптимальных центров и добавление текущего центра
                optimalCenters.Clear();
                optimalCenters.Add(center);
            }
            else if (currentPointsCount == minPointsCount)
            {
                // Добавление центра к списку оптимальных центров при равенстве количества точек
                optimalCenters.Add(center);
            }
        }

        return optimalCenters;
    }

    // Метод для записи центров в файл
    static void WriteCentersToFile(string filePath, List<SPoint> centers)
    {
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            foreach (SPoint center in centers)
            {
                writer.Write($"{center.X} {center.Y} {center.Z}\n");
            }
        }
    }

    // Метод для подсчета числа точек внутри шара для заданного центра
    static double CountPointsInsideSphere(SPoint center, List<SPoint> points, double radius)
    {
        double count = 0;

        foreach (SPoint point in points)
        {
            double distance = CalculateDistance(center, point);

            if (distance <= radius)
            {
                count++;
            }
        }
        return count;
    }

    // Метод для вычисления расстояния между двумя точками
    static double CalculateDistance(SPoint point1, SPoint point2)
    {
        double dx = point1.X - point2.X;
        double dy = point1.Y - point2.Y;
        double dz = point1.Z - point2.Z;

        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }
    
    static void Main()
    {
        List<SPoint> points = ReadPointsFromFile("input.txt");

        double radius;

        Console.Write("Введите радиус шара: ");
        while (!TryReadRadius(out radius))
        {
            Console.WriteLine("Некорректный ввод. Попробуйте еще раз.");
        }

        double minPointsCount = double.MaxValue;

        // Поиск оптимальных центров с минимальным числом точек внутри шара
        List<SPoint> optimalCenters = FindOptimalCenters(points, radius, ref minPointsCount);

        WriteCentersToFile("output.txt", optimalCenters);

        Console.WriteLine($"Оптимальные центры с минимальным числом точек ({minPointsCount}) записаны в файл 'output.txt'.");
    }
}
