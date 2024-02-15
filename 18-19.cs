using System;
using System.Collections.Generic;
using System.IO;

// Абстрактный класс Клиент
abstract class Client
{
    // Метод для вывода информации о клиенте
    public abstract void DisplayInfo();

    // Метод для определения соответствия клиента критерию поиска
    public abstract bool IsMatching(DateTime date);
}

// Класс Вкладчик, производный от Клиента
class Depositor : Client
{
    // Поля класса Вкладчик
    public string LastName { get; set; }
    public DateTime DepositStartDate { get; set; }
    public decimal DepositAmount { get; set; }
    public double DepositInterest { get; set; }

    // Конструктор класса Вкладчик
    public Depositor(string lastName, DateTime depositStartDate, decimal depositAmount, double depositInterest)
    {
        LastName = lastName;
        DepositStartDate = depositStartDate;
        DepositAmount = depositAmount;
        DepositInterest = depositInterest;
    }

    // Реализация метода DisplayInfo для вывода информации о вкладчике
    public override void DisplayInfo()
    {
        Console.WriteLine($"Вкладчик: {LastName}");
        Console.WriteLine($"Дата открытия вклада: {DepositStartDate.ToShortDateString()}");
        Console.WriteLine($"Размер вклада: {DepositAmount}");
        Console.WriteLine($"Процент по вкладу: {DepositInterest}");
        Console.WriteLine();
    }

    // Реализация метода IsMatching для определения соответствия дате открытия вклада
    public override bool IsMatching(DateTime date)
    {
        return DepositStartDate >= date;
    }
}

// Класс Кредитор, производный от Клиента
class Creditor : Client
{
    // Поля класса Кредитор
    public string LastName { get; set; }
    public DateTime CreditStartDate { get; set; }
    public decimal CreditAmount { get; set; }
    public double CreditInterest { get; set; }
    public decimal DebtAmount { get; set; }

    // Конструктор класса Кредитор
    public Creditor(string lastName, DateTime creditStartDate, decimal creditAmount, double creditInterest, decimal debtAmount)
    {
        LastName = lastName;
        CreditStartDate = creditStartDate;
        CreditAmount = creditAmount;
        CreditInterest = creditInterest;
        DebtAmount = debtAmount;
    }

    // Реализация метода DisplayInfo для вывода информации о кредиторе
    public override void DisplayInfo()
    {
        Console.WriteLine($"Кредитор: {LastName}");
        Console.WriteLine($"Дата выдачи кредита: {CreditStartDate.ToShortDateString()}");
        Console.WriteLine($"Размер кредита: {CreditAmount}");
        Console.WriteLine($"Процент по кредиту: {CreditInterest}");
        Console.WriteLine($"Остаток долга: {DebtAmount}");
        Console.WriteLine();
    }

    // Реализация метода IsMatching для определения соответствия дате выдачи кредита
    public override bool IsMatching(DateTime date)
    {
        return CreditStartDate >= date;
    }
}

// Класс Организация, производный от Клиента
class Organization : Client
{
    // Поля класса Организация
    public string Name { get; set; }
    public DateTime AccountOpeningDate { get; set; }
    public int AccountNumber { get; set; }
    public decimal AccountBalance { get; set; }

    // Конструктор класса Организация
    public Organization(string name, DateTime accountOpeningDate, int accountNumber, decimal accountBalance)
    {
        Name = name;
        AccountOpeningDate = accountOpeningDate;
        AccountNumber = accountNumber;
        AccountBalance = accountBalance;
    }

    // Реализация метода DisplayInfo для вывода информации организации
    public override void DisplayInfo()
    {
        Console.WriteLine($"Организация: {Name}");
        Console.WriteLine($"Дата открытия счета: {AccountOpeningDate.ToShortDateString()}");
        Console.WriteLine($"Номер счета: {AccountNumber}");
        Console.WriteLine($"Сумма на счету: {AccountBalance}");
        Console.WriteLine();
    }

    // Реализация метода IsMatching для определения соответствия дате открытия счета
    public override bool IsMatching(DateTime date)
    {
        return AccountOpeningDate >= date;
    }
}

class Program
{
    static void Main(string[] args)
    {
        List<Client> clients = new List<Client>();

        // Считывание данных из файла
        try
        {
            using (StreamReader sr = new StreamReader("clients.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split(',');
                    string type = data[0].Trim();
                    if (type == "Depositor")
                    {
                        clients.Add(new Depositor(data[1].Trim(), DateTime.Parse(data[2].Trim()), decimal.Parse(data[3].Trim()), double.Parse(data[4].Trim())));
                    }
                    else if (type == "Creditor")
                    {
                        clients.Add(new Creditor(data[1].Trim(), DateTime.Parse(data[2].Trim()), decimal.Parse(data[3].Trim()), double.Parse(data[4].Trim()), decimal.Parse(data[5].Trim())));
                    }
                    else if (type == "Organization")
                    {
                        clients.Add(new Organization(data[1].Trim(), DateTime.Parse(data[2].Trim()), int.Parse(data[3].Trim()), decimal.Parse(data[4].Trim())));
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Ошибка при чтении файла: " + e.Message);
        }

        // Вывод полной информации о клиентах
        Console.WriteLine("Полная информация о клиентах банка:");
        foreach (var client in clients)
        {
            client.DisplayInfo();
        }

        // Поиск клиентов, начавших сотрудничать с банком с заданной даты
        DateTime searchDate = new DateTime(2024, 1, 1); // Заданная дата для поиска
        Console.WriteLine($"Клиенты, начавшие сотрудничать с банком с {searchDate.ToShortDateString()}:");
        foreach (var client in clients)
        {
            if (client.IsMatching(searchDate))
            {
                client.DisplayInfo();
            }
        }
    }
}
