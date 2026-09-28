using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace backnew222hm
{
    internal interface Vehicle
    {
        void Drive();
        int Refuel(int amount);
    }
    internal class Car : Vehicle
    {
        private int fuel;
        public Car(int mainfuel)
        {
            fuel = mainfuel;
        }

        public void Drive()
        {
            if (fuel > 0)
            {
                Console.WriteLine("manqana modzraobss");
            }
            else
            {
                Console.WriteLine("manqana ver modzraobs benzini araa.");
            }
        }
        public int Refuel(int amount)
        {
            fuel += amount;
            Console.WriteLine($"sheivso {amount} litri. axlandeli benzinis raodenoba {fuel} ");
            return fuel;
        }
    }
}