using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace StudentInFormation
{
    public class StudentsRepository
    {
        private readonly string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "students.json");
        private List<StudentInfo> students;

        public StudentsRepository()
        {
            LoadData();
        }

        private void LoadData()
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                File.WriteAllText(filePath, "[]");
            }
            var json = File.ReadAllText(filePath);
            students = JsonSerializer.Deserialize<List<StudentInfo>>(json) ?? new List<StudentInfo>();
        }

        private void SaveData()
        {
            var json = JsonSerializer.Serialize(students, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
        }

        public List<StudentInfo> GetStudents() => students;

        public StudentInfo GetStudentByID(int id) => students.FirstOrDefault(s => s.id == id);

        public bool AddStudent(StudentInfo student)
        {
            students.Add(student);
            SaveData();
            return true;
        }

        public bool UpdateStudent(StudentInfo student)
        {
            var existing = GetStudentByID(student.id);
            if (existing == null) return false;

            existing.Name = student.Name;
            existing.RollNumber = student.RollNumber;
            existing.age = student.age;
            existing.MobileNumber = student.MobileNumber;
            SaveData();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = GetStudentByID(id);
            if (student == null) return false;

            students.Remove(student);
            SaveData();
            return true;
        }

        public List<StudentInfo> SearchStudentsByName(string name)
        {
            return students
                .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }
    }
}
