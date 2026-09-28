namespace backnew222hm
{
    internal class Program
    {
        static void Main()
        {
            Car myCar = new Car(0);
            Console.Write("miutite ramdeni daematos benzini: ");
            try
            {
                int fuelAmount = Convert.ToInt32(Console.ReadLine());
                myCar.Refuel(fuelAmount);
            }
            catch
            {
                Console.WriteLine("araswori");
            }
            myCar.Drive();
        }
    }
}