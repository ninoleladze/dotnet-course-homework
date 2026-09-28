using _06._10._26_DI2.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06._10._26_DI2.Services
{
    internal class StudentService
    {
        public void ShowAllStudents(List<Student> students)
        {
            for (int i = 0; i < students.Count; i++)
            {
                students[i].DisplayStudent();
            }
        }

        public void ShowStudentsSortedByGPADescending(List<Student> students)
        {
            List<Student> sorted = students.OrderByDescending(s => s.GPA).ToList();
            ShowAllStudents(sorted);
        }

        public void ShowActiveStudents(List<Student> students)
        {
            List<Student> active = students.Where(s => s.IsActive == true).ToList();
            ShowAllStudents(active);
        }

        public void SearchByFaculty(List<Student> students)
        {
            Console.Write("Enter faculty: ");
            string faculty = Console.ReadLine();
            List<Student> filtered = students.Where(s => s.Faculty.ToLower() == faculty.ToLower()).ToList();
            if (filtered.Count == 0)
            {
                Console.WriteLine("No students found in this faculty.");
                return;
            }
            ShowAllStudents(filtered);
        }

        public void ShowHighAchievers(List<Student> students)
        {
            List<Student> top = students.Where(s => s.GPA > 3.5).ToList();
            ShowAllStudents(top);
        }
    }
}
