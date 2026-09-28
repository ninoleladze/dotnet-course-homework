namespace _9._19._2025
{
    internal class Player
    {
        private static readonly Random random = new();

        public string Name;
        public int Health;
        public bool IsBlocking;

        public Player(string name)
        {
            Name = name; 
            Health = random.Next(100, 201);
            IsBlocking = false;
        }

        public int Attack()
        {
            return random.Next(10, 21);
        }

        public void TakeDamage(int damage)
        {
            if (IsBlocking)
            {
                Console.WriteLine($"{Name} dabloka");
                IsBlocking = false;
            }
            else
            {
                Health -= damage;
                Console.WriteLine($"{Name} took {damage} damage. Health: {Health}");
            }
        }

        public void Block()
        {
            IsBlocking = true;
            Console.WriteLine($"{Name} blokavs");
        }

        public bool IsAlive => Health > 0;
    }
}