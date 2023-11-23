using System;
using System.Collections.Generic;
using System.IO;

// Структура Student представляет студента и реализует интерфейс IComparable<Student>
struct Student : IComparable<Student>
{
    // Поля для хранения информации о студенте: ФИО, номер группы, оценки за экзамены
    public string FullName;
    public string GroupNumber;
    public int Exam1;
    public int Exam2;
    public int Exam3;

    // Конструктор для инициализации полей при создании объекта студента
    public Student(string fullName, string groupNumber, int exam1, int exam2, int exam3)
    {
        FullName = fullName;
        GroupNumber = groupNumber;
        Exam1 = exam1;
        Exam2 = exam2;
        Exam3 = exam3;
    }

    // Метод CompareTo требуется интерфейсом IComparable<Student> для сравнения студентов по номеру группы
    public int CompareTo(Student obj)
    {
        if (GroupNumber == obj.GroupNumber) 
        { 
            return 0;
        }

        if (int.Parse(GroupNumber) < int.Parse(obj.GroupNumber))
        {
            return 1;
        }

        return -1;
    }
}

class Program
{
    static void Main()
    {
        // Создание списка для хранения студентов
        List<Student> students = new List<Student>();

        try
        {
            // Чтение строк из файла "input.txt"
            string[] lines = File.ReadAllLines("input.txt");

            // Обработка каждой строки из файла
            foreach (string line in lines)
            {
                // Разделение строки на части по пробелам
                string[] parts = line.Split(' ');

                // Проверка, что в строке достаточно элементов для создания объекта Student
                if (parts.Length >= 6)
                {
                    // Извлечение информации из частей строки
                    string fullName = parts[0] + " " + parts[1];
                    string groupNumber = parts[2];
                    int exam1 = int.Parse(parts[3]);
                    int exam2 = int.Parse(parts[4]);
                    int exam3 = int.Parse(parts[5]);
                    
                    // Создание объекта Student и добавление его в список студентов
                    Student student = new Student(fullName, groupNumber, exam1, exam2, exam3);
                    students.Add(student);
                }
            }

            // Фильтрация студентов, прошедших экзамены
            List<Student> passedStudents = students.FindAll(student => student.Exam1 + student.Exam2 + student.Exam3 > 10);

            // Сортировка списка студентов по номеру группы
            passedStudents.Sort();

            // Запись результатов в файл "output.txt"
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (Student student in passedStudents)
                {
                    // Запись данных студента в файл
                    writer.WriteLine($"{student.FullName} {student.GroupNumber} {student.Exam1} {student.Exam2} {student.Exam3}");
                }
            }

            Console.WriteLine("Выполнено.");
        }
        catch (Exception ex)
        {
            // Обработка и вывод сообщения об ошибке
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
