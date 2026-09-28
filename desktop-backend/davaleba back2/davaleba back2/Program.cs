class Program
{
    static void Main()
    {
        // davaleba 1: 
        Console.Write("sheiyvane N: ");
        int n = Convert.ToInt32(Console.ReadLine());
        int sum = 0;
        int i = 1;
        while (i <= n)
        {
            sum = sum + i;
            i = i + 1;
        }
        Console.WriteLine("jami: " + sum);

        // davaleba 2: cifrta raodenoba
        Console.Write("sheiyvane ricxvi: ");
        int num = Math.Abs(Convert.ToInt32(Console.ReadLine()));
        int cifrebi = 0;
        if (num == 0)
        {
            cifrebi = 1;
        }
        else
        {
            while (num > 0)
            {
                cifrebi = cifrebi + 1;
                num = num / 10;
            }
        }
        Console.WriteLine("cifrebis raodenoba: " + cifrebi);

        // davaleba 3: gamravlebis tabula
        for (int a = 1; a <= 10; a++)
        {
            for (int b = 1; b <= 10; b++)
            {
                Console.WriteLine(a+"x"+b+"="+(a*b));
            }
        }

        // davaleba 4: sheyvana uarqopitamde
        int raodenoba = 0;
        int value;
        do
        {
            Console.Write("sheiyvane ricxvi: ");
            value = Convert.ToInt32(Console.ReadLine());
            if (value >= 0)
            {
                raodenoba = raodenoba + 1;
            }
        } while (value >= 0);
        Console.WriteLine("sheyvanili ricxvebis raodenoba: " + raodenoba);

        ////////// davaleba 5: 3-is jeradebis sashualo
        int jami = 0;
        int jeradi = 0;
        for (int j = 1; j <= 100; j++)
        {
            if (j % 3 == 0)
            {
                jami = jami + j;
                jeradi = jeradi + 1;
            }
        }
        Console.WriteLine("3-is jeradebis sashualo: " + ((double)jami / jeradi));

        /// davaleba 6: palindromia tu ara
        Console.Write("sheiyvane ricxvi: ");
        string s = Console.ReadLine()!;
        Console.WriteLine(s == new string(s.Reverse().ToArray()) ? "ki" : "ara");

        // davaleba 7: martivi ricxvebi 1-dan 100-mde
        for (int p = 2; p <= 100; p++)
        {
            bool martivi = true;
            for (int d = 2; d * d <= p; d++)
                if (p % d == 0) { martivi = false; break; }
            if (martivi) Console.Write(p + " ");
        }
        Console.WriteLine();

        // davaleba 8: naiarapormis samkutxedi
        for (int t = 1; t <= 12; t++)
            Console.WriteLine(new string('*', t));

        // davaleba 9: parolis mcdelobebi
        string paroli = "ninilamazia";
        int tries = 3;
        while (tries > 0)
        {
            Console.Write("sheiyvane paroli: ");
            string input = Console.ReadLine()!;
            if (input == paroli)
            {
                Console.WriteLine("wvdoma nebadartulia.");
                break;
            }
            else
            {
                tries = tries - 1;
                if (tries == 0)
                {
                    Console.WriteLine("shen dablokili xar");
                }
                else
                {
                    Console.WriteLine("darchebuli cdebi: " + tries);
                }
            }
        }
    }
}