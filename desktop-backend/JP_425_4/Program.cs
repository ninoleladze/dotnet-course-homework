using JP_425_4;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.ExceptionServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

class Program
{
    //runtime - კოდის გაშვების პროცესი რომელიც უკან მიმდინარეობს
    //CLR  - COMMON LANGUAGE RUNTIME - შეკრული კოდი
    //COMPILER - ის რაც კოდს კრავს აპლიკაციად
    //access modifier - public , private , internal 
    // return type - CLASS , DATA TYPE , VOID ----- არაფერს არ აბრუნებს
    public static void Main()
    {



        //Console.WriteLine("GAMARJOBA"); //მთელ ხაზს იკავებს
        //Console.Write("sheni asaki:"); // არ იკავებს მთლიან ხაზს
        //var age = Console.ReadLine(); // ელოდება მომხარებლის პასუხს და ანიჭებს მას ცვლადს
        //Console.WriteLine($"shen xar {age} wlis");

        // რიცხვებთან სამუშაო data type ს
        //int number = 25;
        //double priceOfCocaCola = 1.8;
        //float fll = 3.1341114f;
        //decimal salary = 1998.72m;
        //long  bigsalary = 212191118310318212;

        ////ტექსტთან სამუშაო data types
        //string name = "nini";
        //char letter = '5';

        //// ჭეშმარიტება / არა ჭეშმარიტება , სიმართლე / სიცრუე , true / false
        //bool isAdult = false;
        //bool isFemale = true;

        //Console.WriteLine("sheni xelfasi :");
        //int salary2 = Convert.ToInt32(Console.ReadLine());
        //Console.WriteLine($"xelfasi : {salary2} ");

        // არითმეტიკული ოპერატორები ( + , - , / გაყოფა , * გამრავლეა , % ნაშთი)

        // ლოგიკური ოპერატორები ( && და , || ან , ! not (შებრუნება) ) 

        //if (isAdult == true || isFemale == false)
        //{
        //    Console.WriteLine("zrdasruli momxmarebeli");
        //}
        //else if (!isAdult)
        //{
        //    Console.WriteLine("mivkidit sigarets");
        //}
        //else
        //{
        //    Console.WriteLine("ver gaiaret avtorizacia");
        //}
        //while (true)
        //{
        //    Console.Write("kviris romeli dghea?");
        //    int day = Convert.ToInt32(Console.ReadLine());
        //    if (day < 8)
        //    {
        //        switch (day)
        //        {
        //            case 1:
        //                Console.WriteLine("orshabati");
        //                break;
        //            case 2:
        //                Console.WriteLine("samshabati");
        //                break;
        //            case 3:
        //                Console.WriteLine("otxshabati");
        //                break;
        //            case 4:
        //                Console.WriteLine("xutshabati");
        //                break;
        //            case 5:
        //                Console.WriteLine("paraskevi");
        //                break;
        //            default:
        //                Console.WriteLine("shabati an kvira");
        //                break;
        //        }
        //    }
        //    else
        //    {
        //        Console.WriteLine("araswori dgheta ricxvi");
        //    }
        //}



        //Console.WriteLine("meramdene tveshi daibade:");
        //int month = Convert.ToInt32(Console.ReadLine());

        //switch (month) 

        //{
        //    case 2 :
        //        Console.WriteLine("tebervalshi daibade");
        //        break;
        //    case 7:
        //        Console.WriteLine("ivlisshi daibade");
        //        break;
        //    case 9:
        //        Console.WriteLine("sektemberi daibade");
        //        break;
        //    case 12:
        //        Console.WriteLine("dekemberi daibade");
        //        break;
        //    case 1:
        //        Console.WriteLine("ianvri daibade");
        //        break;
        //    default :
        //        Console.WriteLine("sxva tveshi daibade");
        //        break;  
        //}



        //ციკლები   (loop) - არის კოდის კონსტრუქცია რომელიც საშუალეაბს გვაძლევს რომ გავიმეოროთ კოდი მრავალჯერ რაიმე პირობის მიხედვით

        //ოპტიმიზაცია - რომ კოდის განმეორებით დაწერა ავირიდოთ თავიდან
        // ავტომატიზაცია - მონაცემთა ჯგუფის დამუშავებაში გვეხმარება : სიები, მასივები
        //ეფექტურობა - სწრაფია

        //for , while , do-while , foreach 

        //for -- გამოიყენება მაშინ როცა წინასწარ ვიცით რამდენჯერ უნდა განმეორდეს ციკლი
        // ვქმნით ცვლადს ; პირობა; ცვლილება;
        //for (int i = 30; i <= 90; i++)
        //{
        //    Console.WriteLine($"i = {i}");
        //}

        //while -- უცნობია რამდენჯერ გვინდა მგრამ ვიცით პირობა --- 

        //bool hasInsurance = true;
        //while (hasInsurance)
        //{


        //}
        //do - while -- როგორც მინიმუმ ასრულებს 1 იტერაციას და შედეგ ამოწმებ პირობას
        //int i = 4;
        //do
        //{
        //    i++;
        //    i++;

        //    Console.WriteLine($"i : {i}");

        //} while (i < 3);




        //for each
        //როდესაც ვმუშაობ მონაცემებზე 


        //string[] fruits = { "apple", "pineapple", "cherry" };

        //Console.WriteLine(fruits[2]);


        //nested loops  გამოიყენება მაშინ როცა ერთ ციკლში ვამუშავებთ მეორე ციკლს

        //for (int i = 1; i <= 4; i++)
        //{
        //    for (int j = 1; j <= 3; j++)
        //    {
        //        Console.WriteLine($"i :{i}   j : {j}");
        //    }
        //}

        // რა არს მასივები  - არის მონაცემთა სტრუქტურა რომელიც ინახავს ერთი და იგივე ტიპის ელემენტებს მეხსიერებაში
        // რატომ ვიყენებთ მასივებს : მრავალ მონაცემზე გვქონდეს ერთდროულად წვდომა ,
        // მეხსიერებასთან ვიმუშაოთ ოპტიმალურად ,მონაცემების მარტივი დახარისხბა და ძიება

        //int[] numbers = new int[5];
        //numbers[0] = 1;
        //numbers[1] = 2;
        //numbers[2] = 3;
        //numbers[3] = 4;
        //numbers[4] = 5;
        //foreach (var number in numbers)
        //{
        //    Console.WriteLine($"i : {number}");
        //}

        //int[] numbers2 = { 1, 2, 3, 4, 33131,21,23 };


        //char[] prices = new char[] { 'a', '2', '8' };

        //Console.WriteLine(numbers2.Length);
        //Console.WriteLine(Array.IndexOf(numbers2, 3));


        //for (int z = 0; z <= numbers2.Length; z++) 
        //{
        //    Console.WriteLine(numbers2[z]);
        //}




        //int[][] jaggedArray = new int[3][];
        //jaggedArray[0] = new int[] { 1, 2, 3 };
        //jaggedArray[1] = new int[] { 3 };
        //jaggedArray[2] = new int[] { 13, 31, 2, 4, 6 };


        //Console.WriteLine(jaggedArray[2][4]);


        //int[] original = { 2, 3, 6, 8 };
        //int[] copy = (int[])original.Clone();

        ////foreach (int i in copy) 
        ////{
        ////    Console.WriteLine(i);
        ////}

        //string[] cars = { "Volvo", "BMW", "Ford", "Mazda" };
        ////Array.Sort(cars);

        //Array.Reverse(cars);
        //foreach (string car in cars)
        //{
        //    Console.WriteLine(car);
        //}

        //სტრინგები - არის სიმბოლოთა წყობა (CHAR ARRAY)
        // სტრინგი არის IMMUTABLE  - როდესაც შევცვლით სტრინგს შეიქმნება ახალი ობიექტი
        //string name = "niNi";

        //Console.WriteLine(name.Contains("li"));
        //Console.WriteLine(name.StartsWith("n"));
        //Console.WriteLine(name.EndsWith("n"));
        //length , name[0]
        //mutable 

        //StringBuilder sb = new StringBuilder();
        //sb.Append("name:");
        //sb.Append("lasha");
        //Console.WriteLine(sb.ToString());


        //concat

        //string saxeli = "gio";
        //string gvari = "kapanadze";
        ////string fullname = saxeli + " " + gvari;
        //string fullName = string.Concat(saxeli, "", gvari);
        //Console.WriteLine(fullName);

        //Console.WriteLine(saxeli==gvari);
        //Console.WriteLine(saxeli.Equals(gvari, StringComparison.OrdinalIgnoreCase));

        ////substring
        //string text = "hello world";
        //string sub = text.Substring(3,6);
        //Console.WriteLine(sub);

        //indexOf
        //string text = "good morning";
        //int sub = text.IndexOf("g");
        //Console.WriteLine(sub);

        ////replace

        //string text1 = "today is rainy day";
        //string replaced = text1.Replace("rainy", " sunny");
        //Console.WriteLine(replaced);

        //split

        //string text2 = "apple.banana.cherry";
        //string[] fruits = text2.Split(".");
        //foreach (string fruit in fruits) 
        //{
        //    Console.WriteLine(fruit);
        //}


        //მეთოდები
        //loose coupling
        // რა არის მეთოდი -- მეთოდი არის კოდის ბლოკი რომელიც ასრულებს
        // გარკვეულ დავალებას და შეიძლება რომ მრავალჯერ გავიმეოროთ  


        //[access modifier] [return type] Name (parameter)
        //{
        //      code 
        //      return value 
        //}

        //void -- დამაბრუნებელი ტიპი რომელი არ აბრუნებს არაფერს

        //int age = Convert.ToInt32(Console.ReadLine());
        //string? name5 = Console.ReadLine();
        //if(age > 18) 
        //{
        //    SayHello(name5);
        //}

        //int x = 5; 
        //UpdateValues(ref x);
        //Console.WriteLine(x);


        int x, y;
        GetValues(out x, out y);
        Console.WriteLine(x + " " + y);
    }

    public static void UpdateValues(ref int num) 
    {
        num = 100;
    }
    public static void GetValues(out int a, out int b) 
    {
         a = 5;
        b = 100;
    }
    
    
    public static void SayHello(string name3) 
    {
        Console.WriteLine($"gamarjoba {name3}");
    }


    public static int Sum(int a, int b) 
    {
        return a + b;         
    }

}
