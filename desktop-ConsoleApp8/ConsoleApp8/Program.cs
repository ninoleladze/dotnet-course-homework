using System.Collections;
using System;

//ArrayList list = new ArrayList();  ar gviwevs mititeba ra monacemebs sheinaxavs
//list.Add(0);
//list.Add(1);
//list.Add(2);
//list.Add("nini");
//list.Add(true);

//bool hasItem = list.Contains(0);
//Console.WriteLine(hasItem);
//list.Insert(0, " new item");
////list.Remove("nini");
////list.RemoveAt(1);
////list.Clear();
//list.Reverse();
//foreach (var item in list)
//{
//    Console.WriteLine(item);    
//}



//Stack stack = new Stack();
//stack.Push(12);
//stack.Push(13);
//stack.Push(14);
//stack.Push(15);
//stack.Push(16);
//object deleteditem=stack.Pop();//bolo elements shlis da abrunebs"pirvels"
//object findeditem = stack.Peek(); //bolo elements poulobs magram ar shlis"pirvels" 

//int count = stack.Count;
//Console.WriteLine( $"deleted item:{deleteditem}");
//Console.WriteLine($"finded item:{findeditem}");
//Console.WriteLine("");
//foreach (var item in stack)
//{
//    Console.WriteLine(item);
//}


//Queue queue = new Queue();
//queue.Enqueue(12);
//queue.Enqueue(13);
//queue.Enqueue(14);
//queue.Enqueue(15);
//queue.Enqueue("nini");
//queue.Enqueue(true);
//object deleted =queue.Dequeue();
//object find = queue.Peek();

//Console.WriteLine($"deleted:{ deleted}");
//Console.WriteLine($"find:{find}");
//Console.WriteLine("List: ");

//foreach (var item in queue)
//{
//    Console.WriteLine(item);    
//}




//11111

//ArrayList arrayList = new ArrayList();
//arrayList.Add(1);
//arrayList.Add(2);   
//arrayList.Add(3);
//arrayList.Add(4);
//arrayList.Add(5);
//arrayList.Add(6);
//arrayList.Add(7);
//arrayList.Add(8);
//arrayList.Add(9);
//arrayList.Add(10);

//int min = int.MaxValue;
//int max = int.MinValue;

//foreach (var item in arrayList)
//{
//    if (item is int number)
//    {
//        if (number < min)
//        {
//            min = number;
//        }
//        if (number > max)
//        {
//            max = number;
//        }
//    }
//    Console.WriteLine(item);
//}

//Console.WriteLine($"min:{min}");
//Console.WriteLine($"max:{max}");




////222
//    ArrayList arrayList = new ArrayList();  
//    arrayList.Add(1);
//    arrayList.Add(2);
//arrayList.Add("nini");
//arrayList.Add(true);
//arrayList.Add(3);

//foreach (var item in arrayList)
//{
//    Console.WriteLine(item);
//}



//33333333




//ArrayList arrayList = new ArrayList();      
//arrayList.Add("mari");
//arrayList.Add("nini");
//arrayList.Add("ana");
//arrayList.Add("lizi");
//arrayList.RemoveAt(3);
//arrayList.Insert(2, "luka");

//foreach (var item in arrayList)
//{
//    Console.WriteLine(item);

//}




/////44444
///



//class Program
//    {
//        static void Main()
//        {
//            ArrayList arrayList = new ArrayList();
//            arrayList.Add(5);
//            arrayList.Add(2);
//            arrayList.Add(9);
//            arrayList.Add(1);
//            arrayList.Add(7);

//            arrayList.Sort();

//            Console.WriteLine("Sorted:");
//            foreach (var item in arrayList)
//            {
//                Console.WriteLine(item);
//            }
//        }
//    }













////5555

//Stack stack = new Stack();  
//stack.Push(1);
//stack.Push(2);
//  stack.Push(3);      
//stack.Push(4);
//   stack.Push(5);

//object deleteditem = stack.Pop(); 

//Console.WriteLine( $"deleted item:{deleteditem}");

//foreach (var item in stack)
//{
//    Console.WriteLine(item);
//}


////66666

//Console.Write("Enter a word: ");
//string word = Console.ReadLine();
//Stack charStack = new Stack();
//foreach (char c in word)
//    charStack.Push(c);
//Console.Write("Reversed word: ");
//while (charStack.Count > 0)
//    Console.Write(charStack.Pop());
//Console.WriteLine();

//// 777777777
//Stack actions = new Stack();
//actions.Push("Open");
//actions.Push("Save");
//actions.Push("Close");
//Console.WriteLine("Undoing actions:");
//while (actions.Count > 0)
//    Console.WriteLine($"Undo: {actions.Pop()}");

//// 88888888
//Stack numStack = new Stack();
//numStack.Push(10);
//numStack.Push(20);
//numStack.Push(30);
//Console.WriteLine($"Last element (Peek): {numStack.Peek()}");

//// 999999999999
//Console.WriteLine($"Contains 20: {numStack.Contains(20)}");

//// 3️⃣ Queue – Tasks

//// Task 1: Store 5 user names, print first
//Queue queue = new Queue();
//Console.WriteLine("Enter 5 user names:");
//for (int i = 0; i < 5; i++)
//    queue.Enqueue(Console.ReadLine());
//Console.WriteLine($"First user: {queue.Peek()}");
// Task 2: Store 10 numbers, print in order
//Queue numQueue = new Queue();
//for (int i = 1; i <= 10; i++)
//    numQueue.Enqueue(i);
//Console.WriteLine("Numbers in queue:");
//foreach (var n in numQueue)
//    Console.WriteLine(n);

//// 10000
//Queue bankQueue = new Queue();
//bankQueue.Enqueue("User1");
//bankQueue.Enqueue("User2");
//bankQueue.Enqueue("User3");
//Console.WriteLine($"Serving: {bankQueue.Dequeue()}");
//Console.WriteLine($"Serving: {bankQueue.Dequeue()}");


//Console.WriteLine($"Next in bank queue: {bankQueue.Peek()}");


//Console.WriteLine($"Contains 'User3': {bankQueue.Contains("User3")}");
    