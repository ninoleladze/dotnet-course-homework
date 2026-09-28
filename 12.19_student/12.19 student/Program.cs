using _12._19_student;
using _12._19_student.Services;

Baza baza = new Baza();

StudentService studentService = new StudentService();

while (true)
{
    Console.WriteLine("1. Create Student");
    Console.WriteLine("2. Delete Student");
    Console.WriteLine("3. Edit Student");
    Console.WriteLine("4. List Students");
    Console.WriteLine("5. Exit");
    Console.Write("Select an option: ");
    string choice = Console.ReadLine();
    try
    {
        switch (choice)
        {
            case "1":
                studentService.CreateStudent();
                break;
            case "2":
                studentService.DeleteStudent();
                break;
            case "3":
                studentService.EditStudent();
                break;
            case "4":
                studentService.ShowStudents();
                break;
            case "5":
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
    Console.WriteLine();
}
