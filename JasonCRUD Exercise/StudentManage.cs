using System;
using System.Collections.Generic;
using System.Linq;
using StudentInFormation;
using JasonLibrary; // Assuming StudentInfo is defined here

namespace JasonCRUD_Exercise
{
    public class StudentManage
    {
        public List<StudentInfo> students = new List<StudentInfo>();
        public StudentManage()
        {

            students.Add(new StudentInfo { RollNumber = 101, Name = "Arun", age = 20, MobileNumber = 9876543210 });
            students.Add(new StudentInfo { RollNumber = 102, Name = "Bala", age = 21, MobileNumber = 9876501234 });
            students.Add(new StudentInfo { RollNumber = 103, Name = "Chitra", age = 19, MobileNumber = 9876005678 });
        }

        //  Search by Roll Number
        public StudentInfo SearchByRollNo(int rollNo)
        {
            return students.FirstOrDefault(s => s.RollNumber == rollNo);
        }

        //  Search by Mobile Number
        public StudentInfo SearchByMobile(long mobile)
        {
            return students.FirstOrDefault(s => s.MobileNumber == mobile);
        }

        // Search by Name 
        public List<StudentInfo> SearchByName(string name)
        {
            return students
                .Where(s => s.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0)
                .ToList();
        }
    }
}
