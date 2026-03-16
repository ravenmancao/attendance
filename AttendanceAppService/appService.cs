using System;
using System.Collections.Generic;
using AttendanceModels;

namespace attendanceAppService
{
    public class AppService
    {
        public void DisplayWeekly(List<Student> students, AttendanceRecord attendance)
        {
            Console.WriteLine("RAVE'S UNIVERSITY BIÑAN CAMPUS\n");
            Console.WriteLine("| WEEKLY ATTENDANCE PER STUDENT |");
            Console.WriteLine("---------------------------------\n");

            for (int i = 0; i < students.Count; i++)
            {
                int present = 0, absent = 0, excused = 0;

                for (int j = 0; j < 5; j++)
                {
                    var status = attendance.Records[i, j];
                    if (status == AttendanceStatus.P) present++;
                    else if (status == AttendanceStatus.A) absent++;
                    else if (status == AttendanceStatus.E) excused++;
                }

                double percentage = (double)present / 5 * 100;

                string remark =
                    percentage >= 100 ? "Excellent" :
                    percentage >= 75 ? "Good" :
                    percentage >= 50 ? "Warning" :
                    "Critical";

                Console.WriteLine($"{i + 1}. ID: {students[i].Id} | {students[i].Name}");
                Console.WriteLine($"Present: {present} | Absent: {absent} | Excused: {excused}");
                Console.WriteLine("Rate: " + percentage.ToString("F2") + "%");
                Console.WriteLine("Remark: " + remark);
                Console.WriteLine("--------------------");
            }
        }

        public void DisplaySummary(AttendanceRecord attendance)
        {
            int totalPresent = 0, totalAbsent = 0, totalExcused = 0;

            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var status = attendance.Records[i, j];
                    if (status == AttendanceStatus.P) totalPresent++;
                    else if (status == AttendanceStatus.A) totalAbsent++;
                    else if (status == AttendanceStatus.E) totalExcused++;
                }
            }

            Console.WriteLine("\n| OVERALL ATTENDANCE SUMMARY |");
            Console.WriteLine("------------------------------\n");
            Console.WriteLine("Total Present: " + totalPresent);
            Console.WriteLine("Total Absent: " + totalAbsent);
            Console.WriteLine("Total Excused: " + totalExcused);
        }
    }
}