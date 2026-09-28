namespace ConsoleApp2
{
    internal class Player
    {
        private Random random = new Random();

        public int Health { get; set; }

        public Player()
        {
            Health = random.Next(100, 150);
        }

        public void TakeDamage(int Damage)
        {
            int num = random.Next(0, 100);  


            if(num > 50)
            {
                Console.WriteLine($"Damage: {Damage} -> {Damage / 2} - Blocked");
                Health -= Damage / 2;
            } else
            {
                Console.WriteLine($"Damage: {Damage}");
                Health -= Damage;
            }
        }

        public void Attack(Player enemy)
        {
            int damage = random.Next(10, 25);

            enemy.TakeDamage(damage);
        }
    }
}
