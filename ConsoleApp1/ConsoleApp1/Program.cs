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
using System.Text.RegularExpressions;

using ConsoleApp1.Model;



namespace ConsoleApp1
{
    public class Program 
    {
        static void AddDataMenu()
        {
            Console.WriteLine("\n=== Add Data Menu ===");
            Console.WriteLine("1. Department");
            Console.WriteLine("2. Student");
            Console.WriteLine("3. Instructor");
            Console.WriteLine("4. Course");
            Console.WriteLine("5. Enrollment");
            Console.WriteLine("6. Schedule");
            Console.Write("Select an option (1-6): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": // Department
                    Console.Write("Enter DeptID: ");
                    int deptId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Name: ");
                    string deptName = Console.ReadLine();
                    Console.Write("Enter Address: ");
                    string deptAddress = Console.ReadLine();

                    Instructor_Student_Operations.SaveDepartments(new List<Department>
            {
                new Department { DeptID = deptId, Name = deptName, Address = deptAddress }
            });
                    break;

                case "2": // Student
                    Console.Write("Enter StudentID: ");
                    int studentId = int.Parse(Console.ReadLine());

                    Console.Write("Enter Full Name: ");
                    string studentName = Console.ReadLine();

                    Console.Write("Enter Address: ");
                    string studentAddress = Console.ReadLine();

                    Console.Write("Enter DepartmentID: ");
                    int studentDeptId = int.Parse(Console.ReadLine());

                    Console.Write("Enter UserID: ");
                    int userId = int.Parse(Console.ReadLine());

                    // Email Validation
                    Console.Write("Enter Email: ");
                    string email = Console.ReadLine();
                    string emailPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6}$";
                    //if (string.IsNullOrEmpty(email) || !Regex.IsMatch(email, emailPattern))
                    //{
                    //    Console.WriteLine(" Invalid Email format. Please try again.");
                    //    break; 
                    //}

                    
                    Console.Write("Enter Password: ");
                    string password = Console.ReadLine();
                    Regex passPattern = new Regex(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$");
                    //if (string.IsNullOrEmpty(password) || !passPattern.IsMatch(password))
                    //{
                    //    Console.WriteLine(" Invalid Password. Must contain at least:\n- 8 characters\n- 1 uppercase\n- 1 lowercase\n- 1 digit\n- 1 special character");
                    //    break;
                    //}

                    var student = new Student
                    {
                        StudentID = studentId,
                        FullName = studentName,
                        Address = studentAddress,
                        DepartmentID = studentDeptId
                    };

                    var user = new User
                    {
                        UserID = userId,
                        Email = email,
                        Password = password,
                        Role = "Student"
                    };

                    Instructor_Student_Operations.SaveStudent(student, user);
                    break;

                case "3": // Instructor
                    Console.Write("Enter InstructorID: ");
                    int instrId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Full Name: ");
                    string instrName = Console.ReadLine();
                    Console.Write("Enter Address: ");
                    string instrAddress = Console.ReadLine();
                    Console.Write("Enter DepartmentID: ");
                    int instrDeptId = int.Parse(Console.ReadLine());

                    Console.Write("Enter UserID: ");
                    int instrUserId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Email: ");
                    string instrEmail = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    string instrPassword = Console.ReadLine();

                    var instructor = new Instructor { InstructorID = instrId, FullName = instrName, Address = instrAddress, DeptID = instrDeptId };
                    var instrUser = new User { UserID = instrUserId, Email = instrEmail, Password = instrPassword, Role = "Instructor" };

                    Instructor_Student_Operations.SaveInstructor(instructor, instrUser);
                    break;

                case "4": // Course
                    Console.Write("Enter Department Name: ");
                    string courseDept = Console.ReadLine();
                    Console.Write("Enter Course Title: ");
                    string courseTitle = Console.ReadLine();
                    Console.Write("Enter Credit Hours: ");
                    int creditHours = int.Parse(Console.ReadLine());

                    var courseList = new List<AddCrouse>
            {
                new AddCrouse { Title = courseTitle, CreditsHours = creditHours }
            };

                    Instructor_Student_Operations.SaveCourse(courseList, courseDept);
                    break;

                case "5": // Enrollment
                    Console.Write("Enter StudentID: ");
                    int enrollStuId = int.Parse(Console.ReadLine());
                    Console.Write("Enter CourseID: ");
                    int enrollCourseId = int.Parse(Console.ReadLine());

                    var enrollmentList = new List<Enrollment>
            {
                new Enrollment { StudentID = enrollStuId, CourseID = enrollCourseId, EnrollmentDate = DateTime.Now }
            };

                    Instructor_Student_Operations.SaveEnrollment(enrollmentList);
                    break;

                case "6": // Schedule
                    Console.Write("Enter InstructorID: ");
                    int scheduleInstrId = int.Parse(Console.ReadLine());
                    Console.Write("Enter CourseID: ");
                    int scheduleCourseId = int.Parse(Console.ReadLine());
                    Console.Write("Enter Schedule Date (yyyy-MM-dd): ");
                    DateTime scheduleDate = DateTime.Parse(Console.ReadLine());

                    var scheduleList = new List<Schedule>
            {
                new Schedule { InstructorID = scheduleInstrId, CourseID = scheduleCourseId, ScheduletDate = scheduleDate }
            };

                    Instructor_Student_Operations.SaveSchedule(scheduleList);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please select from 1 to 6.");
                    break;
            }
        }
        public static void UpdateDataMenu()
        {
            Console.WriteLine("\n=== Update Menu ===");
            Console.WriteLine("1. Department");
            Console.WriteLine("2. Student");
            Console.WriteLine("3. Instructor");
            Console.WriteLine("4. Course");
            Console.WriteLine("5. Enrollment");
            Console.WriteLine("6. Schedule");
            Console.Write("Select type to update (1-6): ");

            string type = Console.ReadLine();

            switch (type)
            {
                case "1": // Department
                    Console.Write("Enter DeptID to update: ");
                    int deptId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Name: ");
                    string deptName = Console.ReadLine();
                    Console.Write("Enter new Address: ");
                    string deptAddress = Console.ReadLine();
                    Instructor_Student_Operations.UpdateDepartment(deptId, deptName, deptAddress);
                    break;

                case "2": // Student
                    Console.Write("Enter StudentID to update: ");
                    int stuId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Name: ");
                    string stuName = Console.ReadLine();
                    Console.Write("Enter new Address: ");
                    string stuAddress = Console.ReadLine();
                    Console.Write("Enter new DeptID: ");
                    int stuDeptId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new UserID: ");
                    int stuUserId = int.Parse(Console.ReadLine());
                    Instructor_Student_Operations.UpdateStudent(stuId, stuName, stuAddress, stuDeptId, stuUserId);
                    break;

                case "3": // Instructor
                    Console.Write("Enter InstructorID to update: ");
                    int instrId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Name: ");
                    string instrName = Console.ReadLine();
                    Console.Write("Enter new Address: ");
                    string instrAddress = Console.ReadLine();
                    Console.Write("Enter new DeptID: ");
                    int instrDeptId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new UserID: ");
                    int instrUserId = int.Parse(Console.ReadLine());
                    Instructor_Student_Operations.UpdateInstructor(instrId, instrName, instrAddress, instrDeptId, instrUserId);
                    break;

                case "4": // Course
                    Console.Write("Enter CourseID to update: ");
                    int courseId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new DeptID: ");
                    int courseDeptId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Title: ");
                    string courseTitle = Console.ReadLine();
                    Console.Write("Enter new Credit Hours: ");
                    int courseCH = int.Parse(Console.ReadLine());
                    Instructor_Student_Operations.UpdateCourse(courseId, courseDeptId, courseTitle, courseCH);
                    break;

                case "5": // Enrollment
                    Console.Write("Enter EnrollmentID to update: ");
                    int enrollId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new StudentID: ");
                    int enrollStuId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new CourseID: ");
                    int enrollCourseId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Date (yyyy-MM-dd): ");
                    DateTime enrollDate = DateTime.Parse(Console.ReadLine());
                    Instructor_Student_Operations.UpdateEnrollment(enrollId, enrollStuId, enrollCourseId, enrollDate);
                    break;

                case "6": // Schedule
                    Console.Write("Enter ScheduleID to update: ");
                    int schedId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new CourseID: ");
                    int schedCourseId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new InstructorID: ");
                    int schedInstrId = int.Parse(Console.ReadLine());
                    Console.Write("Enter new Date (yyyy-MM-dd): ");
                    DateTime schedDate = DateTime.Parse(Console.ReadLine());
                    Instructor_Student_Operations.UpdateSchedule(schedId, schedCourseId, schedInstrId, schedDate);
                    break;

                default:
                    Console.WriteLine("Invalid option. Please select between 1 and 6.");
                    break;
            }
        }
        public static void DeleteDataMenu()
        {
            Console.WriteLine("\n=== Delete Menu ===");
            Console.WriteLine("1. Department");
            Console.WriteLine("2. Student");
            Console.WriteLine("3. Instructor");
            Console.WriteLine("4. Course");
            Console.WriteLine("5. Enrollment");
            Console.WriteLine("6. Schedule");
            Console.Write("Select type to delete (1-6): ");

            string choice = Console.ReadLine();

            Console.Write("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1": Instructor_Student_Operations.DeleteRecord("department", id); break;
                case "2": Instructor_Student_Operations.DeleteRecord("student", id); break;
                case "3": Instructor_Student_Operations.DeleteRecord("instructor", id); break;
                case "4": Instructor_Student_Operations.DeleteRecord("course",id); break;
                case "5": Instructor_Student_Operations.DeleteRecord("enrollment", id); break;
                case "6": Instructor_Student_Operations.DeleteRecord("schedule",id); break;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
        public static void ShowDataMenu()
        {
            Console.WriteLine("Select type to show:");
            Console.WriteLine("1 - Users");
            Console.WriteLine("2 - Students");
            Console.WriteLine("3 - Instructors");
            Console.WriteLine("4 - Departments");
            Console.WriteLine("5 - Courses");
            Console.WriteLine("6 - Enrollments");
            Console.WriteLine("7 - Schedules");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Instructor_Student_Operations.ShowData("User");
                    break;
                case "2":
                    Instructor_Student_Operations.ShowData("Student");
                    break;
                case "3":
                    Instructor_Student_Operations.ShowData("Instructor");
                    break;
                case "4":
                    Instructor_Student_Operations.ShowData("Department");
                    break;
                case "5":
                    Instructor_Student_Operations.ShowData("Course");
                    break;
                case "6":
                    Instructor_Student_Operations.ShowData("Enrollment");
                    break;
                case "7":
                    Instructor_Student_Operations.ShowData("Schedule");
                    break;
                default:
                    Console.WriteLine("Invalid choice! Please select between 1 and 7.");
                    break;
            }
        }
        public static void SearchDataMenu()
        {
            Console.WriteLine("\n=== Search Menu ===");
            Console.WriteLine("1. Department by ID");
            Console.WriteLine("2. Student by ID");
            Console.WriteLine("3. Instructor by ID");
            Console.WriteLine("4. Course by ID");
            Console.WriteLine("5. Enrollment by ID");
            Console.WriteLine("6. Schedule by ID");
            Console.Write("Select option (1-6): ");
            string choice = Console.ReadLine();

            Console.Write("Enter ID to search: ");
            int id = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case "1":
                    Instructor_Student_Operations.SearchByID(id, "Department");
                    break;
                case "2":
                    Instructor_Student_Operations.SearchByID(id, "Student");
                    break;
                case "3":
                    Instructor_Student_Operations.SearchByID(id, "Instructor");
                    break;
                case "4":
                    Instructor_Student_Operations.SearchByID(id, "Course");
                    break;
                case "5":
                    Instructor_Student_Operations.SearchByID(id, "Enrollment");
                    break;
                case "6":
                    Instructor_Student_Operations.SearchByID(id, "Schedule");
                    break;
                default:
                    Console.WriteLine("Invalid option!");
                    break;
            }
        }

