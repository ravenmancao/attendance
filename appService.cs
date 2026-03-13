using System;
using System.Collections.Generic;
using System.Text;

namespace attendanceAppService
{
    public class AppService
    {
        public void DisplayWeekly(List<string> students, string[,] attendance)
        {
            Console.WriteLine("RAVE'S UNIVERSITY BIÑAN CAMPUS\n");
            Console.WriteLine("| WEEKLY ATTENDANCE PER STUDENT |");
            Console.WriteLine("---------------------------------\n");

            for (int i = 0; i < students.Count; i++)
            {
                int present = 0, absent = 0, excused = 0;

                for (int j = 0; j < attendance.GetLength(1); j++)
                {
                    if (attendance[i, j] == "P") present++;
                    else if (attendance[i, j] == "A") absent++;
                    else if (attendance[i, j] == "E") excused++;
                }

                double percentage = (double)present / attendance.GetLength(1) * 100;

                string remark =
                    percentage >= 100 ? "Excellent" :
                    percentage >= 75 ? "Good" :
                    percentage >= 50 ? "Warning" :
                    "Critical";

                Console.WriteLine((i + 1) + ". " + students[i]);
                Console.WriteLine("Present: " + present);
                Console.WriteLine("Absent: " + absent);
                Console.WriteLine("Excused: " + excused);
                Console.WriteLine("Rate: " + percentage.ToString("F2") + "%");
                Console.WriteLine("Remark: " + remark);
                Console.WriteLine("--------------------");
            }
        }

        public void DisplaySummary(string[,] attendance)
        {
            int totalPresent = 0, totalAbsent = 0, totalExcused = 0;

            for (int i = 0; i < attendance.GetLength(0); i++)
            {
                for (int j = 0; j < attendance.GetLength(1); j++)
                {
                    if (attendance[i, j] == "P") totalPresent++;
                    else if (attendance[i, j] == "A") totalAbsent++;
                    else if (attendance[i, j] == "E") totalExcused++;
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
