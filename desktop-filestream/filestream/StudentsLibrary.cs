using System.Xml.Serialization;


namespace filestream
{
    internal class StudentsLibrary
    {
        private List<Student> studentsList = new List<Student>();
        XmlSerializer serializer = new XmlSerializer(typeof(List<Student>));

        public void LoadStudents()
        {
            StreamReader sr = new StreamReader("students.xml");
            var data = serializer.Deserialize(sr);
            sr.Close();

            if (data != null)
            {
                studentsList = (List<Student>)data;
            }
        }

        public void CreateStudent()
        {
            Console.Write("Enter student name: ");
            string name = Console.ReadLine();

            Console.Write("Enter student age: ");
            int age = int.Parse(Console.ReadLine());

            Console.Write("Enter student major: ");
            string major = Console.ReadLine();

            Student student = new Student();
            student.Name = name;
            student.Age = age;
            student.Major = major;

            studentsList.Add(student);
            SaveData();

            Console.WriteLine("Student created successfully.");
        }

        public void DeleteStudent()
        {
            ShowStudents();

            Console.Write("Enter student ID: ");
            int studentId = int.Parse(Console.ReadLine());

            var student = studentsList.FirstOrDefault(e => e.Id == studentId);

            if (student == null)
            {
                Console.WriteLine("Student not found!");
            }
            else
            {
                studentsList.Remove(student);
                SaveData();
            }
        }

        public void ShowStudents()
        {
            foreach (var student in studentsList)
            {
                Console.WriteLine(student);
            }
        }

        private void SaveData()
        {
            StreamWriter sw = new StreamWriter("students.xml");
            serializer.Serialize(sw, studentsList);
            sw.Close();
        }
    }
}