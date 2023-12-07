using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

// Определение структуры для хранения информации о продукции
struct Product
{
    public string Type { get; set; }
    public double Cost { get; set; }
    public string Sort { get; set; }
    public int Quantity { get; set; }
}

class Program
{
    static void Main()
    {
        List<Product> products = (from line in File.ReadAllLines("input.txt")
                                let parts = line.Split(';')
                                // Создание нового объекта типа Product для каждой строки
                                select new Product
                                {
                                    // Присвоение значений полям объекта из частей строки
                                    Type = parts[0],
                                    Cost = double.Parse(parts[1]), 
                                    Sort = parts[2],
                                    Quantity = int.Parse(parts[3]) 
                                })
                                .ToList();
                                
//        List<Product> products = File.ReadAllLines("input.txt")
//                                .Select(line =>
//                                {
//                               string[] parts = line.Split(';');
//                                return new Product
//                                {
//                                    Type = parts[0],
//                                   Cost = double.Parse(parts[1]),
//                                    Sort = parts[2],
//                                    Quantity = int.Parse(parts[3])
//                                };
//                                })
//                                .ToList();
                                
        // Заданная величина количества
        int thresholdQuantity = 10;

        // Использование LINQ для фильтрации и группировки данных
        var result = (from p in products
                    where p.Quantity > thresholdQuantity // Фильтрация по количеству
                    group p by p.Type into grouped // Группировка по типу
                    select new // Создание объекта для каждой группы
                    {
                        Type = grouped.Key, // Ключ группировки
                        Products = grouped.ToList() 
                    })
                    .ToList();
                    
//        var result = products
//                    .Where(p => p.Quantity > thresholdQuantity)
//                    .GroupBy(p => p.Type)
//                    .Select(group => new
//                    {
//                        Type = group.Key,
//                        Products = group.ToList()
//                   })
//                    .ToList();

        using (var writer = new StreamWriter("output.txt"))
        {
            foreach (var group in result)
            {
                writer.WriteLine($"Продукт: {group.Type}");

                foreach (var product in group.Products)
                {
                    writer.WriteLine($"  Стоимость: {product.Cost}, Сорт: {product.Sort}, Количество: {product.Quantity}");
                }
                writer.WriteLine();
            }
        }
    }
}
