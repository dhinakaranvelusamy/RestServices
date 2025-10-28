using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using StudentInFormation;

namespace StudentApi.Data
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

        public StudentInfo GetStudentById(int id) => students.FirstOrDefault(s => s.Id == id);

        public bool AddStudent(StudentInfo student)
        {
            students.Add(student);
            SaveData();
            return true;
        }

        public bool UpdateStudent(StudentInfo student)
        {
            var existing = GetStudentById(student.Id);
            if (existing == null) return false;

            existing.Name = student.Name;
            existing.RollNo = student.RollNo;
            existing.Age = student.Age;
            existing.MobileNo = student.MobileNo;
            SaveData();
            return true;
        }

        public bool DeleteStudent(int id)
        {
            var student = GetStudentById(id);
            if (student == null) return false;

            students.Remove(student);
            SaveData();
            return true;
        }

        public List<StudentInfo> SearchByName(string name)
        {
            return students
                .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        public StudentInfo SearchByRollNo(int rollNo)
        {
            return students.FirstOrDefault(s => s.RollNo == rollNo);
        }

        public StudentInfo SearchByMobile(long mobile)
        {
            return students.FirstOrDefault(s => s.MobileNo == mobile);
        }
    }
}
