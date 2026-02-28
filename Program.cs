/*
 STUDENTS ATTENDANCE,STUDENTS SUMMARY.
 */
using System;
using System.Collections.Generic;

namespace attendance
{
    internal class Program
    {
        static void Main()
        {

            //DINI-DEFINE ANG LISTA SA MGA STUDENTS AND ANG 2D ARRAY PARA SA ATTENDANCE NILA.
            List<string> students = new List<string>()
            {
"Ralph Monzon","Brix Sochaco","Manu Masangkay","Jen Villareal","Josh Dator","Gege Graban","Abby Almadin","Laurent Dimapelis","Eichi Aquino","Rave Mancao",
"Mitch Pichi","Shielo Resaba","Keichiro Shin","Jewell Gestoso","Usher Magbanua"
            };

            //DINI-DEFINE ANG ATTENDANCE NG BAWAT STUDENT SA BAWAT ARAW, GINAMIT ANG "P" PARA SA PRESENT, "A" PARA SA ABSENT, AND "E" PARA SA EXCUSED.
            string[,] attendance ={

               { "P","P","A","E","E" },
               { "P","A","P","P","P" },
               { "A","P","P","E","P" },
               { "P","P","P","P","P" },
               { "P","P","P","E","P" },
               { "P","P","P","P","A" },
               { "P","P","E","E","P"},
               { "P","P","P","P","P"},
               { "P","P","A","P","E"},
               { "P","P","P","E","P"},
               { "E","E","P","P","P"},
               { "P","P","A","P","P"},
               { "P","P","P","P","P"},
               { "P","A","E","P","P"},
               { "P","A","A","A","P"},
             };

            DisplayWeeklyPerStudent(students, attendance);
            DisplayOverallSummary(students,attendance);
        }

        //DINI-DISPLAY NYA ANG ATTENDANCE NG BAWAT STUDENT SA BAWAT ARAW AND CALCULATE ANG PRESENT, ABSENT, & EXCUSED.
        static void DisplayWeeklyPerStudent(List<string> students, string[,] attendance)
        {
            Console.WriteLine("RAVE'S UNIVERSITY BIÑAN CAMPUS\n");
            Console.WriteLine("| WEEKLY ATTENDANCE PER STUDENT |");
            Console.WriteLine("---------------------------------\n");

            for (int i = 0; i < students.Count; i++)
            {
                int present = 0, absent = 0, excused = 0;

                for (int j = 0; j < attendance.GetLength(1); j++)
                {
                    if (attendance[i, j] == "P") { present++; }
                    else if (attendance[i, j] == "A") { absent++; }
                    else if (attendance[i, j] == "E") { excused++; }
                }

                //KINI- CALCULATE ANG PERCENTAGE NG ATTENDANCE NG BAWAT STUDENT AND DETERMINE ANG REMARKS BASED ON THE PERCENTAGE.
                double percentage = (double)present / attendance.GetLength(1) * 100;
                  string remark = percentage switch
                    {
                        >= 100 => "Excellent",
                        >= 75 => "Good",
                        >= 50 => "Warning",
                        _ => "Critical"
                    };

                    Console.WriteLine((i + 1) + ". " + students[i]);
                    Console.WriteLine("Present: " + present);
                    Console.WriteLine("Absent: " + absent);
                    Console.WriteLine("Excused: " + excused);


                //DINI-DISPLAY NYA ANG PERCENTAGE AND REMARKS NG BAWAT STUDENT.
                Console.WriteLine("Rate: " + percentage.ToString("F2") + "%");
                Console.WriteLine("Remark: " + remark);
                Console.WriteLine("--------------------");

                }
            }

        //KINOKOMPYLE NYA ANG TOTAL PRESENT, ABSENT, AND EXCUSED NG LAHAT NG STUDENTS PARA SA OVERALL SUMMARY.
        static void DisplayOverallSummary(List<String> students, String[,] attendance)
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

            //DINI-DISPLAY NYA ANG OVERALL SUMMARY NG ATTENDANCE.
            Console.WriteLine("\n| OVERALL ATTENDANCE SUMMARY |");
                Console.WriteLine("------------------------------\n");
                Console.WriteLine("Total Present: " + totalPresent);
                Console.WriteLine("Total Absent: " + totalAbsent);
                Console.WriteLine("Total Excused: " + totalExcused);

            }
        }
    }

