using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;

namespace AttendanceModels
{
    public enum AttendanceStatus
    {
      P,A,E
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
    }

    public class AttendanceRecord
    {
    
        public AttendanceStatus?[,] Records { get; set; } = new AttendanceStatus?[100, 5];
    }
}