        public static async Task Main(string[] args)
        {


            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("\n=== Main Menu ===");
                Console.WriteLine("1. Add Data");
                Console.WriteLine("2. Update Data");
                Console.WriteLine("3. Delete Data");
                Console.WriteLine("4. Show Data");
                Console.WriteLine("5. Search Data");
                Console.WriteLine("6. Exit");
                Console.Write("Select an option: ");
                Console.Write("\n");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddDataMenu(); break;
                    case "2": UpdateDataMenu(); break;
                    case "3": DeleteDataMenu(); break;
                    case "4": ShowDataMenu(); break;
                    case "5": SearchDataMenu(); break;
                    case "6": exit = true; break;
                    default: Console.WriteLine("Invalid choice, try again."); break;
                }
            }

            Console.ReadLine();









            //var departments = new List<Department>
            //{
            //    new Department { DeptID = 1, Name = "Computer Science", Address = "Islamabad" },
            //    new Department { DeptID = 3, Name = "Arts", Address = "Islamabad" },
            //    new Department { DeptID = 4, Name = "Arts", Address = "Islamabad" },
            //};


            //Instructor_Student_Operations.SaveDepartments(departments);

            //Instructor_Student_Operations.ShowDepartment(departments);
            //var user1 = new User
            //{
            //    UserID = 1,
            //    Email = "talha@email.com",
            //    Password = "*****",
            //    Role = "Student"
            //};

