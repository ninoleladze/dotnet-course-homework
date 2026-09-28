using _1111.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace _1111.Services
{
    internal class TodoService
    {
        private List<Todo> todolist
             = new List<Todo>();
        private string path = "todos.json";

        public void LoadTodos()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);
                var data = JsonSerializer.Deserialize<List<Todo>>(json);
                if(data != null)todolist = data;
            }
        }

        public void createtodo()
        {
            Console.WriteLine("enter todo title: ");
            string title = Console.ReadLine();

            if (string.IsNullOrEmpty(title)) throw new Exception("title is requered");
            Console.WriteLine("enter due date day");
            int day = int.Parse(Console.ReadLine());

            if (day < 1) throw new Exception("min day is 1");

            if (UsersService.currentUser == null) throw new Exception("unauthorized");
            Todo todo = new Todo()
            {
                Title = title,
                userid= UsersService.currentUser.Id,
                DueDate = DateTime.UtcNow.AddDays(day)
                

            };
            todolist.Add(todo);
            savedata();
            Console.WriteLine("todo created successfully");


        }

        public void edittodo()
        {
            showtodos();
            Console.WriteLine("enter todo id:");
            int id = int.Parse(Console.ReadLine());

            if (UsersService.currentUser == null) throw new Exception("unauthorized");

            var todo = todolist.FirstOrDefault(t => t.Id == id&& t.userid == UsersService.currentUser.Id);
            if (todo == null) throw new Exception("todo not found");

            Console.WriteLine("");
            Console.WriteLine($"seleccted todo: {todo}");

            Console.WriteLine("enter todo title: ");
            string title = Console.ReadLine();

            if (!string.IsNullOrEmpty(title)) todo.Title = title;
            Console.WriteLine("enter due date day");
            string dayinput = Console.ReadLine();


            if (!string.IsNullOrEmpty(dayinput))
            {
                int day = int.Parse(dayinput);

            if (day < 1) throw new Exception("min day is 1");

            todo.DueDate = DateTime.UtcNow.AddDays(day);
            



            }
          
            savedata();
            Console.WriteLine("todo list updated successfully");




        }

        public void deletetodo()
        {
            showtodos();

            Console.WriteLine("enter todo id:");
            int id = int.Parse(Console.ReadLine());
            if (UsersService.currentUser == null) throw new Exception("unauthorized");
            var todo = todolist
                .FirstOrDefault(t=> t.Id == id && t.userid ==UsersService.currentUser.Id);

            if (todo == null) throw new Exception("todo not found");
            todolist.Remove(todo);
            savedata();
            Console.WriteLine("todo deleted successfully");
        }

        public void showtodos()
        {
            if (UsersService.currentUser == null) throw new Exception("unauthorized");
            var todo = todolist
                .Where(t=>  t.userid == UsersService.currentUser.Id   )
                .ToList();

            if (!todo.Any()) throw new Exception("you dont have any todo");

            foreach (var item in todo)
            {
                Console.WriteLine(item);
            }



        }

        public void filtertodos()
        {

            Console.WriteLine("enter todo title: ");
            string title = Console.ReadLine();

            var todos = todolist.Where(t=> t.Title.ToLower().Contains(title.ToLower())).ToList();

            if (!todos.Any()) throw new Exception($"todos not found based on your search: {title}");

            foreach (var item in todos)
            {
                Console.WriteLine(item);
                
            }






        }


        private void savedata()
        {
            string json = JsonSerializer.Serialize(todolist);
            File.WriteAllText(path, json);
        }


    }
}
