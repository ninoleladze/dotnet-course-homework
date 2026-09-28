using _1104;
using System.Text;

//Console.WriteLine("enter text: ");
////string text = Console.ReadLine();

//string path = "info.txt";
////StreamWriter sw = new StreamWriter(path);
//StreamReader sr = new StreamReader(path);
//Console.WriteLine();

////sw.WriteLine(text);

//sw.Close();\\\\\



//void Register()
//{
//    Console.WriteLine("enter username:");
//    string username = Console.ReadLine();
//    Console.WriteLine("enter email: ");
//    string email = Console.ReadLine();
//    Console.WriteLine("enter password: ");
//    string password = Console.ReadLine();

//    StreamWriter sw = new StreamWriter($"{username}.txt");

//    sw.WriteLine($"username: {username}");
//    sw.WriteLine($"email: {email}");
//    sw.WriteLine($"password: {password}");
    
//    sw.Close();
// }
//void showLogs()
//{
//    Console.WriteLine("enter username:");
//    string username = Console.ReadLine();

//    StreamReader sr = new StreamReader($"{username}.txt");

//    string info = sr.ReadToEnd();

//    Console.WriteLine(info);
//    sr.Close();
    

//}


//while (true)
//{
//    Console.WriteLine("1. register");
//    Console.WriteLine("2. show user data");
//    Console.WriteLine("enter key");
//    string key = Console.ReadLine();

//    if (key == "1")
//    {
//        Register();
//    }
//    else if (key == "2")
//    {
//        showLogs();
//    }
//    else break;


//}





//void noteInfo()
//{
//    Console.WriteLine("enter note info:");
//    string noteinfo = Console.ReadLine();
//    Console.WriteLine("enter notename");
//   string notename = Console.ReadLine();

//    StreamWriter sw = new StreamWriter($"{notename}.txt");

//    sw.WriteLine($"info: {noteinfo}");
//    sw.WriteLine($"name: {notename}");
//    sw.Close();

//}

//void infoData()
//{

//    Console.WriteLine("enter name:");
//    string notename = Console.ReadLine();

//    StreamReader sr = new StreamReader($"{notename}.txt");

//    string info = sr.ReadToEnd();

//    Console.WriteLine(info);
//    sr.Close();

//}




//while (true)
//{
//    Console.WriteLine("1. create noteinfo");
//    Console.WriteLine("2. show note data");
//    Console.WriteLine("enter key");
//    string key = Console.ReadLine();

//    if (key == "1")
//    {
//        noteInfo();
//    }
//    else if (key == "2")
//    {
//        infoData();
//    }
//    else break;
//}


Library library = new Library();
library.loadbooks();

while (true)
{
    Console.WriteLine("library");
    Console.WriteLine("1. create new book");
    Console.WriteLine("2. show all books");
    Console.WriteLine("3. delete book");

    Console.WriteLine("enter key");
    string key = Console.ReadLine();

    if (key == "1")
    {
        Console.Clear();
        library.CreateBook();
    }
    else if (key == "2")
    {
        Console.Clear();
        library.showBooks();
    }
    else if(key == "3")
    {

        Console.Clear();
        library.deletebook();
    }
    else break;
}












































