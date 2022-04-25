using System;
using System.Collections.Generic;
using TaxPayment.Entities;
using System.Globalization;


namespace TaxPayment
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter the number of tax payers: ");
            int entries = int.Parse(Console.ReadLine());
            List<TaxPayer> list = new List<TaxPayer>();

            for (int i = 1; i <= entries; i++)
            {
                Console.WriteLine($"Enter tax payer #{i} data:");
                Console.Write("Individual or Company (i/c)? ");
                char verify = char.Parse(Console.ReadLine());

                if (verify == 'i' || verify == 'I')
                {
                    Console.Write("Name: ");
                    string taxpayer = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Health expenditures: ");
                    double healthExpenditures = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new Individual(taxpayer, anualIncome, healthExpenditures));
                }
                else if (verify == 'c' || verify == 'C')
                {
                    Console.Write("Name: ");
                    string taxpayer = Console.ReadLine();
                    Console.Write("Anual income: ");
                    double anualIncome = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    Console.Write("Number of employees: ");
                    int employees = int.Parse(Console.ReadLine());
                    list.Add(new Company(taxpayer, anualIncome, employees));
                }
                else
                {
                    Console.WriteLine("Impossible to find type of tax payer.");
                }
            }

            Console.WriteLine();
            Console.WriteLine("TAXES PAID: ");
            foreach (TaxPayer payer in list)
            {
                Console.WriteLine($"{payer.Name}: $ {payer.Tax().ToString("F2", CultureInfo.InvariantCulture)} ");
            }
        }
    }
}
