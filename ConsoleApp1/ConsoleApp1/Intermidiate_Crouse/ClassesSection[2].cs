using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp1.Intermidiate_Crouse
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public Person() { }
        public Person(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }


        public void display()
        {
            Console.WriteLine($"Person ID: {Id} Name: {Name} and age: {Age}");
        }

        public void display(List<Person> people, int id, string name, int age)
        {
            var p = people.FirstOrDefault(x => x.Id == id);
            if (p != null)
            {
                Console.WriteLine($"Person ID: {p.Id} Name: {p.Name} and age: {p.Age}");
            }
            else
            {
                Console.WriteLine("Enter Your Correct Details!");
            }
        }
    }
}