            //var student1 = new Student
            //{
            //    StudentID = 1,
            //    UserID = 1,
            //    DepartmentID = 1,
            //    FullName = "Talha",
            //    Address = "Islamabad"
            //};

            //  Instructor_Student_Operations.SaveStudent(student1, user1);
            //var user1 = new User
            //{
            //    UserID = 3,
            //    Email = "ahmad@email.com",
            //    Password = "12345",
            //    Role = "Instructor"
            //};

            //var instructor1 = new Instructor
            //{
            //    InstructorID = 1,
            //    FullName = "Ahmad Khan",
            //    Address = "Lahore",
            //    DeptID = 1
            //};
            //Instructor_Student_Operations.SaveInstructor(instructor1, user1);

            //var newCourses = new List<AddCrouse>
            //{
            //    new AddCrouse { Title = "Visual Programing", CreditsHours = 4 },
            //    new AddCrouse { Title = "Web Engineering", CreditsHours = 4 }
            //};


            //string departmentName = "Computer Science";


            //Instructor_Student_Operations.SaveCourse(newCourses, departmentName);

            //    var newEnrollments = new List<Enrollment>
            //{
            //    new Enrollment { StudentID = 1, CourseID = 2, EnrollmentDate = DateTime.Now },
            //    new Enrollment { StudentID = 1, CourseID = 3, EnrollmentDate = DateTime.Now },
            //    new Enrollment { StudentID = 1, CourseID = 10, EnrollmentDate = DateTime.Now } 
            //};

