using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using StudentInFormation;

namespace JasonLibrary
{
    public class JasonCRUD
    {
        public List<StudentInfo> Info = new List<StudentInfo>();
        public string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "data.json");

        public JasonCRUD()
        {
            LoadData();
        }

        // CREATE STUDENT
        public void AddJason(StudentInfo info)
        {
            Info.Add(info);
            SaveData();
        }

        // READ ALL
        public List<StudentInfo> GetAll()
        {
            return Info;
        }

        // UPDATE
        public bool UpdateJason(int rollno, string newname, int newage, long newmobile)
        {
            var student = Info.FirstOrDefault(x => x.RollNo == rollno);
            if (student != null)
            {
                student.Name = newname;
                student.Age = newage;
                student.MobileNo = newmobile;
                SaveData();
                return true;
            }
            return false;
        }

        // DELETE
        public bool DeleteJason(int rollno)
        {
            var student = Info.FirstOrDefault(x => x.RollNo == rollno);
            if (student != null)
            {
                Info.Remove(student);
                SaveData();
                return true;
            }
            return false;
        }

        // SEARCH: NAME
        public List<StudentInfo> SearchByName(string keyword)
        {
            return Info.Where(x => x.Name.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        // SEARCH: ROLL NUMBER
        public StudentInfo SearchByRollNo(int rollno)
        {
            return Info.FirstOrDefault(x => x.RollNo == rollno);
        }

        // SEARCH: MOBILE
        public StudentInfo SearchByMobile(long mobile)
        {
            return Info.FirstOrDefault(x => x.MobileNo == mobile);
        }

        // JSON FILE OPERATIONS
        private void SaveData()
        {
            var json = JsonSerializer.Serialize(Info, new JsonSerializerOptions { WriteIndented = true });
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
            File.WriteAllText(filePath, json);
        }

        private void LoadData()
        {
            if (!File.Exists(filePath))
            {
                Directory.CreateDirectory("Data");
                File.WriteAllText(filePath,"[]");
            }

            var json = File.ReadAllText(filePath);
            Info = JsonSerializer.Deserialize<List<StudentInfo>>(json) ?? new List<StudentInfo>();
        }
    }
}
