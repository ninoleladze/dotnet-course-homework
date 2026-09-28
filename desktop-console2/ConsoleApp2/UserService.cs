using System.Text.Json;

namespace ConsoleApp2
{
    internal class UserService
    {
        private List<User> usersList = new List<User>();
        private string path = "users.json";
        private User? LoggedInUser = null;

        public void LoadUsers()
        {
            if (File.Exists(path))
            {
                string json = File.ReadAllText(path);

                var data = JsonSerializer.Deserialize<List<User>>(json);

                if (data != null) usersList = data;
            }
        }

        public void Register()
        {
            Console.Write("Enter username: ");
            string username = Console.ReadLine();

            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var userExists = usersList.FirstOrDefault(x => x.Email == email);

            if (userExists != null)
            {
                Console.WriteLine("User already exists");
            }
            else
            {
                User user = new User()
                {
                    Username = username,
                    Password = password,
                    Email = email
                };

                usersList.Add(user);
                SaveData();

                Console.WriteLine("Registered successfully.");
            }
        }
        public void Login()
        {
            Console.Write("Enter email: ");
            string email = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            var user = usersList
                .FirstOrDefault(e => e.Email == email && e.Password == password);

            if (user == null)
            {
                Console.WriteLine("User not found!");
            }
            else
            {
                LoggedInUser = user;
                Console.WriteLine("User logged in successfully!");
            }
        }
        public void ShowUsers()
        {
            foreach (var user in usersList)
            {
                user.ShowInfo();
            }
        }
        public void Logout()
        {
            if (LoggedInUser == null)
            {
                Console.WriteLine("User is not logged in!");
            }
            else
            {
                LoggedInUser = null;
            }
        }
        public void ShowLoggedInUser()
        {
            if (LoggedInUser == null)
            {
                Console.WriteLine("User is not logged in!");
            }
            else
            {
                LoggedInUser.ShowInfo();
            }
        }

        private void SaveData()
        {
            string json = JsonSerializer.Serialize(usersList);

            File.WriteAllText(path, json);
        }
    }
}