            //    Instructor_Student_Operations.SaveEnrollment(newEnrollments);

            //    var schedules = new List<Schedule>
            //{
            //    new Schedule
            //    {
            //        InstructorID = 1,
            //        CourseID = 2,
            //        ScheduletDate = DateTime.Parse("2025-10-05")
            //    },
            //    new Schedule
            //    {
            //        InstructorID = 2,
            //        CourseID = 3,
            //        ScheduletDate = DateTime.Parse("2025-10-06")
            //    },
            //    new Schedule
            //    {
            //        InstructorID = 1,
            //        CourseID = 2,
            //        ScheduletDate = DateTime.Parse("2025-10-05") 
            //    }
            //};


            //    Instructor_Student_Operations.SaveSchedule(schedules);
            //Instructor_Student_Operations.SearchScheduleByID(1, "Instructor");

            //Instructor_Student_Operations.SearchScheduleByID(1, "Student");

            //Instructor_Student_Operations.SearchEnrollmentByID(1);
            //Instructor_Student_Operations.SearchData("Student");
            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();


            ///*** Advance Crouse ***\\\

            ///*** Async and Execption Example  ***\\\

            Console.WriteLine("\n--- Async Task Using Exception Handling ---\n");

    //        CancellationTokenSource token = new CancellationTokenSource();

