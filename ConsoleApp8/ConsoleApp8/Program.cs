using ConsoleApp8;
using System.Linq;

//List<Student> students = new List<Student>()
//{
//    new Student(){Id=1,Name="nini"},
//    new Student(){Id=2, Name="nika"},
//     new Student(){Id=3,Name="nino"},
//    new Student(){Id=4, Name="inga"},
//     new Student(){Id=5,Name="mari"},
//    new Student(){Id=6, Name="gio"},


//};

//void FilterStudentsByName(string name)
//{
//    var student = students.Where(student => student.Name.ToLower().Contains(name.ToLower())).ToList();
//    foreach (var item in student)
//    {
//        Console.WriteLine($"id: {item.Id}, name: {item.Name}");
//    }


//}

//void getstudentbyid(int id)
//{
//    var student =students.FirstOrDefault(student => student.Id == id);
//    if (student == null)
//    {
//        Console.WriteLine("student not found");
//    }
//    else
//    {

//        Console.WriteLine($"id: {student.Id}, name: {student.Name}");
//    }
//}

//Console.WriteLine("Enter Name:  ");
//    string name = Console.ReadLine();
//   FilterStudentsByName (name);


//Console.WriteLine("enter id");
//int id = int.Parse(Console.ReadLine());
//getstudentbyid(id);



//List<Student> students = new List<Student>()
//{
//    new Student(){Id=1,Name="nini"},
//    new Student(){Id=2, Name="nika"},
//     new Student(){Id=3,Name="nino"},
//    new Student(){Id=4, Name="inga"},
//     new Student(){Id=5,Name="mari"},
//    new Student(){Id=6, Name="gio"},


//};


List<Product> products = new List<Product>() { 
   new Product(){Id=1,Title="title 1"},
   new Product(){Id=2,Title="title 2"},
   new Product(){Id=3,Title="title 3"},
   new Product(){Id=4,Title="title 4"},
   new Product(){Id=5,Title="title 5"},
   new Product(){Id=6,Title="title 6"},
   new Product(){Id=7,Title="title 7"},
};
void FilterStudentsByName(string title)
{
    var product = products.Where(product => product.Title.ToLower().Contains(title.ToLower())).ToList();
    foreach (var item in products)
    {
        Console.WriteLine($"id: {item.Id}, name: {item.Title}");
    }
}
Console.WriteLine("Enter Name:  ");
string name = Console.ReadLine();
FilterStudentsByName(name);


void getstudentbyid(int id)
{
    var product = products.FirstOrDefault(product => product.Id == id);
    if (product == null)
    {
        Console.WriteLine("student not found");
    }
    else
    {

        Console.WriteLine($"id: {product.Id}, name: {product.Title}");
    }
}
Console.WriteLine("enter id");
int id = int.Parse(Console.ReadLine());
getstudentbyid(id);