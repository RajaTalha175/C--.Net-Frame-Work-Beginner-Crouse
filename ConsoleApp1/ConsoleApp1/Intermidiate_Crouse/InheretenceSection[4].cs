using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Intermidiate_Crouse
{
    public abstract class Employees
    {
        private int id;
        public string Name { get; set; }

        public Employees(int ID, string Name)
        {
            id = ID;
            this.Name = Name;
        }
        public int GetID()
        {
            return id;
        }
        public abstract decimal ShowEmployeeDetails();
    }

    public class EmployeeType : Employees
    {
        public string Type { get; set; }

        public EmployeeType(int id, string name, string type) : base(id, name)
        {
            this.Type = type;
        }

        public override decimal ShowEmployeeDetails()
        {
            decimal salary = 0;
            if (Type == "Full")
            {
                salary = 10000;
                Console.WriteLine($"[Full-Time] ID: {GetID()}, Name: {Name}, Salary: {salary}");
            }
            else if (Type == "Contratual")
            {
                salary = 20000;
                Console.WriteLine($"[Contratual] ID: {GetID()}, Name: {Name}, Salary: {salary}");
            }
            else
            {
                salary = 5000;
                Console.WriteLine($"[Part-Time] ID: {GetID()}, Name: {Name}, Salary: {salary}");
            }
            return salary;
        }
    }
}
