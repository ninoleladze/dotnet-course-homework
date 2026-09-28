using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1031
{
    internal class StudentService : IStudentService
    {
        private List<Student> _students = new List<Student>()
        {
                new Student { Name = "Nini", lastName = "Leladze", Age = 17, Grade = 12 },
                new Student { Name = "Giorgi", lastName = "Beridze", Age = 18, Grade = 11 },
                new Student { Name = "Ana", lastName = "Chikvaidze", Age = 16, Grade = 10 },
                new Student { Name = "Luka", lastName = "Japaridze", Age = 17, Grade = 12 },
                new Student { Name = "Mari", lastName = "Koberidze", Age = 15, Grade = 9 },
                new Student { Name = "Nika", lastName = "Gelashvili", Age = 18, Grade = 12 },
                new Student { Name = "Salome", lastName = "Tchanturia", Age = 16, Grade = 10 },
                new Student { Name = "Irakli", lastName = "Abashidze", Age = 17, Grade = 11 },
                new Student { Name = "Sandro", lastName = "Kikvidze", Age = 15, Grade = 9 },
                new Student { Name = "Keti", lastName = "Iashvili", Age = 16, Grade = 10 }
        };
        public void createStudent()
        {
            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be empty.");
                return;
            }
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(lastName))
            {
                Console.WriteLine("Last Name cannot be empty.");
                return;
            }

            Console.Write("Enter Age: ");
            int age= Convert.ToInt32(Console.ReadLine());
            if (age < 5 || age > 18)
            {
                Console.WriteLine("Age must be between 5 and 100.");
                return;
            }
            Console.Write("Enter Grade: ");
            int grade = Convert.ToInt32(Console.ReadLine());
            if (grade < 1 || grade > 12)
            {
                Console.WriteLine("Grade must be between 1 and 12.");
                return;
            }
            Student newStudent = new Student
            {
                Name = name,
                lastName = lastName,
                Age = age,
                Grade = grade
            };
            _students.Add(newStudent);
            Console.WriteLine("Student created successfully.");

                



        }

        public void deleteStudent()
        {
            showStudents();
            Console.WriteLine("");
            Console.WriteLine("Enter Student ID to delete: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var studentToDelete = _students.FirstOrDefault(s => s.Id == id);
            if(studentToDelete == null) throw new Exception("Student not found.");
            _students.Remove(studentToDelete);
            Console.WriteLine("Student deleted successfully.");
        }

        public void editStudent()
        {
            showStudents();
            Console.WriteLine("");
            Console.WriteLine("enter student id to update");
            int id = Convert.ToInt32(Console.ReadLine());
            var studentToEdit = _students.FirstOrDefault(s => s.Id == id);
            if (studentToEdit == null) throw new Exception("Student not found.");
            Console.WriteLine("select student:");
            Console.WriteLine(studentToEdit);

            Console.Write("Enter Name: ");
            string name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name))
            {
                studentToEdit.Name = name;
            }
            Console.Write("Enter Last Name: ");
            string lastName = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(lastName))
            {
                studentToEdit.lastName = lastName;
            }

            Console.WriteLine(" student edited successfully");



        }

        public void filterStudents()
        {
            Console.WriteLine("search students:");
            string query = Console.ReadLine();

            var filteredStudents = _students.Where(s => s.Name.ToLower().Contains(query) || s.lastName.ToLower().Contains(query)).ToList();
            if(!filteredStudents.Any())throw new Exception("No students found matching the query.");

            foreach (var student in filteredStudents)
            {
                Console.WriteLine(student);
            }

        }

        public void showStudentDetails()
        {
            showStudents();
            Console.WriteLine("");
            Console.WriteLine("Enter Student ID to view details: ");
            int id = Convert.ToInt32(Console.ReadLine());
            var student = _students.FirstOrDefault(s => s.Id == id);
            if (student == null) throw new Exception("Student not found.");
            Console.WriteLine("Student Details:");
            Console.WriteLine(student);


        }

        public void showStudents()
        {
            Console.WriteLine("Student List:");
            foreach (var student in _students)
            {
                Console.WriteLine(student);
            }

        }

        public void showstudentsusername()
        {
       var usernames = _students
                .Select(s => $"{s.Name} {s.lastName}").ToList();
            Console.WriteLine("Student Usernames:");
            foreach (var username in usernames)
            {
                Console.WriteLine(username);
            }






        }
    }
}
