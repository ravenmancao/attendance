using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AttendanceModels;

namespace attendanceDataService
{
    public class DataService
    {
        private int nextId = 34;

        public List<Student> Students { get; private set; } = new List<Student>()
        {
            new Student{Id=19, Name="Ralph Monzon"},
            new Student{Id=20, Name="Brix Sochaco"},
            new Student{Id=21, Name="Manu Masangkay"},
            new Student{Id=22, Name="Jen Villareal"},
            new Student{Id=23, Name="Josh Dator"},
            new Student{Id=24, Name="Gege Graban"},
            new Student{Id=25, Name="Abby Almadin"},
            new Student{Id=26, Name="Laurent Dimapelis"},
            new Student{Id=27, Name="Eichi Aquino"},
            new Student{Id=28, Name="Rave Mancao"},
            new Student{Id=29, Name="Mitch Pichi"},
            new Student{Id=30, Name="Shielo Resaba"},
            new Student{Id=31, Name="Keichiro Shin"},
            new Student{Id=32, Name="Jewell Gestoso"},
            new Student{Id=33, Name="Usher Magbanua"}
        };

        public AttendanceRecord Attendance { get; private set; } = new AttendanceRecord();
        private Random rand = new Random();

        public DataService()
        {
            for (int i = 0; i < Students.Count; i++)
                for (int j = 0; j < 5; j++)
                    Attendance.Records[i, j] = RandomStatus();
        }

        private AttendanceStatus RandomStatus()
        {
            Array values = Enum.GetValues(typeof(AttendanceStatus));
            return (AttendanceStatus)values.GetValue(rand.Next(values.Length));
        }

        public void AddStudent(string name)
        {
            var student = new Student { Id = nextId++, Name = name };
            Students.Add(student);
            int index = Students.Count - 1;
            for (int j = 0; j < 5; j++)
                Attendance.Records[index, j] = RandomStatus();
            Console.WriteLine($"Student added successfully! ID: {student.Id}");
        }

        public void UpdateStudent(int id, string newName)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student != null)
            {
                student.Name = newName;
                Console.WriteLine("Student updated successfully!");
            }
            else
                Console.WriteLine("Student not found.");
        }

        public void DeleteStudent(int id)
        {
            int index = Students.FindIndex(s => s.Id == id);
            if (index != -1)
            {
                Students.RemoveAt(index);
                for (int i = index; i < Students.Count; i++)
                    for (int j = 0; j < 5; j++)
                        Attendance.Records[i, j] = Attendance.Records[i + 1, j];
                int lastIndex = Students.Count;
                for (int j = 0; j < 5; j++)
                    Attendance.Records[lastIndex, j] = null;
                Console.WriteLine("Student deleted successfully.");
            }
            else
                Console.WriteLine("Student not found.");
        }
    }
}