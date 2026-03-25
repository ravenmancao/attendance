using System;
using attendanceDataService;
using attendanceAppService;

namespace attendance
{
    internal class Program
    {
        static void Main()
        {
            DataService data = new DataService();
            AppService app = new AppService();
            bool running = true;

            while (running)
            {
                Console.WriteLine("\n==============================");
                Console.WriteLine(" STUDENT ATTENDANCE SYSTEM ");
                Console.WriteLine("==============================");
                Console.WriteLine("1 Add Student");
                Console.WriteLine("2 Update Student");
                Console.WriteLine("3 Delete Student");
                Console.WriteLine("4 View Weekly Attendance");
                Console.WriteLine("5 View Summary");
                Console.WriteLine("6 Exit");
                Console.Write("Choose option: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Invalid input.");
                    continue;
                }

                switch (choice)
                {
                    case 1:
                        Console.Write("Enter Student Name: ");
                        string studentName = Console.ReadLine() ?? "";
                        data.AddStudent(studentName);
                        break;

                    case 2:
                        Console.Write("Enter Student ID to update: ");
                        if (int.TryParse(Console.ReadLine(), out int updateId))
                        {
                            Console.Write("Enter new name: ");
                            string newStudentName = Console.ReadLine() ?? "";
                            data.UpdateStudent(updateId, newStudentName);
                        }
                        else
                            Console.WriteLine("Invalid ID.");
                        break;

                    case 3:
                        Console.Write("Enter Student ID to delete: ");
                        if (int.TryParse(Console.ReadLine(), out int deleteId))
                            data.DeleteStudent(deleteId);
                        else
                            Console.WriteLine("Invalid ID.");
                        break;

                    case 4:
                        app.DisplayWeekly(data.Students);
                        break;

                    case 5:
                        app.DisplaySummary(data.Students);
                        break;

                    case 6:
                        running = false;
                        Console.WriteLine("Exiting system...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }
    }
}