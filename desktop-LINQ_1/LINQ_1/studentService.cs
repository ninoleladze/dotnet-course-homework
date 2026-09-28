namespace LINQ_1
{
    internal class StudentService
    {
        private readonly List<Student> _students = new()
        {
            new Student { Name = "Alice", Age = 20, Grade = 3.7, Group = "A" },
            new Student { Name = "Bob",   Age = 22, Grade = 4.0, Group = "B" },
            new Student { Name = "Carol", Age = 21, Grade = 3.9, Group = "A" },
            new Student { Name = "Dave",  Age = 23, Grade = 2.8, Group = "C" }
        };

       
        public IList<Student> FilterStudents(int? minAge = null, int? maxAge = null,
                                            double? minGrade = null, double? maxGrade = null,
                                            string? group = null)
        {
            IEnumerable<Student> q = _students;

            if (minAge.HasValue) q = q.Where(s => s.Age >= minAge.Value);
            if (maxAge.HasValue) q = q.Where(s => s.Age <= maxAge.Value);
            if (minGrade.HasValue) q = q.Where(s => s.Grade >= minGrade.Value);
            if (maxGrade.HasValue) q = q.Where(s => s.Grade <= maxGrade.Value);
            if (!string.IsNullOrWhiteSpace(group))
                q = q.Where(s => string.Equals(s.Group, group, StringComparison.OrdinalIgnoreCase));

            return q.ToList();
        }

        public IList<Student> OrderStudentsByGrade(bool descending = true)
        {
            return descending
                ? _students.OrderByDescending(s => s.Grade).ThenBy(s => s.Name).ToList()
                : _students.OrderBy(s => s.Grade).ThenBy(s => s.Name).ToList();
        }


        public IList<Student> GetPagedStudents(int pageNumber, int pageSize)
        {
            if (pageNumber < 1) throw new ArgumentOutOfRangeException(nameof(pageNumber));
            if (pageSize < 1) throw new ArgumentOutOfRangeException(nameof(pageSize));

            return _students.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }


        public IDictionary<string, IList<Student>> GroupStudentsByGroup()
        {
            return _students
                .GroupBy(s => s.Group)
                .ToDictionary(g => g.Key, g => (IList<Student>)g.ToList());
        }

    
        public Student? GetTopStudent()
        {
            return _students.OrderByDescending(s => s.Grade).ThenBy(s => s.Age).FirstOrDefault();
        }

     
        public Student? FindStudentByName(string name, bool exact = false)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;

            return exact
                ? _students.FirstOrDefault(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase))
                : _students.FirstOrDefault(s => s.Name.IndexOf(name, StringComparison.OrdinalIgnoreCase) >= 0);
        }

        

        public void ShowAllStudents()
        {
            if (!_students.Any())
            {
                Console.WriteLine("No students.");
                return;
            }

            foreach (var s in _students) Console.WriteLine(s);
        }

        public void AddStudent()
        {
            Console.Write("enter student name: ");
            var name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("name cannot be empty");

            Console.Write("enter age: ");
            if (!int.TryParse(Console.ReadLine(), out var age)) throw new Exception("invalid age");

            Console.Write("enter grade (e.g. 3.5): ");
            if (!double.TryParse(Console.ReadLine(), out var grade)) throw new Exception("invalid grade");

            Console.Write("enter group: ");
            var group = Console.ReadLine() ?? string.Empty;

            _students.Add(new Student { Name = name, Age = age, Grade = grade, Group = group });
            Console.WriteLine("Student added.");
        }

        public void RemoveStudent()
        {
            Console.Write("enter student id: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) throw new Exception("invalid id");

            var found = _students.FirstOrDefault(s => s.Id == id);
            if (found == null) throw new Exception("student not found");

            _students.Remove(found);
            Console.WriteLine("Student removed.");
        }

        public void UpdateStudent()
        {
            ShowAllStudents();
            Console.Write("enter student id to update: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) throw new Exception("invalid id");

            var found = _students.FirstOrDefault(s => s.Id == id);
            if (found == null) throw new Exception("student not found");

            Console.Write("enter new name: ");
            var name = Console.ReadLine();
            Console.Write("enter new age: ");
            if (!int.TryParse(Console.ReadLine(), out var age)) throw new Exception("invalid age");
            Console.Write("enter new grade: ");
            if (!double.TryParse(Console.ReadLine(), out var grade)) throw new Exception("invalid grade");
            Console.Write("enter new group: ");
            var group = Console.ReadLine() ?? string.Empty;

            found.Name = name ?? string.Empty;
            found.Age = age;
            found.Grade = grade;
            found.Group = group;

            Console.WriteLine("Student updated.");
        }

        public void FilterStudentsInteractive()
        {
            Console.Write("min age (blank to ignore): ");
            var minAgeS = Console.ReadLine();
            Console.Write("max age (blank to ignore): ");
            var maxAgeS = Console.ReadLine();
            Console.Write("min grade (blank to ignore): ");
            var minGradeS = Console.ReadLine();
            Console.Write("max grade (blank to ignore): ");
            var maxGradeS = Console.ReadLine();
            Console.Write("group (blank to ignore): ");
            var group = Console.ReadLine();

            int? minAge = string.IsNullOrWhiteSpace(minAgeS) ? null : int.Parse(minAgeS);
            int? maxAge = string.IsNullOrWhiteSpace(maxAgeS) ? null : int.Parse(maxAgeS);
            double? minGrade = string.IsNullOrWhiteSpace(minGradeS) ? null : double.Parse(minGradeS);
            double? maxGrade = string.IsNullOrWhiteSpace(maxGradeS) ? null : double.Parse(maxGradeS);

            var res = FilterStudents(minAge, maxAge, minGrade, maxGrade, group);
            if (!res.Any()) Console.WriteLine("No matching students.");
            else foreach (var s in res) Console.WriteLine(s);
        }

        public void OrderStudentsByGradeInteractive()
        {
            Console.Write("descending? (y/n): ");
            var ch = Console.ReadLine();
            bool desc = string.Equals(ch, "y", StringComparison.OrdinalIgnoreCase);
            var res = OrderStudentsByGrade(desc);
            foreach (var s in res) Console.WriteLine(s);
        }

        public void GetPagedStudentsInteractive()
        {
            Console.Write("page number (1-based): ");
            if (!int.TryParse(Console.ReadLine(), out var page)) throw new Exception("invalid page");
            Console.Write("page size: ");
            if (!int.TryParse(Console.ReadLine(), out var size)) throw new Exception("invalid size");

            var res = GetPagedStudents(page, size);
            if (!res.Any()) Console.WriteLine("No students on this page.");
            else foreach (var s in res) Console.WriteLine(s);
        }

        public void GroupStudentsInteractive()
        {
            var groups = GroupStudentsByGroup();
            foreach (var kv in groups)
            {
                Console.WriteLine($"Group: {kv.Key}");
                foreach (var s in kv.Value) Console.WriteLine("  " + s);
            }
        }

        public void ShowTopStudent()
        {
            var top = GetTopStudent();
            if (top == null) Console.WriteLine("No students.");
            else Console.WriteLine("Top student: " + top);
        }

        public void FindStudentByNameInteractive()
        {
            Console.Write("enter name (partial or full): ");
            var name = Console.ReadLine();
            var found = FindStudentByName(name ?? string.Empty);
            if (found == null) Console.WriteLine("student not found.");
            else Console.WriteLine(found);
        }

        public void GetStudentByIdInteractive()
        {
            Console.Write("enter student id: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) throw new Exception("invalid id");
            var found = _students.FirstOrDefault(s => s.Id == id);
            if (found == null) throw new Exception("student not found");
            Console.WriteLine(found);
        }
    }
}