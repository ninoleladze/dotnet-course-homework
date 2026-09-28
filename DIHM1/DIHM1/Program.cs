
            // 1 პირადი ინფორმაცია

            // ტექსტია, ამიტომ string
            string name = "Nino Leladze";

            // string-ში ვინახავ რადგან არითმეტიკაში არ გვჭირდება
            string personalNumber = "01019087452";

            // byte საკმარისია (0-255)
            byte age = 24;

            // ერთი ასოა ('M' ან 'F'), ამიტომ char და არა string
            char gender = 'F';

            // ტექსტია, string
            string email = "nino.leladze@mybank.ge";

            // აქვს "+" სიმბოლო, ამიტომ რიცხვში ვერ ჩავდებ  string
            string phone = "+995577894521";


            // 2 საბანკო ანგარიშის ინფორმაცია

            // ასოები + ციფრები, string
            string iban = "GE45TB7654300101874523";

            // ფული - ყოველთვის decimal (float/double-ს აქვს ცდომილება)
            // 'm' სუფიქსი ნიშნავს რომ decimal ლიტერალია
            decimal balance = 8742.30m;

            // 2021 ჩაეტევა short-ში (-32768 დან 32767-მდე), int ფუჭად დახარჯავდა მეხსიერებას
            short openYear = 2021;

            // ქულები შეიძლება ბევრი დაგროვდეს, ამიტომ int (short შეიძლება არ ეყოს)
            int loyaltyPoints = 320;


            // 3 სტატუსები

            // ყველა მათგანი არის "კი/არა", ამიტომ bool
            bool isActive = true;
            bool isVerified = true;
            bool smsOn = false;
            bool isPremium = false;


            // 4 ფინანსური მონაცემები

            // ფული, იმიტომ decimal (ბანკში ფული ყოველთვის ზუსტი უნდა იყოს)
            decimal income = 36000.50m;

            // float-ი 7 ციფრამდე სიზუსტე აქვს, 5000 უპრობლემოდ ჩაეტევა
            // 'f' სუფიქსი = float ლიტერალი
            float creditLimit = 3000.00f;

            // double-ი 15-17 ციფრიანი სიზუსტისაა, კურსის გათვლისთვის საკმარისია
            double usdRate = 2.7234;


            // 5  დამატებითი ინფორმაცია 

            // 2 მილიარდზე მეტი რიცხვი int-ში ვერ ჩაეტევა (int max ≈ 2.14 მილიარდი)
            // ამიტომ long
            long totalTransactions = 1247865;


            // Console-ში გამოტანა 

            Console.WriteLine("=================================================");
            Console.WriteLine("           MyBank - Client Information           ");
            Console.WriteLine("=================================================");

            Console.WriteLine("\n--- Personal Info ---");
            Console.WriteLine($"Name:             {name}");
            Console.WriteLine($"Personal Number:  {personalNumber}");
            Console.WriteLine($"Age:              {age}");
            Console.WriteLine($"Gender:           {gender}");
            Console.WriteLine($"Email:            {email}");
            Console.WriteLine($"Phone:            {phone}");

            Console.WriteLine("\n--- Bank Account ---");
            Console.WriteLine($"IBAN:             {iban}");
            Console.WriteLine($"Balance:          {balance} GEL");
            Console.WriteLine($"Open Year:        {openYear}");
            Console.WriteLine($"Loyalty Points:   {loyaltyPoints}");

            Console.WriteLine("\n--- Statuses ---");
            Console.WriteLine($"Active:           {isActive}");
            Console.WriteLine($"Verified (KYC):   {isVerified}");
            Console.WriteLine($"SMS Notifications:{smsOn}");
            Console.WriteLine($"Premium Client:   {isPremium}");

            Console.WriteLine("\n--- Finances ---");
            Console.WriteLine($"Annual Income:    {income} GEL");
            Console.WriteLine($"Credit Limit:     {creditLimit} GEL");
            Console.WriteLine($"USD/GEL Rate:     {usdRate}");

            Console.WriteLine("\n--- Statistics ---");
            Console.WriteLine($"Total Transactions: {totalTransactions}");

            Console.WriteLine("\n=================================================");


//ბონუს შეკითხვებზე პასუხები:

//1. რატომ არ უნდა გამოვიყენოთ float ფულისთვის?
//   float და double-ი რიცხვებს ბინარულ ფორმატში ინახავენ.
//   ბევრი ათობითი წილადი (0.1, 0.2 და ა.შ.) ბინარულად ზუსტად ვერ ჩაიწერება.
//   ამიტომ 0.1 + 0.2 ხდება 0.30000000000000004.
//   თუ ბანკი ყოველი ტრანზაქციისას 0.01 თეთრს კარგავს - მილიონი ტრანზაქციის
//   შემდეგ ეს ხდება დიდი ფული. decimal-ი base-10-ში ინახავს რიცხვებს და
//   ცდომილებას არ აქვს.

//2. რა მოხდება თუ პირად ნომერს long-ში შევინახავთ?
//   - 0-ით დაწყებული ნომრები დააკარგავენ ნულს (01024085739 -> 1024085739)
//   - არითმეტიკაში არასოდეს გამოვიყენებთ, ანუ რიცხვითი ტიპი ფუჭია
//   - ფორმატირება (დეფისების დამატება და ა.შ.) რთულდება
//   - თუ მომავალში ფორმატში ასო-ნიშანი დაემატება, long ვერ მოერგება

//3. რატომ ნელია decimal, მაგრამ ბანკები მაინც იყენებენ?
//   decimal-ი 128-ბიტიანია და გამოთვლა პროგრამულად ხდება, არა პროცესორში
//   პირდაპირ. ამიტომ double-ზე ~10-20-ჯერ ნელია. მაგრამ ბანკისთვის სიჩქარეზე
//   ბევრად მნიშვნელოვანია სიზუსტე - ფული უნდა იყოს ზუსტი ბოლო თეთრამდე.
//   რამდენიმე მიკროწამი ფასიანი არ არის შეცდომის რისკთან შედარებით.

//4. რომელი Data Type იქნება ოპტიმალური ბანკომატის PIN კოდისთვის (4 ციფრი)?
//   string. რატომ?
//   - PIN შეიძლება იყოს "0007" - რიცხვით ტიპში წამყვანი ნულები იკარგება
//   - PIN-ში არასოდეს ვაკეთებთ არითმეტიკას (არ ვამატებთ PIN-ებს)
//   - რეალურ სისტემაში PIN საერთოდ არ ინახება როგორც პლეინ ტექსტი,
//     ინახება მისი hash, რაც ისედაც string-ია
//   - ვალიდაცია (4 ციფრი ხო არის?) უფრო ადვილია string-ით