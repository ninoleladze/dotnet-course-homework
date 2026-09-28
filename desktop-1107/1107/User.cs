using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1107
{
    internal class User
    {
        private static int _counter = 1;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public User()  =>Id = _counter++;

        public void showinfo(){

            Console.WriteLine($"id: {Id}, name: {Name}, email: {Email} ");

            }
    }
}
