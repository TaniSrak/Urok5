using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Urok5
{
    //Task4
    internal class Employee
    {
        public string Name { get; set; } = "";
        public DateTime DateOfBirth { get; set; }
        public string Phone { get; set; } = "";
        public string Email { get; set; } = "";
        public string  Position { get; set; } = "";
        public string Responsibilities { get; set; } = "";
        public decimal Salary { get; set; }

        public Employee(string name, DateTime dateOfBirth, string phone, string email, string position, string responsibilities, decimal salary)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
            Phone = phone;
            Email = email;
            Position = position;
            Responsibilities = responsibilities;
            Salary = salary;
        }
        //метод для увеличения зп работникам
        public static decimal operator +(Employee a, decimal salary) 
        { 
            return a.Salary + salary;
        }
        public static decimal operator -(Employee a, decimal salary) 
        { 
            return a.Salary + salary; 
        }
        public static bool operator ==(Employee a, Employee b)
        {
            return a.Salary == b.Salary;
        }
        public static bool operator !=(Employee a, Employee b)
        {
            return a.Salary != b.Salary;
        }
        public static bool operator >(Employee a, Employee b)
        {
            return a.Salary > b.Salary;
        }
        public static bool operator <(Employee a, Employee b)
        {
            return a.Salary < b.Salary;
        }

        public override bool Equals(object? obj)
        {
            if(obj is Employee other)
            {
                return this.Salary == other.Salary;
            }
            return false;
        }

        public override string ToString()
        {
            return $"Name: {Name}, Date: {DateOfBirth}, " +
                $"Phone: {Phone}, Rmail: {Email}, position: {Position}, " +
                $"Responsibilities: {Responsibilities}, Salary: {Salary}";
        }
    }
}
