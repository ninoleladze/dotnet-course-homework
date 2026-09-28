using _1024;

List<Student> students = new  List<Student>()
{
    new Student { Id = 1, FirstName = "John", LastName = "Doe", Email = "nini@gmail.com ", Age = 20 },
    new Student { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "nini@gmail.com", Age = 22 },
    new Student { Id = 3, FirstName = "Alice", LastName = "Johnson", Email = "luka@gmail.com", Age = 21},
    new Student { Id = 4, FirstName = "Bob", LastName = "Brown", Email = "bob@gmail.com", Age = 21 },
    new Student { Id = 5, FirstName = "Charlie", LastName = "Davis", Email = "charlie@gmail.com", Age = 22 }
    };


//var studentlist = students
//    .OrderBy(s => s.Id)
//    .Take(3)
//    .ToList();
//foreach (var student in studentlist)
//{
//    Console.WriteLine(student);
//}


//var studentlist2 = students
//    .OrderByDescending(s => s.Id)
//    .Skip(2)
//    .Take(3)
//    .ToList();
//foreach (var student in studentlist2)
//{
//    Console.WriteLine(student);
//}

var studentlist3 = students
    .GroupBy(s=> s.Age)
    .ToList();


foreach (var group in studentlist3)
{
   
    Console.WriteLine($"Age Group: {group.Key}");
    foreach (var student in group)
    {
        Console.WriteLine(student);
    }

}

// void filterStudentsByemailAndAge(string email, int age)
//{

//    var filteredStudents = students
//        .Where(s => s.Email.ToLower().Contains(email.ToLower()) && s.Age > age)
//        .ToList();
//    foreach (var student in filteredStudents)
//    {
//        Console.WriteLine(student);
//    }
//}

//void FilterStudents(string query)
//{
//    var filteredStudents = students
//        .Where(s => s.FirstName.Contains(query)|| s.LastName.Contains(query)|| s.Email.Contains(query))
//        .ToList();

//    foreach (var student in filteredStudents)
//        {
//        Console.WriteLine(student);
//    }

//}

//void getstudentbyid(int id)
//{
//var student = students.FirstOrDefault(s => s.Id == id);
//    Console.WriteLine(student);
//}

//void filterbyage(int age)
//{
//    var filteredStudents = students
//        .Where(s => s.Age == age)
//        .ToList();

//    foreach (var student in filteredStudents)
//    {
//        Console.WriteLine(student);
//    }

//}





//Console.WriteLine("enter email:");
//string email = Console.ReadLine();
//Console.WriteLine("enter age:");
//int age = int.Parse(Console.ReadLine());
//filterStudentsByemailAndAge(email, age);

//Console.WriteLine("enter query: ");
//string query = Console.ReadLine();    ///filter students
//FilterStudents(query);

//Console.WriteLine("enter id:");
//int id = int.Parse(Console.ReadLine());   ////filter id
//getstudentbyid(id);

//Console.WriteLine("enter age:");
//int age = int.Parse(Console.ReadLine());   ////filter by age
//filterbyage(age);

