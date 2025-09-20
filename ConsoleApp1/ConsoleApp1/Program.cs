using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using ConsoleApp1.Intermidiate_Crouse;


namespace ConsoleApp1
{
    public class Program 
    {

        public static void Main(string[] args)
        {
           
           

            ///*** Summary Examples and Exercises ***\\\

            Stack<int> obj = new Stack<int>();
            for (int i = 0; i < 10; i++) obj.Push(i);
            foreach (var v in obj) Console.WriteLine($"Stack Values: {v}");
            Queue<int> obj1 = new Queue<int>();
            for (int i = 0; i < 10; i++) obj1.Enqueue(i);
            foreach (var v in obj1) Console.WriteLine($"Queue Values: {v}");

            var adminPermission = enumClass.admin;
            Console.WriteLine($"Admin Permissions: {adminPermission.permissionsdisPlay()} ");
            var userPermission = enumClass.read | enumClass.write;
            Console.WriteLine($"User Permissions: {userPermission.permissionsdisPlay()} ");

            IEnumerable<int> number = new int[] { 1, 2, 3, 4, 5 };
            foreach(var n in number)
            {
                Console.WriteLine($"Nmber {0} : {n}");
            }


            ///*** Section [2] Includes: Implemenatation about classes, Constractor and Object in Different Ways ***\\\
            
            Console.WriteLine("///*** Section [2] Implemenatation about classes, Constractor and Object in Different Ways ***\\\\\\");
            Person p =new Person(1, "ali", 30);
            Console.WriteLine($"Person ID: {p.Id} Name: {p.Name} and age: {p.Age}");
            Person p1 = new Person(1, "hamza", 39);
            p1.display();
            Person p2 = new Person();
            p2.Id = 3;
            p2.Name = "haris";
            p2.Age = 40;
            Console.WriteLine($"Person ID: {p1.Id} Name: {p1.Name} and age: {p2.Age}");
            List<Person> people = new List<Person>();


            people.Add(new Person(1, "Ali", 30));
            people.Add(new Person(2, "Hamza", 39));
            people.Add(new Person(3, "Haris", 40));
            Person p3 = new Person();
            int id = 1; string name = "ali"; int age = 30;
            p3.display(people, id, name, age);

            ///*** Section [2] Includes: implementation about Access Modifier and Inheretince ***\\\
            Console.WriteLine("///*** Section [2] implementation about Access Modifier and Inheretince ***\\\\\\");
            Employee.name = "Hamza";

            List<Order> Employees = new List<Order>()
            {
                new Order(1, 25, 5000),
                new Order(2, 30, 6000),
                new Order(3, 28, 5500)
            };

            foreach (var person in Employees)
            {

                person.PersonDetails();
            }

            ///*** Section [2] Includes: Example Using indexe and Dictionary ***\\\
            Console.WriteLine("///*** Section [2] Example Using indexe and Dictionary ***\\\\\\");

            HelloWorld Hello = new HelloWorld();
            Hello[1] = "hamza";
            HelloWorld p9 = new HelloWorld();

            foreach (var item in p9.books)
            {
                Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
            }


            Console.WriteLine("Array Details: " + Hello.Arrays);

            ///*** Section [4] Includes: inheritence Example ***\\\
            Console.WriteLine("///*** Section [4] Includes: inheritence Example ***\\\\\\");

            List<Employees> employees = new List<Employees>
        {
            new EmployeeType(1, "Alice", "Full"),
            new EmployeeType(2, "Bob", "Contratual"),
            new EmployeeType(3, "Charlie", "Part-Time")
        };

            foreach (var emp in employees)
            {
                emp.ShowEmployeeDetails();

            }

            EmployeeType returnsalary = new EmployeeType(4, "hamza", "Full");


            decimal empSalary = returnsalary.ShowEmployeeDetails();


            decimal bonus = empSalary * 0.1m;
            Console.WriteLine("Bonus: " + bonus);




            ///*** Section [5] Includes : Abtract Methods and Inheretence ***\\\

            Console.WriteLine(" ///*** Section 5 Includes : Abtract Methods and Inheretence ***\\\\\\ ");
            List<Shape> shapes = new List<Shape>
        {
            new Cricle("Circle A", 5),  
            new Triangle("Triangle X", 4, 6),
            new Cricle("Circle B", 3),
            new Triangle("Triangle Y", 8, 5)
        };
            foreach (var shape in shapes)
            {
                shape.Draw();
                Console.WriteLine($"Area: {shape.Area():F2}\n");
            }

            ///*** Section [6] Includes : Simple Interface Example ***\\\

            Console.WriteLine(" ///*** Section 6 Includes : Includes : Simple Interface Example ***\\\\\\ ");

            TotalBranches branch1 = new TotalBranches("Toyota");
            branch1.DisplayAddressBranch1();

            TotalBranches branch2 = new TotalBranches("Honda");
            branch2.DisplayAddressBranch2();


            Console.WriteLine(" ///*** End of Intermediate Crouse ***\\\\\\ ");
            Console.ReadLine();
        }
    }
}
