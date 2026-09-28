using _06._29._26_DI.Models._1EX;
using _06._29._26_DI.Models._2EX;
using _06._29._26_DI.Models._5EX;
using _06._29._26_DI.Models._6EX;
using _06._29._26_DI.Models._7EX;
using _06._29._26_DI.Models._8EX;
using _06._29._26_DI.Models._9EX;
using _06._29._26_DI.Models.EX10;
using System.Runtime.ConstrainedExecution;

//1,2,3
Dog myDog = new Dog();
myDog.Name = "Max";

Console.WriteLine("Dog's Name: " + myDog.Name);
myDog.Eat();
myDog.Bark();

//4
Student Nini = new Student();
Nini.Name = "Nini";
Nini.Age = 18;
Nini.School = "idk";

Console.WriteLine($"Name: {Nini.Name}, Age: {Nini.Age}, School: {Nini.School}");

//5
Car myCar = new Car();
myCar.Brand = "Toyota";
myCar.Model = "Camry";
myCar.Speed = 120.5;

myCar.Drive();

//6
Cat myCat = new Cat();
myCat.IsAlive = true;
myCat.Name = "Misa";
myCat.Color = "Black";

Console.WriteLine($"Cat Name: {myCat.Name}, Color: {myCat.Color}, IsAlive: {myCat.IsAlive}");



//7
Manager mgr = new Manager();
mgr.Name = "Giorgi";
mgr.Salary = 5000;
mgr.TeamSize = 10;

mgr.ShowInfo();


//8

Circle myCircle = new Circle();
myCircle.Name = "MyRoundCircle";
myCircle.Describe();

//9
SmartPhone myPhone = new SmartPhone();
myPhone.Brand = "Apple";
myPhone.Number = "555-123456";
myPhone.OS = "iOS";

myPhone.PowerOn();
myPhone.InstallApp();


//10
SavingsAccount myAccount = new SavingsAccount();
myAccount.Owner = "Nino";

myAccount.Deposit(1000);
myAccount.InterestRate = 5.0;

myAccount.ShowBalance();
myAccount.AddInterest();
myAccount.ShowBalance();
