class Program {
    static void Main()
    {
        void Func()
        {
            try
            {
                int num = int.Parse(Console.ReadLine());
                Console.WriteLine(num);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


        }
        Func();
    }
}