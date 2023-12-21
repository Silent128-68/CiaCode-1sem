using System;

namespace MyNamespace
{
    class Program
    {
        static void Main()
        {
            // Создание объекта класса Point с начальными координатами (3, 4)
            Point p1 = new Point(3, 4);
            p1.Display(); // Вывод координат на экран

            Console.WriteLine($"Расстояние от начала: {p1.CalculateDistance()}"); // Расстояние от начала координат

            p1.Move(1, 1); // Перемещение на вектор (1, 1)
            p1.Display();

            p1.X = 4; // Установка нового значения x
            p1.Y = 6; // Установка нового значения y
            p1.Scale = 2; // Используем свойство Scale сразу после установки координат
            p1.Display();

            Console.WriteLine($"Индексация - x: {p1[0]}, y: {p1[1]}"); // Использование индексатора

            // Использование оператора ++ для начальных значений
            Console.WriteLine($"++p1: {++p1.InitialX}, {++p1.InitialY}");

            // Использование оператора -- для начальных значений
            Console.WriteLine($"--p1: {--p1.InitialX}, {--p1.InitialY}");

            Console.WriteLine($"Координаты p1 равны? : {Point.IsTrue(p1)}"); // Использование оператора true
            Console.WriteLine($"Координаты p1 не равны? : {Point.IsFalse(p1)}"); // Использование оператора false

            // Использование оператора + для добавления скаляра
            p1 = 5 + p1;
            p1.Display();
        }
    }
}
