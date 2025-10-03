using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1.Model
{
    // ---------------- User ----------------
    public class User
    {
        public int UserID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }

    // ---------------- Department ----------------
    public class Department
        {
            public int DeptID { get; set; }
            public string Name { get; set; }
            public string Address { get; set; }

         
            
        }

        // ---------------- Student ----------------
        public class Student
        {
            public int StudentID { get; set; }
            public int UserID { get; set; }
            public int DepartmentID { get; set; }
            public string FullName { get; set; }
            public string Address { get; set; }
          
        }

        // ---------------- Instructor ----------------
        public class Instructor
        {
            public int InstructorID { get; set; }
            public int UserID { get; set; }
            public int DeptID { get; set; }
            public string FullName { get; set; }
             public string Address { get; set; }

    }

        // ---------------- Course ----------------
        public class Course
        {
            public int CourseID { get; set; }
            public int DeptID { get; set; }
            public string Title { get; set; }
            public int CreditsHours { get; set; }

        }

        // ---------------- Enrollment ----------------
        public class Enrollment
        {
            public int EnrollmentID { get; set; }
            public int StudentID { get; set; }

            public int CourseID { get; set; }

            public DateTime EnrollmentDate { get; set; }
        }

        // ---------------- Schedule ----------------
        public class Schedule
        {
            public int ScheduleID { get; set; }
            public int CourseID { get; set; }
            public int InstructorID { get; set; }
            public DateTime ScheduletDate { get; set; }

        }

      
    

}
