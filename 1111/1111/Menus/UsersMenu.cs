using _1111.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1111.Menus
{
    internal class UsersMenu
    {
        private static UsersService _usersService = new UsersService();
        public static void start()
        {
            while (true)
            {
                Console.WriteLine("---authorization menu----------");
                Console.WriteLine("1. register");
                Console.WriteLine("2. login");
                Console.WriteLine("3. logout");
                Console.WriteLine("4. exit");

                Console.WriteLine("enter key:");
                string key = Console.ReadLine();
                if (key == "1")
                {
                    _usersService.Register();
                }
                else if (key == "2")
                {
                    _usersService.Login();
                }
                else if (key == "3")
                {
                    _usersService.logout();
                }
                else if (key == "4") {
                break;
                }
                else
                {
                    Console.WriteLine("invalid");
                }
              


                }

            }
        }
    }

