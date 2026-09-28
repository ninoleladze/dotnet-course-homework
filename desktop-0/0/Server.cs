using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    internal class Server
    {
        bool Isstarted= true;

        Player player = new Player();
        Player enemy = new Player();

        public void Start()
        {
            Console.WriteLine("game started");
            Console.WriteLine("exit:esc");
                    ConsoleKeyInfo input= Console.ReadKey();
                  
                    if (input.Key == ConsoleKey.Escape)
                    {
                        Isstarted = false;
                        return;

                    }

            while (Isstarted)
            {
                Console.WriteLine
                    ();


                try
                {
                    ConsoleKeyInfo input2 = Console.ReadKey();
                    if (input2.Key == ConsoleKey.Enter) {

                        Console.WriteLine("Player start attack");
                        player.Attack(enemy);
                        if (enemy.health <= 0)
                        {
                            Console.WriteLine("player win");
                            return;
                        }
                        else
                        {
                            Console.WriteLine($"Enemy stats: {enemy.health}");
                        }

                        Console.WriteLine("");

                        Console.WriteLine("enemy start attack");
                        enemy.Attack(player);



                        if (player.health <= 0)
                        {
                            Console.WriteLine("player loose");
                            return;
                        }
                        else
                        {

                            Console.WriteLine($"player stats: {player.health}");
                        }
                    }


                    else {
                        throw new Exception("you can only use enter for attack");
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
