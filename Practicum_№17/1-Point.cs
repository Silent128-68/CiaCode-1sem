using System;

namespace MyNamespace
{
    class Point
    {
        // Поля класса Point
        private int x, y;

        // Конструктор без параметров, инициализирующий координаты нулями
        public Point() : this(0, 0) { }

        // Конструктор с параметрами, позволяющий задать координаты точки
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        // Метод вывода координат точки на экран
        public void Display()
        {
            Console.WriteLine($"Координаты точки: ({x}, {y})");
        }

        // Метод расчета расстояния от начала координат до точки
        public double CalculateDistance()
        {
            return Math.Sqrt(x * x + y * y);
        }

        // Метод перемещения точки на плоскости на вектор (a, b)
        public void Move(int a, int b)
        {
            x += a;
            y += b;
        }

        // Свойство для доступа к полю x (чтение и запись)
        public int X
        {
            get { return x; }
            set { x = value; }
        }

        // Свойство для доступа к полю y (чтение и запись)
        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        // Свойство для умножения координат на скаляр (доступное только для записи)
        public int Scale
        {
            set
            {
                x *= value;
                y *= value;
            }
        }

        // Индексатор для доступа к полям x и y по индексу
        public int this[int index]
        {
            get
            {
                if (index == 0) return x;
                else if (index == 1) return y;
                else
                {
                    Console.WriteLine("Invalid index. Use 0 for x, 1 for y.");
                    return -1; // Возвращаем значение-заполнитель; можно выбрать другой подход.
                }
            }
            set
            {
                if (index == 0) x = value;
                else if (index == 1) y = value;
                else
                {
                    Console.WriteLine("Invalid index. Use 0 for x, 1 for y.");
                }
            }
        }

        // Перегрузка оператора ++ для увеличения значений x и y на 1
        public static Point operator ++(Point point)
        {
            Point temp = new Point(point.x, point.y);
            temp.x = point.x + 1;
            temp.y = point.y + 1;
            return temp;
        }

        // Перегрузка оператора -- для уменьшения значений x и y на 1
        public static Point operator --(Point point)
        {
            Point temp = new Point(point.x, point.y);
            temp.x = point.x - 1;
            temp.y = point.y - 1;
            return temp;
        }

        // Перегрузка оператора true: возвращает true, если x и y совпадают
        public static bool IsTrue(Point point)
        {
            return point.x == point.y;
        }

        // Перегрузка оператора false: возвращает true, если x и y не совпадают
        public static bool IsFalse(Point point)
        {
            return point.x != point.y;
        }

        // Перегрузка оператора + для добавления скаляра к x и y
        public static Point operator +(int scalar, Point point)
        {
            Point temp = new Point(point.x, point.y);
            temp.x += scalar;
            temp.y += scalar;
            return temp;
        }
    }
}
