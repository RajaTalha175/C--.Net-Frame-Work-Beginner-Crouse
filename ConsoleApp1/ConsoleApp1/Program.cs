using ConsoleApp1.Advance_Crouse;
using ConsoleApp1.Intermidiate_Crouse;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.Serialization;
using static ConsoleApp1.Advance_Crouse.Program;



namespace ConsoleApp1
{
    public class Program 
    {

        public static async Task Main(string[] args)
        {

            ///*** Advance Crouse ***\\\
            ///
            ///*** Async and Execption Example  ***\\\
            
            Console.WriteLine("\n--- Async Task Using Exception Handling ---\n");

            CancellationTokenSource token = new CancellationTokenSource();

            string[] urls =
            {
        "https://jsonplaceholder.typicode.com/posts/1",
        "https://jsonplaceholder.typicode.com/posts/2",
        "https://jsonplaceholder.typicode.com/posts/3",
        "https://jsonplaceholder.typicode.com/posts/4"
    };

            try
            {
                Console.WriteLine("Multiple Data Fetching from API...");

                Task<string>[] dataFetching = new Task<string>[urls.Length];

                for (int i = 0; i < dataFetching.Length; i++)
                {
                    
                    dataFetching[i] = TestApi.asyncdataFetch(urls[i], token.Token);
                }

                string[] results = await Task.WhenAll(dataFetching);

                for (int i = 0; i < results.Length; i++)
                {
                    Console.WriteLine($"Result {i + 1}: {results[i].Substring(0, Math.Min(50, results[i].Length))}...");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Critical error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Cleanup finished.");
                
            }


            ///*** Exention Method and NullableType and Dynamic Examples ***\\\
            Console.WriteLine("\n--- Use Extension Method ---\n");
            String word = "hello dear how are";
            var totalcountchar = word.WordCount();
            Console.WriteLine($"Total Word Count  {totalcountchar} and Word is {word}");
            ///Nullabletpe 
            var nullablevalue = word?.Length;
            Console.WriteLine($"Total Word Count Using NullableType {nullablevalue}");
            dynamic dynamicvalue = "Hello";
            object objectvalue = "Hello";
            Console.WriteLine($"Dynamic Value: {dynamicvalue.Length}");  /// no need casting 
            Console.WriteLine($"Object Value: {((string)objectvalue).Length}");/// run-time delare datatype: casting required

             ///*** Events Examples ***\\\

            OrderProcessor setOrder = new OrderProcessor();
            EmailService setEmail = new EmailService();
            LogService setLog = new LogService();
            setOrder.OrderProcessed += setEmail.OnOrderProcessed;
            setOrder.OrderProcessed += setLog.OnOrderProcessed;

            setOrder.ProcessOrder(101, "Talha Rasheed");
            setOrder.ProcessOrder(102, "John Doe");


            ///*** Events Using Interface Class ***\\\


            Console.WriteLine("\n--- Alram Using Intereface Class ---\n");
            IFireAlarm smokeAlarm = new InterfaceSmokeAlarm();
            IFireAlarm heatAlarm = new interfaceHeatAlarm();

            // Trigger alarms
            smokeAlarm.DetectFire("Kitchen");
            heatAlarm.DetectFire("Server Room");

            //////*** Events Using Inheretence Class ***\\\

            Console.WriteLine("\n--- Alaram Using Inheretence Class ---\n");
            BaseAlarm smoke = new SmokeAlarm();
            BaseAlarm heat = new HeatAlarm();

            //  subscribers
            People subpeople = new People();
            FireDepartment fireDept = new FireDepartment();

            // people and firedepaertment set Alaram
            smoke.BaseFireDetected += subpeople.OnFireDetected;
            smoke.BaseFireDetected += fireDept.OnFireDetected;

            heat.BaseFireDetected += subpeople.OnFireDetected;

            // fire Event Genrate 
            smoke.DetectFire("Kitchen");
            Console.WriteLine("\n--- Another Fire ---\n");

            ///*** Delagats Examples ***\\\
            HelloWorld<int> objHelloWorld = new HelloWorld<int>();
            HelloWorld<string> obj1HelloWorld = new HelloWorld<string>();

            objHelloWorld.Add(1000);
            obj1HelloWorld.Add("hamza");

            // Using Dictionary
            Dictionary<int, string> dictionayobj = new Dictionary<int, string>();
            dictionayobj.Add(12, "Ali");
            dictionayobj.Add(13, "Ammad");

            // Using Delegate
            Operation op;

            op = Add;
            Console.WriteLine("Addition: " + op(5, 3));

            op = Multiply;
            Console.WriteLine("Multiplication: " + op(5, 3));

            // Display Generic Results
            Console.WriteLine("Generic Result (int): " + objHelloWorld.Get());
            Console.WriteLine("Generic Result (string): " + obj1HelloWorld.Get());

            // Loop through Dictionary
            foreach (var kv in dictionayobj)
            {
                Console.WriteLine("Dictionary Result: " + kv.Key + " -> " + kv.Value);
            }

            ///*** LinQ and Lambda Querys ***\\\


            Console.WriteLine("\n--- Using Linq and Lambda Expressions ---\n");

            var bookintro =new AdvanceCrouseIntro().BooksDisplay();
            var LamdaCheepBook = bookintro.Where(b => b.Price < 40);
            var Linqscheepbook= from b in bookintro where b.Price <40 orderby b.Price select b;
            foreach (var v in Linqscheepbook)
            {
                Console.WriteLine($"Cheep Book: {v.Title} and Price: {v.Price}");
                //if (v.Price < 20)
                //{
                //    Console.WriteLine($"Cheep Book: {v.Title} and Price: {v.Price}");
                //}
                //else
                //{
                //    Console.WriteLine($"All Book Here: { v.Title} and Price: {v.Price}");
                //}
            }


            Console.WriteLine("\n--- End of Advance Crouse ---\n");
            ///*** The End ***\\\

            ///*** Summary Examples and Exercises ***\\\

            Console.WriteLine("\n--- Intermeidate Crouse Started  ---\n");

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
