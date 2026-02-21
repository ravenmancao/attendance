using System;
using System.Collections.Generic;

namespace attendance
{
    internal class Program
    {
        static void Main()
        {
            List<string> students = new List<string>()
            {
"Ralph Monzon","Brix Sochaco","Manu Masangkay","Jen Villareal","Josh Dator","Gege Graban","Abby Almadin","Laurent Dimapelis","Eichi Aquino","Rave Mancao",
"Juan Luna","Randy De Guzman","Jayson De Guzman","Dianne De Guzman","Mitch De Guzman"
            };

            string[] attendance =
             {
                "P","P","A","P","P",
                "P","A","P","P","P",
                "A","P","P","E","P",
                "P","P","P","P","P",
                "P","P","P","E","P",
                "P","P","P","P","A",
                "P","P","P","P","P",
                "P","P","P","P","P",
                "P","P","A","P","E",
                "P","P","P","E","P",
                "E","E","P","P","P",
                "P","P","P","P","P",
                "P","P","P","P","P",
                "P","A","E","P","P",
                "P","A","A","A","P",
             };

            DisplayWeeklyPerStudent(students, attendance);
        }
        static void DisplayWeeklyPerStudent(List<string> students, string[] attendance)
        {
            Console.WriteLine("====WEEKLY ATTENDANCE PER STUDENT====");
            Console.WriteLine("-------------------------------------------------------------\n");
            for (int i = 0; i < students.Count; i++)
            {
                int present = 0;
                int absent = 0;
                int excused = 0;

                for (int j = 0; j < attendance.GetLength(1); j++)
                {
                    if (attendance[i, j] == "P")
                    {
                        present++;
                    }
                    else if (attendance[i, j] == "A")
                    {
                        absent++;
                    }
                    else if (attendance[i, j] == "E")
                    {
                        excused++;
                    }
                    Console.WriteLine(i + 1) + "." + students[i];
                    Console.WriteLine("Present: " + present);
                    Console.WriteLine("Absent: " + absent);
                    Console.WriteLine("Excused: " + excused);
                    Console.WriteLine();
                }

            }
        }
    }
}