    //        string[] urls =
    //        {
    //    "https://jsonplaceholder.typicode.com/posts/1",
    //    "https://jsonplaceholder.typicode.com/posts/2",
    //    "https://jsonplaceholder.typicode.com/posts/3",
    //    "https://jsonplaceholder.typicode.com/posts/4"
    //};

    //        try
    //        {
    //            Console.WriteLine("Multiple Data Fetching from API...");

    //            Task<string>[] dataFetching = new Task<string>[urls.Length];

    //            for (int i = 0; i < dataFetching.Length; i++)
    //            {
                    
    //                dataFetching[i] = TestApi.asyncdataFetch(urls[i], token.Token);
    //            }

    //            string[] results = await Task.WhenAll(dataFetching);

    //            for (int i = 0; i < results.Length; i++)
    //            {
    //                Console.WriteLine($"Result {i + 1}: {results[i].Substring(0, Math.Min(50, results[i].Length))}...");
    //            }
    //        }
    //        catch (Exception ex)
    //        {
    //            Console.WriteLine("Critical error: " + ex.Message);
    //        }
    //        finally
    //        {
    //            Console.WriteLine("Cleanup finished.");
                
    //        }


    //        ///*** Exention Method and NullableType and Dynamic Examples ***\\\
    //        Console.WriteLine("\n--- Use Extension Method ---\n");
    //        String word = "hello dear how are";
    //        var totalcountchar = word.WordCount();
    //        Console.WriteLine($"Total Word Count  {totalcountchar} and Word is {word}");
    //        ///Nullabletpe 
    //        var nullablevalue = word?.Length;
    //        Console.WriteLine($"Total Word Count Using NullableType {nullablevalue}");
    //        dynamic dynamicvalue = "Hello";
    //        object objectvalue = "Hello";
    //        Console.WriteLine($"Dynamic Value: {dynamicvalue.Length}");  /// no need casting 
    //        Console.WriteLine($"Object Value: {((string)objectvalue).Length}");/// run-time delare datatype: casting required

    //         ///*** Events Examples ***\\\

    //        OrderProcessor setOrder = new OrderProcessor();
    //        EmailService setEmail = new EmailService();
    //        LogService setLog = new LogService();
    //        setOrder.OrderProcessed += setEmail.OnOrderProcessed;
    //        setOrder.OrderProcessed += setLog.OnOrderProcessed;

    //        setOrder.ProcessOrder(101, "Talha Rasheed");
    //        setOrder.ProcessOrder(102, "John Doe");


    //        ///*** Events Using Interface Class ***\\\


    //        Console.WriteLine("\n--- Alram Using Intereface Class ---\n");
    //        IFireAlarm smokeAlarm = new InterfaceSmokeAlarm();
    //        IFireAlarm heatAlarm = new interfaceHeatAlarm();

    //        // Trigger alarms
    //        smokeAlarm.DetectFire("Kitchen");
    //        heatAlarm.DetectFire("Server Room");

    //        //////*** Events Using Inheretence Class ***\\\

    //        Console.WriteLine("\n--- Alaram Using Inheretence Class ---\n");
    //        BaseAlarm smoke = new SmokeAlarm();
    //        BaseAlarm heat = new HeatAlarm();

    //        //  subscribers
    //        People subpeople = new People();
    //        FireDepartment fireDept = new FireDepartment();

    //        // people and firedepaertment set Alaram
    //        smoke.BaseFireDetected += subpeople.OnFireDetected;
    //        smoke.BaseFireDetected += fireDept.OnFireDetected;

