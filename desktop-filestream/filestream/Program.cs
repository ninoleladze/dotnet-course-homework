using filestream;


StudentsLibrary library = new StudentsLibrary();
library.LoadStudents();

while (true)
{
    Console.Clear();
    Console.WriteLine("====== Student Management ======");
    Console.WriteLine("1. Create new student");
    Console.WriteLine("2. Show all students");
    Console.WriteLine("3. Delete student");
    Console.WriteLine("Any other key to exit");
    Console.Write("Enter key: ");
    string? key = Console.ReadLine();

    if (key == "1")
    {
        Console.Clear();
        library.CreateStudent();
       
    }
    else if (key == "2")
    {
        Console.Clear();
        library.ShowStudents();
      
    }
    else if (key == "3")
    {
        Console.Clear();
        library.DeleteStudent();
       
    }
    else break;
}

