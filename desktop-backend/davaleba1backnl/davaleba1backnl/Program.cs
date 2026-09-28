class Program
{
    static void Main()
    {
        /////davaleba1 ///luwia/kentia///
        Console.Write("sheiyvane ricxvi: ");
        int number = Convert.ToInt32(Console.ReadLine());
        if (number % 2 == 0)
        {
            Console.WriteLine("luwia");
        }
        else
        {
            Console.WriteLine("kentia");
        }


        ////davaleba2/////operatorebi///
        int x = 10;
        Console.WriteLine($" x  = {x}");
        x += 8;
        Console.WriteLine($"mimateba x + 8 = {x}");
        x -= 6;
        Console.WriteLine($"gamokleba x - 6 = {x}");
        x *= 3;
        Console.WriteLine($"gamravleba x * 3 = {x}");
        x /= 4;
        Console.WriteLine($"gayofa x / 4 = {x}");


        ////davaleba mesame////nishnis gansazgvra////
        Console.Write("shemoiyvane ricxvi dadebiti an uaryofiti: ");
        int signNum = Convert.ToInt32(Console.ReadLine());
        if (signNum > 0)
        {
            Console.WriteLine("dadebiti");
        }
        else if (signNum < 0)
        {
            Console.WriteLine("uaryofiti");
        }
        else
        {
            Console.WriteLine("nulia");
        }



        ////davaleba4////////kviris dge switch-case////
        Console.Write("sheiyvane ertidan shvidamde ");
        int day = Convert.ToInt32(Console.ReadLine());
        switch (day)
        {
            case 1:
                Console.WriteLine("orshabati");
                break;
            case 2:
                Console.WriteLine("samshabati");
                break;
            case 3:
                Console.WriteLine("otxshabati");
                break;
            case 4:
                Console.WriteLine("xutshabati");
                break;
            case 5:
                Console.WriteLine("paraskevi");
                break;
            case 6:
                Console.WriteLine("shabati");
                break;
            case 7:
                Console.WriteLine("kvira");
                break;
            default:
                Console.WriteLine("arasworia sheiyvane 1-7mde");
                break;
        }



        ////////davaleba5////chashenebuli piroba ////
        Console.Write("sheiyvane asaki: ");
        int age = Convert.ToInt32(Console.ReadLine());
        Console.Write("sheiyvane erovneba: ");
        var nationality = Console.ReadLine(); 

        if (age >= 18 && nationality == "qartveli")
        {
            Console.WriteLine("moqalaqe da srulwlovani");
        }
        else
        {
            Console.WriteLine("motxovnebs ar akmayofilebs");
        }
    }
}