    //        heat.BaseFireDetected += subpeople.OnFireDetected;

    //        // fire Event Genrate 
    //        smoke.DetectFire("Kitchen");
    //        Console.WriteLine("\n--- Another Fire ---\n");

    //        ///*** Delagats Examples ***\\\
    //        HelloWorld<int> objHelloWorld = new HelloWorld<int>();
    //        HelloWorld<string> obj1HelloWorld = new HelloWorld<string>();

    //        objHelloWorld.Add(1000);
    //        obj1HelloWorld.Add("hamza");

    //        // Using Dictionary
    //        Dictionary<int, string> dictionayobj = new Dictionary<int, string>();
    //        dictionayobj.Add(12, "Ali");
    //        dictionayobj.Add(13, "Ammad");

    //        // Using Delegate
    //        Operation op;

    //        op = Add;
    //        Console.WriteLine("Addition: " + op(5, 3));

    //        op = Multiply;
    //        Console.WriteLine("Multiplication: " + op(5, 3));

    //        // Display Generic Results
    //        Console.WriteLine("Generic Result (int): " + objHelloWorld.Get());
    //        Console.WriteLine("Generic Result (string): " + obj1HelloWorld.Get());

    //        // Loop through Dictionary
    //        foreach (var kv in dictionayobj)
    //        {
    //            Console.WriteLine("Dictionary Result: " + kv.Key + " -> " + kv.Value);
    //        }

    //        ///*** LinQ and Lambda Querys ***\\\


    //        Console.WriteLine("\n--- Using Linq and Lambda Expressions ---\n");

    //        var bookintro =new AdvanceCrouseIntro().BooksDisplay();
    //        var LamdaCheepBook = bookintro.Where(b => b.Price < 40);
    //        var Linqscheepbook= from b in bookintro where b.Price <40 orderby b.Price select b;
    //        foreach (var v in Linqscheepbook)
    //        {
    //            Console.WriteLine($"Cheep Book: {v.Title} and Price: {v.Price}");
    //            //if (v.Price < 20)
    //            //{
    //            //    Console.WriteLine($"Cheep Book: {v.Title} and Price: {v.Price}");
    //            //}
    //            //else
    //            //{
    //            //    Console.WriteLine($"All Book Here: { v.Title} and Price: {v.Price}");
    //            //}
    //        }


    //        Console.WriteLine("\n--- End of Advance Crouse ---\n");
    //        ///*** The End ***\\\

    //        ///*** Summary Examples and Exercises ***\\\

    //        Console.WriteLine("\n--- Intermeidate Crouse Started  ---\n");

    //        Stack<int> obj = new Stack<int>();
    //        for (int i = 0; i < 10; i++) obj.Push(i);
    //        foreach (var v in obj) Console.WriteLine($"Stack Values: {v}");
    //        Queue<int> obj1 = new Queue<int>();
    //        for (int i = 0; i < 10; i++) obj1.Enqueue(i);
    //        foreach (var v in obj1) Console.WriteLine($"Queue Values: {v}");

    //        var adminPermission = enumClass.admin;
    //        Console.WriteLine($"Admin Permissions: {adminPermission.permissionsdisPlay()} ");
    //        var userPermission = enumClass.read | enumClass.write;
    //        Console.WriteLine($"User Permissions: {userPermission.permissionsdisPlay()} ");

    //        IEnumerable<int> number = new int[] { 1, 2, 3, 4, 5 };
    //        foreach(var n in number)
    //        {
    //            Console.WriteLine($"Nmber {0} : {n}");
    //        }


    //        ///*** Section [2] Includes: Implemenatation about classes, Constractor and Object in Different Ways ***\\\
            
