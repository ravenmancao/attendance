using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Microsoft.Data.SqlClient;
using AttendanceModels;

namespace attendanceDataService
{
    public class DataService
    {
        private int nextId = 1;

        private string connectionString = @"Server=localhost\SQLEXPRESS;
Database=AttendanceDB;
Trusted_Connection=True;
TrustServerCertificate=True;";

        private string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "students.json");
        private Random rand = new Random();

        public List<Student> Students { get; private set; } = new List<Student>();

        public DataService()
        {
            LoadStudents();
            if (Students.Count > 0) nextId = Students.Max(s => s.Id) + 1;

            foreach (var student in Students)
            {
                if (student.Attendance.Count == 0)
                {
                    for (int i = 0; i < 5; i++)
                        student.Attendance.Add(RandomStatus());
                    ComputeRateAndRemark(student);
                }
            }
        }

        private AttendanceStatus RandomStatus()
        {
            var values = Enum.GetValues<AttendanceStatus>();
            return (AttendanceStatus)values.GetValue(rand.Next(values.Length))!;
        }

        private void ComputeRateAndRemark(Student student)
        {
            int present = student.Attendance.Count(a => a == AttendanceStatus.P);
            int total = student.Attendance.Count;
            student.Rate = total == 0 ? 0 : (double)present / total * 100;

            student.Remark = student.Rate >= 90 ? "Excellent" :
                  student.Rate > 75 ? "Good" :
                  "Critical";
        }

        public void LoadStudents()
        {
            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                Students = JsonSerializer.Deserialize<List<Student>>(json) ?? new List<Student>();
            }
        }

        public void SaveStudents()
        {
            string json = JsonSerializer.Serialize(Students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public void AddStudent(string name)
        {
            var student = new Student { Id = nextId++, Name = name };
            for (int i = 0; i < 5; i++)
                student.Attendance.Add(RandomStatus());
            ComputeRateAndRemark(student);
            Students.Add(student);
            SaveStudents();

            using var conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "INSERT INTO Students (Name, Rate, Remark) VALUES (@name, @rate, @remark)";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@rate", student.Rate);
            cmd.Parameters.AddWithValue("@remark", student.Remark);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Student Added Successfully!^^");
        }

        public void UpdateStudent(int id, string newName)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) { Console.WriteLine("Student not found."); return; }

            student.Name = newName;
            SaveStudents();

            using var conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "UPDATE Students SET Name=@name, Rate=@rate, Remark=@remark WHERE Id=@id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@name", student.Name);
            cmd.Parameters.AddWithValue("@rate", student.Rate);
            cmd.Parameters.AddWithValue("@remark", student.Remark);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Student Updated Successfully!^^");
        }

        public void DeleteStudent(int id)
        {
            var student = Students.FirstOrDefault(s => s.Id == id);
            if (student == null) { Console.WriteLine("Student not found."); return; }

            Students.Remove(student);
            SaveStudents();

            using var conn = new SqlConnection(connectionString);
            conn.Open();
            string query = "DELETE FROM Students WHERE Id=@id";
            using var cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();

            Console.WriteLine("Student Deleted Successfully!^^");
        }
    }
}