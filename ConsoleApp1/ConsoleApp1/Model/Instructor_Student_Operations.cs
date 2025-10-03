using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;


namespace ConsoleApp1.Model
{

    public class Instructor_Student_Operations
    {
        private static readonly string projectFolder = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\.."));
        private static readonly string assetsFolder = Path.Combine(projectFolder, "Assets");
        private static readonly string studentCourseFile = Path.Combine(assetsFolder, "StudentCoursesData.txt");

        static Instructor_Student_Operations()
        {
            Directory.CreateDirectory(assetsFolder);
        }
        public static List<string> fileloading()
        {
            if (!File.Exists(Instructor_Student_Operations.studentCourseFile))
                File.Create(Instructor_Student_Operations.studentCourseFile).Close();

            return File.ReadAllLines(Instructor_Student_Operations.studentCourseFile).ToList();
        }
        public static List<Department> LoadDepartments(List<string> fileload)
        {
            return fileload
                .Where(l => l.StartsWith("Dept|"))
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new Department
                    {
                        DeptID = int.Parse(parts[1]),
                        Name = parts[2],
                        Address = parts[3]
                    };
                })
                .ToList();
        }
        public static List<User> LoadUsers(List<string> fileload)
        {
            return fileload
                .Where(l => l.StartsWith("User|"))
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new User
                    {
                        UserID = int.Parse(parts[1]),
                        Email = parts[2],
                        Password = parts[3],
                        Role = parts[4]
                    };
                })
                .ToList();
        }
        public static List<Instructor> LoadInstructors(List<string> fileload)
        {
            return fileload
                .Where(l => l.StartsWith("Instr|"))
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new Instructor
                    {
                        InstructorID = int.Parse(parts[1]),
                        FullName = parts[2],
                        UserID = int.Parse(parts[3]),
                        DeptID = int.Parse(parts[4]),
                        Address = parts[5]
                    };
                })
                .ToList();
        }
        public static List<Student> LoadStudents(List<string> fileload)
        {
            return fileload
                .Where(l => l.StartsWith("Stu|"))
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new Student
                    {
                        StudentID = int.Parse(parts[1]),
                        FullName = parts[2],
                        UserID = int.Parse(parts[3]),
                        DepartmentID = int.Parse(parts[4]),
                        Address = parts[5]
                    };
                })
                .ToList();
        }
        public static List<Course> LoadCourses(List<string> fileload)
        {
            return fileload
                .Where(l => l.StartsWith("Course|"))
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new Course
                    {
                        CourseID = int.Parse(parts[1]),
                        DeptID = int.Parse(parts[2]),
                        Title = parts[3],
                        CreditsHours = int.Parse(parts[4])
                    };
                })
                .ToList();
        }
        public static List<Enrollment> LoadEnrollments(List<string> fileload)
        {
            return fileload
                .Where(l => l.StartsWith("Enrollment|"))
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new Enrollment
                    {
                        EnrollmentID = int.Parse(parts[1]),
                        StudentID = int.Parse(parts[2]),
                        CourseID = int.Parse(parts[3]),
                        EnrollmentDate = DateTime.Parse(parts[4])
                    };
                })
                .ToList();
        }
        public static List<Schedule> LoadSchedules(List<string> fileload)
        {
            return fileload
                .Where(l => l.StartsWith("Schedule|"))
                .Select(line =>
                {
                    var parts = line.Split('|');
                    return new Schedule
                    {
                        ScheduleID = int.Parse(parts[1]),
                        InstructorID = int.Parse(parts[2]),
                        CourseID = int.Parse(parts[3]),
                        ScheduletDate = DateTime.Parse(parts[4])
                    };
                })
                .ToList();
        }
        private static void RemoveAndWrite(List<string> fileload, string prefix, int id, string entityName)
        {
            var records = fileload.Where(l => l.StartsWith(prefix)).ToList();
            var existing = records.FirstOrDefault(r => r.Split('|')[1] == id.ToString());

            if (existing != null)
            {
                records.Remove(existing);
                WriteBack(fileload, records, prefix);
                Console.WriteLine($"{entityName} {id} deleted successfully.");
            }
            else
            {
                Console.WriteLine($"{entityName} {id} not found.");
            }
        }
        public static void WriteBack(List<string> alllines, List<string> updatedline, string type)
        {
            var otherLines = alllines.Where(l => !l.StartsWith(type)).ToList();

            var allLines = new List<string>();
            allLines.AddRange(otherLines); 
            allLines.AddRange(updatedline);  

            File.WriteAllLines(Instructor_Student_Operations.studentCourseFile, allLines);
        }


        public static void ShowDepartment(List<Department> dept)
        {
            var lines = fileloading();

            var showdata = lines.Where(d => d.StartsWith("Dept|")).Select(l =>
            {
                var items = l.Split('|');
                return new Department
                {
                    DeptID = int.Parse(items[1]),
                    Name = items[2].ToString(),
                    Address = items[3].ToString(),
                };

            }).ToList();
            Console.WriteLine("Departments\n");
            foreach (var d in showdata)
                Console.WriteLine($"{d.DeptID} | {d.Name} | {d.Address}");

        }
        public static void ShowDepartmentWithCourses()
        {
            var lines = fileloading();


            var departments = LoadDepartments(lines);


            var courses = LoadCourses(lines);

            Console.WriteLine("Departments and their Courses:\n");

            foreach (var dept in departments)
            {
                Console.WriteLine($"Department ID: {dept.DeptID}, Name: {dept.Name}, Address: {dept.Address}");


                var deptCourses = courses.Where(c => c.DeptID == dept.DeptID).ToList();

                if (deptCourses.Any())
                {
                    Console.WriteLine("   Courses:");
                    foreach (var course in deptCourses)
                    {
                        Console.WriteLine($"      - {course.Title} ({course.CreditsHours} Credit Hours)");
                    }
                }
                else
                {
                    Console.WriteLine("   No courses found for this department.");
                }

                Console.WriteLine();
            }
        }
        public static void SearchEnrollmentByID(int ID)
        {
            try
            {
                var fileload = fileloading();


                var allDepartments = LoadDepartments(fileload);


                var allUsers = LoadUsers(fileload);


                var allStudents = fileload
                    .Where(l => l.StartsWith("Stu|"))
                    .Select(line =>
                    {
                        var parts = line.Split('|');
                        var email = parts[3];


                        var user = allUsers.FirstOrDefault(u => u.Email == email);


                        var dep = allDepartments.FirstOrDefault(d => d.Name == parts[6]);

                        return new Student
                        {
                            StudentID = int.Parse(parts[1]),
                            FullName = parts[2],
                            UserID = user?.UserID ?? 0,
                            Address = parts[5],
                            DepartmentID = dep?.DeptID ?? 0
                        };
                    })
                    .ToList();

                var allCourses = fileload
                    .Where(l => l.StartsWith("Course|"))
                    .Select(line =>
                    {
                        var parts = line.Split('|');
                        return new Course
                        {
                            CourseID = int.Parse(parts[1]),
                            DeptID = int.Parse(parts[2]),
                            Title = parts[3],
                            CreditsHours = int.Parse(parts[4])
                        };
                    })
                    .ToList();


                var allEnrollments = fileload
                    .Where(l => l.StartsWith("Enrollment|"))
                    .Select(line =>
                    {
                        var parts = line.Split('|');
                        return new Enrollment
                        {
                            EnrollmentID = int.Parse(parts[1]),
                            StudentID = int.Parse(parts[2]),
                            CourseID = int.Parse(parts[3]),
                            EnrollmentDate = DateTime.Parse(parts[4])
                        };
                    })
                    .ToList();


                var student = allStudents.FirstOrDefault(s => s.StudentID == ID);

                if (student != null)
                {
                    var studentEnrollments = allEnrollments
                        .Where(e => e.StudentID == ID)
                        .ToList();

                    Console.WriteLine($"Enrollments for Student: {student.FullName} (ID: {student.StudentID}, UserID: {student.UserID})");

                    foreach (var enrollment in studentEnrollments)
                    {
                        var course = allCourses.FirstOrDefault(c => c.CourseID == enrollment.CourseID);
                        Console.WriteLine($"Course: {course?.Title}, Credit Hours: {course?.CreditsHours}, Date: {enrollment.EnrollmentDate}");
                    }
                }
                else
                {
                    Console.WriteLine("Student not found!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching Enrollment: " + ex.Message);
            }
        }




        public static void SaveDepartments(List<Department> newDepartments)
        {
            var fileload = fileloading();
            var deptlines = fileload.Where(line => line.StartsWith("Dept|")).ToList();

            foreach (var d in newDepartments)
            {
                var newDeptLine = $"Dept|{d.DeptID}|{d.Name.ToLower()}|{d.Address.ToLower()}";
                var exists = deptlines.Any(dept =>
                {
                    var parts = dept.Split('|');
                    return parts[1] == d.DeptID.ToString();
                });

                if (!exists) 
                {
                    deptlines.Add(newDeptLine);
                }
            }
            WriteBack(fileload, deptlines, "Dept|");
        }
        public static void SaveStudent(Student student,User user)
        {
            try
            {
                var fileload = fileloading();
                var getalldepartments = LoadDepartments(fileload);
                var checkdeparments = getalldepartments.Any(d => d.DeptID == student.DepartmentID);
                if (!checkdeparments)
                {
                    Console.WriteLine($"Enter a correct DepartmentID: {student}");
                    return;
                }
                var getdeptname = getalldepartments.First(d => d.DeptID == student.DepartmentID).Name;
                var checkuser = fileload.Where(u => u.StartsWith("User|")).ToList();
                var checkstudent = fileload.Where(s => s.StartsWith("Stu|")).ToList();
                var userExist = checkuser.Any(u =>
                {
                    var parts = u.Split("|");
                    return parts[1] == user.UserID.ToString();
                });
                var StudentExist = checkstudent.Any(u =>
                {
                    var parts = u.Split("|");
                    return parts[1] == student.StudentID.ToString() || parts[3] == user.Email;
                });
                if (!userExist)
                {
                    var newUser = $"User|{user.UserID}|{user.Email}|{user.Password}|{user.Role}";
                    checkuser.Add(newUser);
                }
                else
                {
                    Console.WriteLine($"User with ID {user.UserID} already exists. Skipping user creation.");
                    return;
                }
                if (!StudentExist)
                {
                    var newStudentLine = $"Stu|{student.StudentID}|{student.FullName.ToLower()}|{user.Email}|{user.Password}|{student.Address.ToLower()}|{getdeptname.ToLower()}";
                    checkstudent.Add(newStudentLine);
                }
                else
                {
                    Console.WriteLine($"Student with ID {user.UserID} already exists. Skipping user creation.");
                    return;
                }
                var updatesFile = new List<String>();
                updatesFile.AddRange(checkuser);
                updatesFile.AddRange(checkstudent);
                WriteBack(fileload, updatesFile, "User|");
                WriteBack(fileload, updatesFile, "Stu");

                Console.WriteLine($"Student {student.FullName} and User {user.Email} added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error:" + ex.Message);
            }
        }
        public static void SaveInstructor(Instructor instructor, User user)
        {
            try
            {
                var fileload = fileloading();
                var getalldepartments = LoadDepartments(fileload);

                var dept = getalldepartments.FirstOrDefault(d => d.DeptID == instructor.DeptID);
                if (dept == null)
                {
                    Console.WriteLine($"Department with ID {instructor.DeptID} not found.");
                    return;
                }

                var checkuser = fileload.Where(u => u.StartsWith("User|")).ToList();
                var checkinstructor = fileload.Where(s => s.StartsWith("Instr|")).ToList();

                var userExist = checkuser.Any(u =>
                {
                    var parts = u.Split('|');
                    return parts[1] == user.UserID.ToString() || parts[2] == user.Email;
                });

                var instructorExist = checkinstructor.Any(i =>
                {
                    var parts = i.Split('|');
                    return parts[1] == instructor.InstructorID.ToString() || parts[3] == user.Email;
                });

                if (userExist)
                {
                    Console.WriteLine($"User with ID {user.UserID} or Email {user.Email} already exists. Skipping user creation.");
                    return;
                }

                if (instructorExist)
                {
                    Console.WriteLine($"Instructor with ID {instructor.InstructorID} or Email {user.Email} already exists. Skipping instructor creation.");
                    return;
                }

                
                var newUser = $"User|{user.UserID}|{user.Email}|{user.Password}|{user.Role}";
                checkuser.Add(newUser);

                var newInstructorLine = $"Instr|{instructor.InstructorID}|{instructor.FullName}|{user.Email}|{user.Password}|{instructor.Address.ToLower()}|{dept.Name.ToLower()}";
                checkinstructor.Add(newInstructorLine);

               
                var updatesFile = new List<string>();
                updatesFile.AddRange(checkuser);
                updatesFile.AddRange(checkinstructor);

                WriteBack(fileload, updatesFile, "User|");
                WriteBack(fileload, updatesFile, "Instr|");

                Console.WriteLine($"Instructor {instructor.FullName} and User {user.Email} added successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        public static void SaveCourse(List<AddCrouse> courses, string DepartmentName)
        {
            try
            {
                var fileload = fileloading();


                var getalldepartments = LoadDepartments(fileload);

                
                var dept = getalldepartments.FirstOrDefault(d => d.Name.Equals(DepartmentName.ToLower(), StringComparison.OrdinalIgnoreCase));
                if (dept == null)
                {
                    Console.WriteLine($"Please enter an existing Department: {DepartmentName}");
                    return;
                }


                var getallcourses = LoadCourses(fileload);

                
                int lastCourseId = fileload
                    .Where(l => l.StartsWith("Course|"))
                    .Select(line => int.Parse(line.Split('|')[1]))
                    .DefaultIfEmpty(1) 
                    .Max();

                var addnewcrouses = new List<string>();

                foreach (var course in courses)
                {
                    
                    var exists = getallcourses.Any(c =>
                        c.Title.Equals(course.Title, StringComparison.OrdinalIgnoreCase) && c.DeptID == dept.DeptID);

                    if (!exists)
                    {
                        
                        lastCourseId++;

                        var newCourseLine = $"Course|{lastCourseId}|{dept.DeptID}|{course.Title.ToLower()}|{course.CreditsHours}";
                        addnewcrouses.Add(newCourseLine);

                        Console.WriteLine($"Added Course: {course.Title} ({course.CreditsHours} Credit Hours) in Department {dept.Name} with CourseID {lastCourseId}");
                    }
                    else
                    {
                        Console.WriteLine($"Course '{course.Title}' already exists in Department {dept.Name}. Skipping...");
                    }
                }

                
                if (addnewcrouses.Any())
                {
                    var allCoursesLines = fileload.Where(l => l.StartsWith("Course|")).ToList();
                    allCoursesLines.AddRange(addnewcrouses);

                    WriteBack(fileload, allCoursesLines, "Course|");
                    Console.WriteLine("Courses saved successfully.");
                }
                else
                {
                    Console.WriteLine("No new courses to add.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving courses: " + ex.Message);
            }
        }
        public static void SaveEnrollment(List<Enrollment> enrollment)
        {
            try
            {
                var fileload = fileloading();

                var GetAllEnrollments = LoadEnrollments(fileload);
                var allDepartments = LoadDepartments(fileload);
                var allStudents = LoadStudents(fileload);
                var allCourses = LoadCourses(fileload);

                var addenrollment = new List<string>();

                int lastId = fileload
                    .Where(l => l.StartsWith("Enrollment|"))
                    .Select(line => int.Parse(line.Split('|')[1]))
                    .DefaultIfEmpty(0)
                    .Max();

                foreach (var enroll in enrollment)
                {

                    var student = allStudents.FirstOrDefault(s => s.StudentID == enroll.StudentID);
                    var course = allCourses.FirstOrDefault(c => c.CourseID == enroll.CourseID);

                    if (student == null || course == null)
                    {
                        Console.WriteLine($"Invalid Enrollment: Student {enroll.StudentID}  Course {enroll.CourseID} Not Found.");
                        continue;
                    }
                    if (student.DepartmentID != course.DeptID)
                    {
                        Console.WriteLine($"Invalid Enrollment : Student {enroll.StudentID} (Dept {student.DepartmentID}) aur Course {enroll.CourseID} (Dept {course.DeptID}) are not matchs .");
                        continue;
                    }

                    bool alreadyExists = GetAllEnrollments.Any(e =>
                        e.StudentID == enroll.StudentID &&
                        e.CourseID == enroll.CourseID);

                    if (!alreadyExists)
                    {
                        lastId++;
                        var newLine = $"Enrollment|{lastId}|{enroll.StudentID}|{enroll.CourseID}|{enroll.EnrollmentDate}";
                        addenrollment.Add(newLine);

                        
                        GetAllEnrollments.Add(new Enrollment
                        {
                            EnrollmentID = lastId,
                            StudentID = enroll.StudentID,
                            CourseID = enroll.CourseID,
                            EnrollmentDate = enroll.EnrollmentDate
                        });
                    }
                    else
                    {
                        Console.WriteLine($"Student {enroll.StudentID} already enrolled in Course {enroll.CourseID}, skipping...");
                    }
                }

                if (addenrollment.Any())
                {
                    var allLines = fileload.Where(l => l.StartsWith("Enrollment|")).ToList();
                    allLines.AddRange(addenrollment);

                    WriteBack(fileload, allLines, "Enrollment|");
                    Console.WriteLine("New enrollments saved successfully.");
                }
                else
                {
                    Console.WriteLine("No new enrollments to save.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving enrollments: " + ex.Message);
            }
        }
        public static void SaveSchedule(List<Schedule> schedules)
        {
            try
            {
                var fileload = fileloading();


                var allDepartments = LoadDepartments(fileload);


                var allInstructors = LoadInstructors(fileload);

                
                var allCourses = LoadCourses(fileload);


                var GetAllSchedules = LoadSchedules(fileload);

                var newSchedules = new List<string>();

                int lastId = fileload
                    .Where(l => l.StartsWith("Schedule|"))
                    .Select(line => int.Parse(line.Split('|')[1]))
                    .DefaultIfEmpty(0)
                    .Max();

                foreach (var schedule in schedules)
                {
                    var instructor = allInstructors.FirstOrDefault(i => i.InstructorID == schedule.InstructorID);
                    var course = allCourses.FirstOrDefault(c => c.CourseID == schedule.CourseID);

                    if (instructor == null || course == null)
                    {
                        Console.WriteLine($"Invalid Schedule: Instructor {schedule.InstructorID} ya Course {schedule.CourseID} not found.");
                        continue;
                    }

                    
                    if (instructor.DeptID != course.DeptID)
                    {
                        Console.WriteLine($"Invalid Schedule: Instructor {instructor.InstructorID} (Dept {instructor.DeptID}) aur Course {course.CourseID} (Dept {course.DeptID}) are not match.");
                        continue;
                    }

                   
                    bool alreadyExists = GetAllSchedules.Any(s =>
                        s.InstructorID == schedule.InstructorID &&
                        s.CourseID == schedule.CourseID &&
                        s.ScheduletDate.Date == schedule.ScheduletDate.Date);

                    if (!alreadyExists)
                    {
                        lastId++;
                        var newLine = $"Schedule|{lastId}|{schedule.InstructorID}|{schedule.CourseID}|{schedule.ScheduletDate}";
                        newSchedules.Add(newLine);

                        GetAllSchedules.Add(new Schedule
                        {
                            ScheduleID = lastId,
                            InstructorID = schedule.InstructorID,
                            CourseID = schedule.CourseID,
                            ScheduletDate = schedule.ScheduletDate
                        });

                        Console.WriteLine($"New Schedule Added: Instructor {instructor.FullName} - Course {course.Title} on {schedule.ScheduletDate}");
                    }
                    else
                    {
                        Console.WriteLine($"Schedule already exists for Instructor {schedule.InstructorID} and Course {schedule.CourseID}, skipping...");
                    }
                }

                
                if (newSchedules.Any())
                {
                    var allLines = fileload.Where(l => l.StartsWith("Schedule|")).ToList();
                    allLines.AddRange(newSchedules);

                    WriteBack(fileload, allLines, "Schedule|");
                    Console.WriteLine("New schedules saved successfully.");
                }
                else
                {
                    Console.WriteLine("No new schedules to save.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while saving Schedule: " + ex.Message);
            }
        }


        public static void SearchByID(int ID, string Type)
        {
            try
            {
                var fileload = fileloading();

                var allDepartments = LoadDepartments(fileload);

                var allUsers = LoadUsers(fileload);

                var allInstructors = LoadInstructors(fileload);

                var allStudents = LoadStudents(fileload);

                var allCourses = LoadCourses(fileload);

                var allEnrollments = LoadEnrollments(fileload);

                var allSchedules = LoadSchedules(fileload);

                switch (Type)
                {
                    case "Department":
                        var dept = allDepartments.FirstOrDefault(d => d.DeptID == ID);
                        Console.WriteLine(dept != null
                            ? $"DeptID: {dept.DeptID}, Name: {dept.Name}, Address: {dept.Address}"
                            : "Department not found!");
                        break;

                    case "User":
                        var user = allUsers.FirstOrDefault(u => u.UserID == ID);
                        Console.WriteLine(user != null
                            ? $"UserID: {user.UserID}, Email: {user.Email}, Role: {user.Role}"
                            : "User not found!");
                        break;

                    case "Student":
                        var student = allStudents.FirstOrDefault(s => s.StudentID == ID);
                        if (student != null)
                        {
                            Console.WriteLine($"StudentID: {student.StudentID}, Name: {student.FullName}, DeptID: {student.DepartmentID}, Address: {student.Address}");
                            var enrolls = allEnrollments.Where(e => e.StudentID == student.StudentID).ToList();
                            foreach (var e in enrolls)
                            {
                                var c = allCourses.FirstOrDefault(c => c.CourseID == e.CourseID);
                                Console.WriteLine($"  Enrolled in: {c?.Title} on {e.EnrollmentDate}");
                            }
                        }
                        else Console.WriteLine("Student not found!");
                        break;

                    case "Instructor":
                        var instr = allInstructors.FirstOrDefault(i => i.InstructorID == ID);
                        if (instr != null)
                        {
                            Console.WriteLine($"InstructorID: {instr.InstructorID}, Name: {instr.FullName}, DeptID: {instr.DeptID}, Address: {instr.Address}");
                            var schedules = allSchedules.Where(s => s.InstructorID == instr.InstructorID).ToList();
                            foreach (var s in schedules)
                            {
                                var c = allCourses.FirstOrDefault(c => c.CourseID == s.CourseID);
                                Console.WriteLine($"  Teaching: {c?.Title} on {s.ScheduletDate}");
                            }
                        }
                        else Console.WriteLine("Instructor not found!");
                        break;

                    case "Course":
                        var course = allCourses.FirstOrDefault(c => c.CourseID == ID);
                        Console.WriteLine(course != null
                            ? $"CourseID: {course.CourseID}, Title: {course.Title}, CreditHours: {course.CreditsHours}, DeptID: {course.DeptID}"
                            : "Course not found!");
                        break;

                    case "Enrollment":
                        var enrollment = allEnrollments.FirstOrDefault(e => e.EnrollmentID == ID);
                        if (enrollment != null)
                        {
                            var s = allStudents.FirstOrDefault(st => st.StudentID == enrollment.StudentID);
                            var c = allCourses.FirstOrDefault(co => co.CourseID == enrollment.CourseID);
                            Console.WriteLine($"EnrollmentID: {enrollment.EnrollmentID}, Student: {s?.FullName}, Course: {c?.Title}, Date: {enrollment.EnrollmentDate}");
                        }
                        else Console.WriteLine("Enrollment not found!");
                        break;

                    case "Schedule":
                        var schedule = allSchedules.FirstOrDefault(s => s.ScheduleID == ID);
                        if (schedule != null)
                        {
                            var i = allInstructors.FirstOrDefault(ins => ins.InstructorID == schedule.InstructorID);
                            var c = allCourses.FirstOrDefault(co => co.CourseID == schedule.CourseID);
                            Console.WriteLine($"ScheduleID: {schedule.ScheduleID}, Course: {c?.Title}, Instructor: {i?.FullName}, Date: {schedule.ScheduletDate}");
                        }
                        else Console.WriteLine("Schedule not found!");
                        break;

                    default:
                        Console.WriteLine("Invalid Type specified!");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while searching: " + ex.Message);
            }
        }



        public static void ShowData(string type)
        {
            try
            {
                var fileload = fileloading();

                if (type == "User")
                {
                    var allUsers = LoadUsers(fileload);

                    Console.WriteLine("---- Users ----");
                    foreach (var u in allUsers)
                    {
                        Console.WriteLine($"ID: {u.UserID}, Email: {u.Email}, Role: {u.Role}");
                    }
                }
                else if (type == "Student")
                {
                    var allStudents = LoadStudents(fileload);
                    Console.WriteLine("---- Students ----");
                    foreach (var s in allStudents)
                    {
                        Console.WriteLine($"ID: {s.StudentID}, Name: {s.FullName}, Address: {s.Address}, DeptID: {s.DepartmentID}");
                    }
                }
                else if (type == "Instructor")
                {
                    var allInstructors = LoadInstructors(fileload);

                    Console.WriteLine("---- Instructors ----");
                    foreach (var i in allInstructors)
                    {
                        Console.WriteLine($"ID: {i.InstructorID}, Name: {i.FullName}, Address: {i.Address}, DeptID: {i.DeptID}");
                    }
                }
                else if (type == "Department")
                {
                    var allDepartments = LoadDepartments(fileload);

                    Console.WriteLine("---- Departments ----");
                    foreach (var d in allDepartments)
                    {
                        Console.WriteLine($"ID: {d.DeptID}, Name: {d.Name}, Address: {d.Address}");
                    }
                }
                else if (type == "Course")
                {
                    var allCourses = LoadCourses(fileload);

                    Console.WriteLine("---- Courses ----");
                    foreach (var c in allCourses)
                    {
                        Console.WriteLine($"ID: {c.CourseID}, Title: {c.Title}, Credit Hours: {c.CreditsHours}, DeptID: {c.DeptID}");
                    }
                }
                else if (type == "Enrollment")
                {
                    var allEnrollments = LoadEnrollments(fileload);

                    Console.WriteLine("---- Enrollments ----");
                    foreach (var e in allEnrollments)
                    {
                        Console.WriteLine($"ID: {e.EnrollmentID}, StudentID: {e.StudentID}, CourseID: {e.CourseID}, Date: {e.EnrollmentDate}");
                    }
                }
                else if (type == "Schedule")
                {
                    var allSchedules = LoadSchedules(fileload);

                    Console.WriteLine("---- Schedules ----");
                    foreach (var s in allSchedules)
                    {
                        Console.WriteLine($"ID: {s.ScheduleID}, InstructorID: {s.InstructorID}, CourseID: {s.CourseID}, Date: {s.ScheduletDate}");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid type! Please enter one of: User, Student, Instructor, Department, Course, Enrollment, Schedule.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error while showing data: " + ex.Message);
            }
        }


        public static void DeleteRecord(string type, int id)
        {
            var fileload = fileloading();

            switch (type.ToLower())
            {
                case "department":
                    var deptName = LoadDepartments(fileload).FirstOrDefault(d => d.DeptID == id)?.Name;

                    var hasStudents = fileload.Any(l => l.StartsWith("Stu|") && l.Split('|')[6] == deptName);
                    var hasInstructors = fileload.Any(l => l.StartsWith("Instr|") && l.Split('|')[6] == deptName);
                    var hasCourses = fileload.Any(l => l.StartsWith("Course|") && l.Split('|')[2] == id.ToString());

                    if (hasStudents || hasInstructors || hasCourses)
                    {
                        Console.WriteLine($"Department {id} cannot be deleted (referenced by other records).");
                        return;
                    }

                    RemoveAndWrite(fileload, "Dept|", id, "Department");
                    break;

                case "student":
                    var hasEnrollment = fileload.Any(l => l.StartsWith("Enrollment|") && l.Split('|')[2] == id.ToString());
                    if (hasEnrollment)
                    {
                        Console.WriteLine($"Student {id} cannot be deleted (enrolled in a course).");
                        return;
                    }

                    RemoveAndWrite(fileload, "Stu|", id, "Student");
                    break;

                case "instructor":
                    var hasSchedule = fileload.Any(l => l.StartsWith("Schedule|") && l.Split('|')[1] == id.ToString());
                    if (hasSchedule)
                    {
                        Console.WriteLine($"Instructor {id} cannot be deleted (assigned to a schedule).");
                        return;
                    }

                    RemoveAndWrite(fileload, "Instr|", id, "Instructor");
                    break;

                case "course":
                    var hasEnrollmentCourse = fileload.Any(l => l.StartsWith("Enrollment|") && l.Split('|')[3] == id.ToString());
                    var hasScheduleCourse = fileload.Any(l => l.StartsWith("Schedule|") && l.Split('|')[2] == id.ToString());

                    if (hasEnrollmentCourse || hasScheduleCourse)
                    {
                        Console.WriteLine($"Course {id} cannot be deleted (used in enrollment/schedule).");
                        return;
                    }

                    RemoveAndWrite(fileload, "Course|", id, "Course");
                    break;

                case "enrollment":
                    RemoveAndWrite(fileload, "Enrollment|", id, "Enrollment");
                    break;

                case "schedule":
                    RemoveAndWrite(fileload, "Schedule|", id, "Schedule");
                    break;

                default:
                    Console.WriteLine("Invalid type specified.");
                    break;
            }
        }

        public static void UpdateDepartment(int deptId, string newName, string newAddress)
        {
            var fileload = fileloading();
            var depts = fileload.Where(l => l.StartsWith("Dept|")).ToList();
            var existing = depts.FirstOrDefault(d => d.Split('|')[1] == deptId.ToString());

            if (existing != null)
            {
                depts.Remove(existing);
                depts.Add($"Dept|{deptId}|{newName}|{newAddress}");
                WriteBack(fileload, depts, "Dept|");
                Console.WriteLine($"Department {deptId} updated.");
            }
        }

        public static void UpdateStudent(int studentId, string newName, string newAddress, int newDeptId, int newUserId)
        {
            var fileload = fileloading();
            var students = fileload.Where(l => l.StartsWith("Stu|")).ToList();
            var existing = students.FirstOrDefault(s => s.Split('|')[1] == studentId.ToString());

            if (existing != null)
            {
                students.Remove(existing);
                students.Add($"Stu|{studentId}|{newName}|{newUserId}|{newDeptId}|{newAddress}");
                WriteBack(fileload, students, "Stu|");
                Console.WriteLine($"Student {studentId} updated.");
            }
        }

        public static void UpdateInstructor(int instructorId, string newName, string newAddress, int newDeptId, int newUserId)
        {
            var fileload = fileloading();
            var instructors = fileload.Where(l => l.StartsWith("Instr|")).ToList();
            var existing = instructors.FirstOrDefault(i => i.Split('|')[1] == instructorId.ToString());

            if (existing != null)
            {
                instructors.Remove(existing);
                instructors.Add($"Instr|{instructorId}|{newName}|{newUserId}|{newDeptId}|{newAddress}");
                WriteBack(fileload, instructors, "Instr|");
                Console.WriteLine($"Instructor {instructorId} updated.");
            }
        }

        public static void UpdateCourse(int courseId, int newDeptId, string newTitle, int newCreditHours)
        {
            var fileload = fileloading();
            var courses = fileload.Where(l => l.StartsWith("Course|")).ToList();
            var existing = courses.FirstOrDefault(c => c.Split('|')[1] == courseId.ToString());

            if (existing != null)
            {
                courses.Remove(existing);
                courses.Add($"Course|{courseId}|{newDeptId}|{newTitle}|{newCreditHours}");
                WriteBack(fileload, courses, "Course|");
                Console.WriteLine($"Course {courseId} updated.");
            }
        }

        public static void UpdateEnrollment(int enrollmentId, int newStudentId, int newCourseId, DateTime newDate)
        {
            var fileload = fileloading();
            var enrollments = fileload.Where(l => l.StartsWith("Enrollment|")).ToList();
            var existing = enrollments.FirstOrDefault(e => e.Split('|')[1] == enrollmentId.ToString());

            if (existing != null)
            {
                enrollments.Remove(existing);
                enrollments.Add($"Enrollment|{enrollmentId}|{newStudentId}|{newCourseId}|{newDate}");
                WriteBack(fileload, enrollments, "Enrollment|");
                Console.WriteLine($"Enrollment {enrollmentId} updated.");
            }
        }

        public static void UpdateSchedule(int scheduleId, int newCourseId, int newInstructorId, DateTime newDate)
        {
            var fileload = fileloading();
            var schedules = fileload.Where(l => l.StartsWith("Schedule|")).ToList();
            var existing = schedules.FirstOrDefault(s => s.Split('|')[1] == scheduleId.ToString());

            if (existing != null)
            {
                schedules.Remove(existing);
                schedules.Add($"Schedule|{scheduleId}|{newInstructorId}|{newCourseId}|{newDate}");
                WriteBack(fileload, schedules, "Schedule|");
                Console.WriteLine($"Schedule {scheduleId} updated.");
            }
        }


    }
}
