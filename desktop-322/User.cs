namespace ConsoleApp2
{
    internal class User
    {
        private static int _counter = 1;

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public User() => Id = _counter++;

        public void ShowInfo()
        {
            Console.WriteLine($"ID: {Id}, Username: {Username}, Email: {Email}");
        }
    }
}
