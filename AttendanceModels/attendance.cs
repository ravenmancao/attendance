using System;
using System.Collections.Generic;
using System.Text;

namespace AttendanceModels
{
    internal class attendance
    {
        public class Student
        {
            public string Name { get; set; }
        }
        public class Attendance
        {
            public string[,] Records { get; set; }
        }

    }
}
