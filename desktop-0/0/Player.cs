using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0
{
    internal class Player
    {  public Player()
        {
            health = random.Next(100, 150);    
        }
        
       private Random random = new Random();
        public int health { get; set; }
      
        public void TakeDamage(int Damage)
        {
            int num = random.Next(0, 100);
            if (num > 50)
            {
                Console.WriteLine($"damage:{Damage}---->{Damage/2}- blocked");
              health -= Damage/2;
            }
            else
            {
                Console.WriteLine($"damage:{Damage}");
                health -= Damage;
            }
           
        }

        public void Attack(Player enemy)
        {
            int damage = random.Next(10, 25);

            enemy.TakeDamage(damage);

        }
    }
}
