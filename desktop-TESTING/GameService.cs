namespace TESTING;

public class GameService
{
    private bool isPlayeing = true;

    private Player _palyer = new Player() { Damage = 16, Health = 100, Name = "Hero" };
    private Player _enemy = new Player() { Damage = 17, Health = 100, Name = "Enemy" };

    public void Start()
    {
        while (isPlayeing)
        {
            Console.WriteLine("Welcome to the game!");
            Console.Write("1. Attack: ");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();

                    if (_palyer.Health <= _enemy.Damage)
                    {
                        Console.WriteLine("Game Over, You Loose!");
                        return;
                    }

                    if (_enemy.Health <= _palyer.Damage)
                    {
                        Console.WriteLine("Game Over, You Win!");
                        return;
                    }

                    _palyer.Attack(_enemy);

                    _enemy.Attack(_palyer);
                    break;
                default:
                    isPlayeing = false;
                    break;
            }
        }
    }
}