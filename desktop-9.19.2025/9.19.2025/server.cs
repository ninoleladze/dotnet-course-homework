using System;

namespace _9._19._2025
{
    internal class Server
    {
        public bool isPlaying = true;
        public readonly Player player;
        public readonly Player enemy;
        public static readonly Random random = new();

        public Server()
        {
            player = new Player("Player");
            enemy = new Player("Enemy");
        }
        public void Start()
        {
            Console.WriteLine("Welcome");
            Console.WriteLine($"{player.Name} Health: {player.Health}");
            Console.WriteLine($"{enemy.Name} Health: {enemy.Health}");

            while (isPlaying)
            {
                Console.WriteLine("airchie 1-Attack  2-Block ");
                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        int playerDamage = player.Attack();
                        Console.WriteLine($"{player.Name} attacks for {playerDamage} damage!");
                        enemy.TakeDamage(playerDamage);
                        break;
                    case "2":
                        player.Block();
                        break;
                    default:
                        isPlaying = false;
                        continue;
                }

                if (!enemy.IsAlive)
                {
                    Console.WriteLine("You win!");
                    break;
                }

                if (random.Next(2) == 0)
                {
                    int enemyDamage = enemy.Attack();
                    Console.WriteLine($"{enemy.Name} attacks for {enemyDamage} damage!");
                    player.TakeDamage(enemyDamage);
                }
                else
                {
                    enemy.Block();
                }

                if (!player.IsAlive)
                {
                    Console.WriteLine("You have been defeated!");
                    break;
                }
            }
            Console.WriteLine("Game over.");
        }
    }
}