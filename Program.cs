using System;
using System.Collections.Generic;
using System.Linq;
using attendanceDataService;
using attendanceAppService;
using AttendanceModels;

namespace attendance
{
    class Program
    {
        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }

        static string? Login()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== RAVE'S ATTENDANCE SYSTEM =====\n");
                Console.WriteLine("1. Admin\n2. Student\n3. Exit");
                Console.Write("Choice: ");

                string c = (Console.ReadLine() ?? "").Trim();

                if (c == "3") return null;

                Console.Write("Enter Username: ");
                string u = (Console.ReadLine() ?? "").Trim();

                Console.Write("Enter Password: ");
                string p = (Console.ReadLine() ?? "").Trim();

                if (c == "1" && u == "admin" && p == "admin123") return "admin";
                if (c == "2" && u == "student" && p == "student123") return "student";

                Console.WriteLine("Invalid login!");
                Pause();
            }
        }

        static void ShowStudents(List<Student> students)
        {
            if (!students.Any())
            {
                Console.WriteLine("No student data.");
                return;
            }

            foreach (var s in students)
                Console.WriteLine($"ID: {s.Id} | Name: {s.Name}");
        }

        static void ShowWeekly(AppService app, List<Student> students)
        {
            if (!students.Any())
            {
                Console.WriteLine("No student data.");
                return;
            }

            foreach (var s in students)
            {
                var stats = app.GetStats(s);

                Console.WriteLine("----------------------------");
                Console.WriteLine($"ID: {s.Id}");
                Console.WriteLine($"Name: {s.Name}");
                Console.WriteLine($"Present: {stats.present}");
                Console.WriteLine($"Absent: {stats.absent}");
                Console.WriteLine($"Excused: {stats.excused}");
                Console.WriteLine($"Rate: {s.Rate:F2}%");
                Console.WriteLine($"Remark: {s.Remark}");
            }
        }

        static void ShowSummary(AppService app, List<Student> students)
        {
            if (!students.Any())
            {
                Console.WriteLine("No student data.");
                return;
            }

            var stats = app.GetSummaryStats(students);

            Console.WriteLine("\n===== SUMMARY =====");
            Console.WriteLine($"Total Students: {students.Count}");
            Console.WriteLine($"Total Present: {stats.totalPresent}");
            Console.WriteLine($"Total Absent: {stats.totalAbsent}");
            Console.WriteLine($"Total Excused: {stats.totalExcused}");
            Console.WriteLine($"Average Rate: {(students.Any() ? students.Average(s => s.Rate) : 0):F2}%");
        }

        static void Main()
        {
            IDataService data = new DataService();
            AppService app = new AppService();

            while (true)
            {
                string? role = Login();
                if (role == null) break;

                bool session = true;

                while (session)
                {
                    Console.Clear();
                    var students = data.GetStudents();

                    Console.WriteLine(role == "admin"
                        ? "===== ADMIN DASHBOARD =====\n"
                        : "===== STUDENT DASHBOARD =====\n");

                    if (role == "admin")
                        Console.WriteLine("1 Add\n2 Update\n3 Delete\n4 View\n5 Weekly\n6 Summary\n7 Logout");
                    else
                        Console.WriteLine("1 View\n2 Weekly\n3 Summary\n4 Logout");

                    Console.Write("Choice: ");

                    if (!int.TryParse(Console.ReadLine(), out int c))
                    {
                        Console.WriteLine("Invalid input!");
                        Pause();
                        continue;
                    }

                    if (role == "admin")
                    {
                        switch (c)
                        {
                            case 1:
                                Console.Write("Enter Name: ");
                                string name = (Console.ReadLine() ?? "").Trim();

                                if (string.IsNullOrWhiteSpace(name))
                                {
                                    Console.WriteLine("Invalid name!");
                                    break;
                                }

                                var s = app.CreateStudent(name);
                                data.AddStudent(s);
                                Console.WriteLine("Student added!");
                                break;

                            case 2:
                                Console.Write("Enter ID: ");
                                string id = (Console.ReadLine() ?? "").Trim();

                                var stu = students.FirstOrDefault(x => x.Id == id);

                                if (stu == null)
                                {
                                    Console.WriteLine("Student not found!");
                                    break;
                                }

                                Console.Write("Enter New Name: ");
                                string newName = (Console.ReadLine() ?? "").Trim();

                                if (string.IsNullOrWhiteSpace(newName))
                                {
                                    Console.WriteLine("Invalid name!");
                                    break;
                                }

                                stu.Name = newName;

                                if (!stu.Attendance.Any())
                                    app.GenerateAttendance(stu);

                                app.ComputeRateAndRemark(stu);
                                data.UpdateStudent(stu);

                                Console.WriteLine("Updated!");
                                break;

                            case 3:
                                Console.Write("Enter ID: ");
                                string delId = (Console.ReadLine() ?? "").Trim();

                                var toDelete = students.FirstOrDefault(x => x.Id == delId);

                                if (toDelete == null)
                                {
                                    Console.WriteLine("Student not found!");
                                    break;
                                }

                                Console.Write("Are you sure? (y/n): ");
                                if ((Console.ReadLine() ?? "").ToLower() != "y")
                                {
                                    Console.WriteLine("Delete cancelled.");
                                    break;
                                }

                                data.DeleteStudent(delId);
                                Console.WriteLine("Deleted!");
                                break;

                            case 4: ShowStudents(students); break;
                            case 5: ShowWeekly(app, students); break;
                            case 6: ShowSummary(app, students); break;
                            case 7: session = false; break;
                            default: Console.WriteLine("Invalid choice!"); break;
                        }
                    }
                    else
                    {
                        switch (c)
                        {
                            case 1: ShowStudents(students); break;
                            case 2: ShowWeekly(app, students); break;
                            case 3: ShowSummary(app, students); break;
                            case 4: session = false; break;
                            default: Console.WriteLine("Invalid choice!"); break;
                        }
                    }

                    Pause();
                }
            }
        }
    }
}