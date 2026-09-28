
using _1031;

StudentService studentService = new StudentService();

while (true)
{
    Console.WriteLine("Student List:");
    Console.WriteLine("1. Create Student");
    Console.WriteLine("2. Delete Student");
    Console.WriteLine("3. Edit Student");
    Console.WriteLine("4. Show Students");
    Console.WriteLine("5. Filter Students");
    Console.WriteLine("6. Show Student Details");
    Console.WriteLine("7. show student username  ");
    Console.WriteLine("8. Exit");
    Console.Write("Select an option: ");
    string choice = Console.ReadLine();
    try
    {
        switch (choice)
        {
            case "1":
                Console.Clear();
                studentService.createStudent();
                break;
            case "2":
                Console.Clear();
                studentService.deleteStudent();
                break;
            case "3":
                Console.Clear();
                studentService.editStudent();
                break;
            case "4":
                Console.Clear();
                studentService.showStudents();
                break;
            case "5":
                Console.Clear();
                studentService.filterStudents();
                break;
            case "6":
                Console.Clear();
                studentService.showStudentDetails();
                break;
            case "7":
                Console.Clear();
                studentService.showstudentsusername();
                break;
            case "8":
                Console.Clear();
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }

    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}







