using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JP_425_4
{
    public class Menu
    {
        public static void PrintMenu()
        {
            while (true)
            {
                Console.WriteLine("meramdene tveshi daibade:");
                int month = Convert.ToInt32(Console.ReadLine());

                switch (month)

                {
                    case 2:
                        Console.WriteLine("tebervalshi daibade");
                        break;
                    case 7:
                        Console.WriteLine("ivlisshi daibade");
                        break;
                    case 9:
                        Console.WriteLine("sektemberi daibade");
                        break;
                    case 12:
                        Console.WriteLine("dekemberi daibade");
                        break;
                    case 1:
                        Console.WriteLine("ianvri daibade");
                        break;
                    default:
                        Console.WriteLine("sxva tveshi daibade");
                        break;
                }
            }
        }
    }
}
