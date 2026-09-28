

using _1;

//user<List<post>> user1 = new user<List<post>>();
//user<List<address>> user2 = new user<List<address>>();

//foreach (var item in user1.Data)
//{

//    Console.WriteLine(item.Title);
//    Console.WriteLine(item.Content);
//}
//Console.WriteLine("");


//foreach (var item in user2.Data)
//{
//    Console.WriteLine(item.City);
//    Console.WriteLine(item.State);
//}



//


//numbers.Add(244) ;
//numbers.Add(20);
//numbers.Add(30);

//numbers.Remove(5);
//numbers.RemoveAt(0);
//bool hasNum = numbers.Contains(20);
//Console.WriteLine(hasNum);
//Console.WriteLine(numbers.Count);
//foreach (var item in numbers)
//{
//    
//}


List<int> numbers = new List<int>() ;
int num = int.Parse(Console.ReadLine());
numbers.Add(num);

for(int i =1; i<=num; i++)
{
    numbers.Add(i);
}



foreach (var item in numbers)
{
    Console.WriteLine(item);
}