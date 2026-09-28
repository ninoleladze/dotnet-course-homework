namespace TESTING;

public class Player()
{
    public string Name { get; set; }
    public int Health { get; set; }

    public int Damage { get; set; }

    public void TakeDamage(int damage)
    {
        Health -= damage;

        Console.WriteLine($"Player {Name} Take a Damage");
        ShowHealth();

        Console.WriteLine("");
        Console.WriteLine("--");
        Console.WriteLine("");
    }

    public void ShowHealth()
    {
        Console.WriteLine($"Health: {Health}");
    }

    public void Attack(Player enemy)
    {
        enemy.TakeDamage(Damage);
    }
}