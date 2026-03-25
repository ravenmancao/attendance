using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttendanceModels
{
    public enum AttendanceStatus
    {
        P, // stand for Present
        A, // stand for Absent
        E  // stand for Excused
    }

    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";
        public double Rate { get; set; } = 0.0;
        public string Remark { get; set; } = "Critical";
        public List<AttendanceStatus> Attendance { get; set; } = new List<AttendanceStatus>();
    }
}