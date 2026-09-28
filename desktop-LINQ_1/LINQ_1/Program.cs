
namespace LINQ_1
{
    internal class Program
    {
        static void Main()
        {
            var service = new StudentService();

            while (true)
            {
                Console.WriteLine("students:");
                Console.WriteLine("1. show all students");
                Console.WriteLine("2. add student");
                Console.WriteLine("3. remove student");
                Console.WriteLine("4. update student");
                Console.WriteLine("5. filter students");
                Console.WriteLine("6. order students by grade");
                Console.WriteLine("7. get paged students");
                Console.WriteLine("8. group students by group");
                Console.WriteLine("9. get top student");
                Console.WriteLine("10. find student by name");
                Console.WriteLine("11. get student by id");
                Console.WriteLine("0. exit");
                Console.Write("enter your choice (0-11): ");

                var input = Console.ReadLine();
                if (!int.TryParse(input, out var choice))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input. Press Enter to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    continue;
                }

                try
                {
                    Console.Clear();
                    switch (choice)
                    {
                        case 0: return;
                        case 1: service.ShowAllStudents(); break;
                        case 2: service.AddStudent(); break;
                        case 3: service.RemoveStudent(); break;
                        case 4: service.UpdateStudent(); break;
                        case 5: service.FilterStudentsInteractive(); break;
                        case 6: service.OrderStudentsByGradeInteractive(); break;
                        case 7: service.GetPagedStudentsInteractive(); break;
                        case 8: service.GroupStudentsInteractive(); break;
                        case 9: service.ShowTopStudent(); break;
                        case 10: service.FindStudentByNameInteractive(); break;
                        case 11: service.GetStudentByIdInteractive(); break;
                        default: Console.WriteLine("Unknown choice."); break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                Console.WriteLine("\nPress Enter to continue...");
                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}