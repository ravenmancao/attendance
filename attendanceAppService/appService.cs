using System;
using System.Collections.Generic;
using System.Linq;
using AttendanceModels;

namespace attendanceAppService
{
    public class AppService
    {
        public void DisplayWeekly(List<Student> students)
        {
            Console.WriteLine("RAVE'S UNIVERSITY BIÑAN CAMPUS\n");
            Console.WriteLine("| WEEKLY ATTENDANCE PER STUDENT |");
            Console.WriteLine("---------------------------------\n");

            foreach (var student in students)
            {
                int present = student.Attendance.Count(a => a == AttendanceStatus.P);
                int absent = student.Attendance.Count(a => a == AttendanceStatus.A);
                int excused = student.Attendance.Count(a => a == AttendanceStatus.E);

                Console.WriteLine($"ID: {student.Id} | Name: {student.Name}");
                Console.WriteLine($"Present: {present} | Absent: {absent} | Excused: {excused}");
                Console.WriteLine("Rate: " + student.Rate.ToString("F2") + "%");
                Console.WriteLine("Remark: " + student.Remark);
                Console.WriteLine("--------------------");
            }
        }

        public void DisplaySummary(List<Student> students)
        {
            int totalPresent = students.Sum(s => s.Attendance.Count(a => a == AttendanceStatus.P));
            int totalAbsent = students.Sum(s => s.Attendance.Count(a => a == AttendanceStatus.A));
            int totalExcused = students.Sum(s => s.Attendance.Count(a => a == AttendanceStatus.E));

            Console.WriteLine("\n| OVERALL ATTENDANCE SUMMARY |");
            Console.WriteLine("------------------------------");
            Console.WriteLine("Total Present: " + totalPresent);
            Console.WriteLine("Total Absent: " + totalAbsent);
            Console.WriteLine("Total Excused: " + totalExcused);
        }
    }
}