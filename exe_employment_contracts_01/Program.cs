using System;
using System.Globalization;
using exe_employment_contracts_01.Entities.Enum;
using exe_employment_contracts_01.Entities;

namespace exe_employment_contracts_01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter department's name: ");
            String deptname = Console.ReadLine();
            Console.WriteLine("Enter Worker date: ");
            Console.Write("Name: ");
            string name = Console.ReadLine();
            Console.Write("Level (Junior/MidLevel/Senior): ");
            WorkerLevel level = Enum.Parse<WorkerLevel>(Console.ReadLine());
            Console.Write("Base Salary: ");
            double baseSalary = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);

            Department dept = new Department(deptname);
            Worker worker = new Worker(name,level, baseSalary, dept);

            Console.Write("How many contracts to this worker? ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("-------------------------------------------------------------");
            for (int i = 1; i <= n; i++) 
            {
                Console.WriteLine($"Enter #{i} contract data:");
                Console.Write("Date (DD/MM/YYYY):");
                DateTime date = DateTime.Parse(Console.ReadLine());
                Console.Write("Value per hour: ");
                double valuePerHour = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                Console.Write("Duration (hours): ");
                int hours = int.Parse(Console.ReadLine());

                HourContract contract = new HourContract(date, valuePerHour, hours);
                worker.AddContract(contract);
                Console.WriteLine("-------------------------------------------------------------");
            }
            Console.Write("Enter month and year to calculate income (MM/YYYY):");
            string monthandyear = Console.ReadLine();
            int month = int.Parse(monthandyear.Substring(0, 2));
            int year = int.Parse(monthandyear.Substring(3));
            Console.WriteLine("Name: " + worker.Name);
            Console.WriteLine("Department: " + worker.Department.Name);
            Console.WriteLine("Income for " + monthandyear + " :" + worker.Income(year, month).ToString("F2",CultureInfo.InvariantCulture));

        }
    }
}
