using _1111.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1111.Menus
{
    internal class TodosMenu
    {
        private static TodoService _todoService = new TodoService();
        public static void Start()
        {
            while (true)
            {
                try
                {
                    Console.WriteLine("===todo====");
                    Console.WriteLine("1. create todo");
                    Console.WriteLine("2. edit todo");
                    Console.WriteLine("3. delete todo");
                    Console.WriteLine("4. show todo");
                    Console.WriteLine("5. filter todo");
                    Console.WriteLine("6. exit");
                    Console.WriteLine("enter key:");
                    string key = Console.ReadLine();


                    if (key == "1")
                    {
                        Console.Clear();
                        _todoService.createtodo();
                    }
                    else if (key == "2")
                    {

                        Console.Clear();
                        _todoService.edittodo();
                    }
                    else if (key == "3")
                    {
                        Console.Clear();
                        _todoService.deletetodo();
                    }
                    else if (key == "4")
                    {

                        Console.Clear();
                        _todoService.showtodos();
                    }
                    else if (key == "5")
                    {
                        Console.Clear();
                        _todoService.filtertodos();
                    }
                    else if (key == "6")
                    {


                        Console.Clear();
                        break;

                        
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                }
        }
    }
                        }
                    
                

           



            
        
    

