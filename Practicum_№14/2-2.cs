using System;
using System.Collections.Generic;
using System.IO;

struct Student : IComparable<Student>
{
    public string FullName;
    public string GroupNumber;
    public int Exam1;
    public int Exam2;
    public int Exam3;

    public Student(string fullName, string groupNumber, int exam1, int exam2, int exam3)
    {
        FullName = fullName;
        GroupNumber = groupNumber;
        Exam1 = exam1;
        Exam2 = exam2;
        Exam3 = exam3;
    }

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
        List<Student> students = new List<Student>();

        try
        {
            string[] lines = File.ReadAllLines("input.txt");
            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                if (parts.Length >= 6)
                {
                    string fullName = parts[0] + " " + parts[1];
                    string groupNumber = parts[2];
                    int exam1 = int.Parse(parts[3]);
                    int exam2 = int.Parse(parts[4]);
                    int exam3 = int.Parse(parts[5]);
                    
                    Student student = new Student(fullName, groupNumber, exam1, exam2, exam3);
                    students.Add(student);
                }
            }

            List<Student> passedStudents = students.FindAll(student => student.Exam1 + student.Exam2 + student.Exam3 > 10);

            passedStudents.Sort();

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                foreach (Student student in passedStudents)
                {
                    writer.WriteLine($"{student.FullName} {student.GroupNumber} {student.Exam1} {student.Exam2} {student.Exam3}");
                }
            }

            Console.WriteLine("Выполнено.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
