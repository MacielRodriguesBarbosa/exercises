using System.Collections.Generic;
using exe_employment_contracts_01.Entities.Enum;
namespace exe_employment_contracts_01.Entities
{
    class Worker
    {
        public string Name { get; set; }
        public  WorkerLevel Level { get; set; }
        public double BaseSalary { get; set; }
        public Department Department { get; set; }
        public List<HourContract> Contracts { get; set; } = new List<HourContract>();

        public Worker()
        {
        }

        public Worker(string name, WorkerLevel level,Department dept, double baseSalary)
        {
            Name = name;
            Level = level;
            Department = dept;
            BaseSalary = baseSalary;
        }

        public void AddContract(HourContract contract)
        {
            Contracts.Add(contract);
        }
            
        public void RemoveContract(HourContract contract)
        {
            Contracts.Remove(contract);
        }
        public double Income(int year, int month) 
        {
            double Sum = BaseSalary;
            foreach (HourContract contract in Contracts) 
            { 
                if (contract.Date.Year == year && contract.Date.Month == month) 
                {
                    Sum += contract.TotalValue();
                }              
            }
            return Sum;
        }
    }
}