    //        Console.WriteLine("///*** Section [2] Implemenatation about classes, Constractor and Object in Different Ways ***\\\\\\");
    //        Person p =new Person(1, "ali", 30);
    //        Console.WriteLine($"Person ID: {p.Id} Name: {p.Name} and age: {p.Age}");
    //        Person p1 = new Person(1, "hamza", 39);
    //        p1.display();
    //        Person p2 = new Person();
    //        p2.Id = 3;
    //        p2.Name = "haris";
    //        p2.Age = 40;
    //        Console.WriteLine($"Person ID: {p1.Id} Name: {p1.Name} and age: {p2.Age}");
    //        List<Person> people = new List<Person>();


    //        people.Add(new Person(1, "Ali", 30));
    //        people.Add(new Person(2, "Hamza", 39));
    //        people.Add(new Person(3, "Haris", 40));
    //        Person p3 = new Person();
    //        int id = 1; string name = "ali"; int age = 30;
    //        p3.display(people, id, name, age);

    //        ///*** Section [2] Includes: implementation about Access Modifier and Inheretince ***\\\
    //        Console.WriteLine("///*** Section [2] implementation about Access Modifier and Inheretince ***\\\\\\");
    //        Employee.name = "Hamza";

    //        List<Order> Employees = new List<Order>()
    //        {
    //            new Order(1, 25, 5000),
    //            new Order(2, 30, 6000),
    //            new Order(3, 28, 5500)
    //        };

    //        foreach (var person in Employees)
    //        {

    //            person.PersonDetails();
    //        }

    //        ///*** Section [2] Includes: Example Using indexe and Dictionary ***\\\
    //        Console.WriteLine("///*** Section [2] Example Using indexe and Dictionary ***\\\\\\");

    //        HelloWorld Hello = new HelloWorld();
    //        Hello[1] = "hamza";
    //        HelloWorld p9 = new HelloWorld();

    //        foreach (var item in p9.books)
    //        {
    //            Console.WriteLine($"Key: {item.Key}, Value: {item.Value}");
    //        }


    //        Console.WriteLine("Array Details: " + Hello.Arrays);

    //        ///*** Section [4] Includes: inheritence Example ***\\\
    //        Console.WriteLine("///*** Section [4] Includes: inheritence Example ***\\\\\\");

    //        List<Employees> employees = new List<Employees>
    //    {
    //        new EmployeeType(1, "Alice", "Full"),
    //        new EmployeeType(2, "Bob", "Contratual"),
    //        new EmployeeType(3, "Charlie", "Part-Time")
    //    };

    //        foreach (var emp in employees)
    //        {
    //            emp.ShowEmployeeDetails();

    //        }

    //        EmployeeType returnsalary = new EmployeeType(4, "hamza", "Full");


    //        decimal empSalary = returnsalary.ShowEmployeeDetails();


    //        decimal bonus = empSalary * 0.1m;
    //        Console.WriteLine("Bonus: " + bonus);




    //        ///*** Section [5] Includes : Abtract Methods and Inheretence ***\\\

    //        Console.WriteLine(" ///*** Section 5 Includes : Abtract Methods and Inheretence ***\\\\\\ ");
    //        List<Shape> shapes = new List<Shape>
    //    {
    //        new Cricle("Circle A", 5),  
    //        new Triangle("Triangle X", 4, 6),
    //        new Cricle("Circle B", 3),
    //        new Triangle("Triangle Y", 8, 5)
    //    };
    //        foreach (var shape in shapes)
    //        {
    //            shape.Draw();
    //            Console.WriteLine($"Area: {shape.Area():F2}\n");
    //        }

    //        ///*** Section [6] Includes : Simple Interface Example ***\\\

    //        Console.WriteLine(" ///*** Section 6 Includes : Includes : Simple Interface Example ***\\\\\\ ");

    //        TotalBranches branch1 = new TotalBranches("Toyota");
    //        branch1.DisplayAddressBranch1();

    //        TotalBranches branch2 = new TotalBranches("Honda");
    //        branch2.DisplayAddressBranch2();


    //        Console.WriteLine(" ///*** End of Intermediate Crouse ***\\\\\\ ");
    //        Console.ReadLine();
        }
    }
}
