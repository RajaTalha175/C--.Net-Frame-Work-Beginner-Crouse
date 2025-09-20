using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Intermidiate_Crouse
{
    public class Employee
    {
        public int id;
        public static string name;
        protected int age;
        private int salary;

        public Employee(int id, int age, int salary)
        {
            this.id = id;
            this.age = age;
            this.salary = salary;
        }

        public void setsalary(int s) => salary = s;
        public int getsalary() => salary;
    }

    public class Order : Employee
    {
        public Order(int id, int age, int salary) : base(id, age, salary) { }

        public void PersonDetails()
        {
            Console.WriteLine($"Person Detail: ID:{id}, Name:{name}, Age:{age}, Salary:{getsalary()}");
        }


    }
}
