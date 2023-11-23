using System;
using System.Collections.Generic;

// Определение структуры SPoint для хранения трехмерных координат точки
struct SPoint
{
    // Свойства X, Y, Z для координат точки, только для чтения
    public double X { get; }
    public double Y { get; }
    public double Z { get; }

    // Конструктор для инициализации координат точки
    public SPoint(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }

    // Метод для вычисления расстояния между текущей точкой и другой точкой
    public double DistanceTo(SPoint other)
    {
        double dx = X - other.X;
        double dy = Y - other.Y;
        double dz = Z - other.Z;
        return Math.Sqrt(dx * dx + dy * dy + dz * dz);
    }

    // Метод для подсчета количества точек внутри шара с центром в текущей точке
    public int CountPointsInside(List<SPoint> points, double radius)
    {
        int count = 0;
        foreach (SPoint point in points)
        {
            if (this.DistanceTo(point) <= radius)
            {
                count++;
            }
        }
        return count;
    }
}

class Program
{
    // Метод для поиска оптимального центра шара с минимальным числом точек внутри
    static SPoint FindOptimalCenter(List<SPoint> points, double radius)
    {
        int n = points.Count;

        // Проверка на пустое множество точек
        if (n == 0)
        {
            throw new ArgumentException("Множество точек не может быть пустым.");
        }

        // Инициализация оптимального центра и минимального числа точек внутри
        SPoint optimalCenter = points[0];
        int minPointsContained = optimalCenter.CountPointsInside(points, radius);

        // Поиск оптимального центра
        for (int i = 1; i < n; i++)
        {
            int pointsContained = points[i].CountPointsInside(points, radius);
            if (pointsContained < minPointsContained)
            {
                optimalCenter = points[i];
                minPointsContained = pointsContained;
            }
        }

        return optimalCenter;
    }
    
    // Основной метод программы
    static void Main()
    {
        List<SPoint> points = new List<SPoint>();
        
        // Ввод координат точек с клавиатуры
        Console.WriteLine("Введите координаты точек (X Y Z):");
        for (int i = 0; i < 6; i++)
        {
            string[] coordinates = Console.ReadLine().Split();
            double x = double.Parse(coordinates[0]);
            double y = double.Parse(coordinates[1]);
            double z = double.Parse(coordinates[2]);
            points.Add(new SPoint(x, y, z));
        }

        // Ввод радиуса с клавиатуры
        Console.WriteLine("Введите радиус шара:");
        double radius = double.Parse(Console.ReadLine());

        // Поиск и вывод оптимального центра
        SPoint optimalCenter = FindOptimalCenter(points, radius);
        Console.WriteLine($"Оптимальный центр: ({optimalCenter.X}, {optimalCenter.Y}, {optimalCenter.Z})");
    }
}
