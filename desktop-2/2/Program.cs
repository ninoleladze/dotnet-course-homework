using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection.Metadata;
//generic classes

//ArrayList arr = new ArrayList() {2,"hi",true };
//List<int> list = new List<int>() { 2, 3, 4 };




//Stack stack = new Stack();
//stack.Push(1);
//stack.Push("hello");
//stack.Push(true);


//Queue queue = new Queue();  
//queue.Enqueue(1);
//queue.Enqueue("hello");
//queue.Enqueue(true);



//Stack<int> stack1 = new Stack<int>();
//stack1.Push(1);
//stack1.Push(2);
//stack1.Push(3);

//Queue<int> queue1 = new Queue<int>();
//queue1.Enqueue(1);
//queue1.Enqueue(2);
//queue1.Enqueue(3);

/////111111111
//List<int> list1 = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
//int min = list1[0];
//int max = list1[0];
//for (int i = 1; i < list1.Count; i++)
//{

//    if (list1[i] < min)
//    {
//        min = list1[i];
//    }
//    if (list1[i] > max)
//    {
//        max = list1[i];
//    }
//}
//Console.WriteLine($"MIN:{min}");
//Console.WriteLine($"MAX:{max}");

///2222222222
//List<int> list2 = new List<int>() {};

//Random random = new Random();
//for (int i = 0; i <= 50; i++)
//{

//    list2.Add(random.Next(1, 50));
//    Console.WriteLine(i );
//}

//3333
//List<string> list3 = new List<string>() { "nini", "mari","nika" };
//list3.Remove("mari");
//list3.Insert(1, "ana");
//foreach (var item in list3)
//{
//    Console.WriteLine(item);
//}



//44444
//class Program
//{
//    static void Main()
//    {
//       List<int> List = new List<int>();
//        List.Add(5);
//        List.Add(3);
//        List.Add(8);
//        List.Add(1);
//        List.Add(4);


//      Console.WriteLine("Sorted:");
//        List.Sort();
//        foreach (var item in List)
//        {
//            Console.WriteLine(item);
//        }
//    }
//}



//5555
//Stack<int> stack = new Stack<int>();
//stack.Push(1);
//stack.Push(2);
//stack.Push(3);
//stack.Push(4);
//stack.Push(5);
//foreach (var item in stack)
//{
//    Console.WriteLine(item);
//}
//Console.WriteLine("After Pop");

//stack.Pop();
//stack.Pop();
//stack.Pop();
//stack.Pop();
//stack.Pop();



//666


//Console.Write("Enter a word: ");
//string input = Console.ReadLine();
//Stack<char> stack = new Stack<char>();
//foreach (char c in input)
//    stack.Push(c);
//Console.Write("Reversed word: ");
//while (stack.Count > 0)
//    Console.Write(stack.Pop());
//Console.WriteLine();


///7777



//Stack actions = new Stack();
//actions.Push("Open");
//actions.Push("Save");
//actions.Push("Close");
//Console.WriteLine("Undoing actions:");
//while (actions.Count > 0)
//    Console.WriteLine($"Undo: {actions.Pop()}");

////8888
///
//Stack<int> stack = new Stack<int>();
//stack.Push(1);
//stack.Push(2);
//stack.Push(3);
//stack.Push(4);
//stack.Push(5);

//object find = stack.Peek();
//Console.WriteLine(find);

//Console.WriteLine($"Contains 2: {stack.Contains(2)}");


////9999
// Queue<string> queue = new Queue<string>();
//    queue.Enqueue("NINI");
//    queue.Enqueue("MARI");
//    queue.Enqueue("NIKA");
//    queue.Enqueue("ANA");
//    queue.Enqueue("LUKA");

//Console.WriteLine($"First user: {queue.Peek()}");

////1000
//Queue<int> numbers = new Queue<int>(new[]
//{
//    15, 2, 6, 8, 4, 10, 12, 14, 18, 20
//});

//Console.WriteLine("Dequeuing numbers in order:");
//while (numbers.Count > 0)
//{
//    Console.WriteLine(numbers.Dequeue());
//}

//Console.WriteLine();
//Console.WriteLine(new string('-', 40));
//Console.WriteLine();


//////1111
//Queue<string> bankQueue = new Queue<string>();


//bankQueue.Enqueue("Nini");
//bankQueue.Enqueue("Mari");
//bankQueue.Enqueue("Nika");
//bankQueue.Enqueue("Ana");
//bankQueue.Enqueue("Luka");

//Console.WriteLine("Current bank queue (front -> back):");
//foreach (var cust in bankQueue)
//    Console.WriteLine(cust);

//Console.WriteLine();

//Console.WriteLine($"First customer (Peek): {bankQueue.Peek()}");

//Console.WriteLine($"Serving (Dequeue): {bankQueue.Dequeue()}");

//Console.WriteLine();

//Console.WriteLine("Queue after serving one customer:");
//foreach (var cust in bankQueue)
//    Console.WriteLine(cust);

//Console.WriteLine();


//string checkName1 = "Nika";
//string checkName2 = "Giorgi";
//Console.WriteLine($"Contains \"{checkName1}\": {bankQueue.Contains(checkName1)}");
//Console.WriteLine($"Contains \"{checkName2}\": {bankQueue.Contains(checkName2)}");
