namespace ConsoleApp2
{
    internal class Server
    {
        bool isStarted = true;
     
        Player player = new Player();
        Player enemy = new Player();

        public void Start() 
        {
            Console.WriteLine("Game Started");
            Console.WriteLine("Exit: 1");

            ConsoleKeyInfo input = Console.ReadKey();

            if (input.Key == ConsoleKey.Escape)
            {
                isStarted = false;
                return;
            }

            while (isStarted)
            {
                Console.WriteLine("");

                try
                {
                    ConsoleKeyInfo input2 = Console.ReadKey();

                    if (input2.Key == ConsoleKey.Enter)
                    {
                        Console.WriteLine("Player start attack");
                        player.Attack(enemy);

                        if (enemy.Health <= 0)
                        {
                            Console.WriteLine("Player win");
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Enemy Health: {enemy.Health}");
                        }

                        Console.WriteLine("");

                        Console.WriteLine("Enemy start attack");
                        enemy.Attack(player);

                        if (player.Health <= 0)
                        {
                            Console.WriteLine("Player loose");
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Player Health: {player.Health}");
                        }
                    }
                    else
                    {
                        throw new Exception("You can only use Enter fro attack");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
