# print(100)  #integer anu mteli ricxvi
# print("hello world")  #string 
# print(3.14) #decimal wiladi

# #operators 
# print(100+200) # + damateba- addition
# print(10-9) # - gamokleba - subtraction
# print(2*4) # * multiplication gamravleba
# print(10/3)# devision gayofa 3.33333333333
# print(10/2)# gamova 5.0 da ara 5
# print(10//3) #truncated division shemoklebuli gayofa 3
# print(10%3) #nashti modulo
# print(4**2) # 4 kvadratshi anu 16
# print(12+20/2)# 22.0 math rules

#function calls 
from itertools import combinations_with_replacement


def square(x):
   return x * x  # logika kvadratis

def sub(x, y):
   return x - y # logika gamoklebis

def add(a, b):
   return a + b


# print(square(3)) #kvadrati
# print(sub(6, 4))  
# print(sub(5, 9))



# data types
# print(type("hello"))
# print(type(17))
# print(type(3.2)) #float
#Text Type:	str
#Numeric Types:	int, float, complex
#Sequence Types:	list, tuple, range
#Mapping Type:	dict
#Set Types:	set, frozenset
#Boolean Type:	bool
#Binary Types:	bytes, bytearray, memoryview
#None Type:	NoneType



#type conversion functions konvertacia
# print(3.14,int(3.14))
# print(3999,int(3,9999))


#variables
# message="helo doc" #variable is message and value is helo doc
# n=17
# pi= 3.14

# print(message)
# print(n )
# print(pi)

# x=5
# print(x)            #x-variable 5-value
# x=10
# print(x)



# day = "Thursday"

# print(day)
# day = 32.5
# print(day)
# day = 19
# print(day)


# a = 5
# b = a    # after executing this line, a and b are now equal
# print(a,b)             5 5         
# a = 3    # after executing this line, a and b are no longer equal
# print(a,b)             3 5


 

# print(len("hello")) #5

# y = 3.14
# x = len("hello")
# print(x)
# print(y)


# x = 2
# y = 1
# print(square(y+3))
# print(square(x+4))
# print(sub(x+4, y+3))
# print(sub(square(x), square(y)))



# x=5
# y=7
# print(add(square(x), square(y)) )


# #update variables
# x = 5
# print(x)  #5
# x = x + 2
# print(x)  #7

# x = 5
# print(x)  #5
# x += 2
# print(x)  #7
# x *= 3
# print(x)  #21
# x -= 4
# print(x)  #17



# x = 10
# y = 3
# avg = (x + y) / 2
# print(avg)
# print("average of", x, "and", y, "is", avg)

#input
# n = input("enter name ") #input is always string
# print("hello",n)

# n = int(input("enter number ")) #input is always string
# print("square is",n*n)




# n = input("Please enter your age: ")
# # user types in 18
# print(type(n))


# print(int(53.785))



#for loops

# for i in range(5):
#     print("this is line")
#     print("this line will be printed 5 times")


# print("other code")


#random module


# import random   #importing random module
# prob = random.random() #random function generates random float between 0 and 1
# print(prob) #print the random float

# diceThrow = random.randrange(1,7)  #randrange function generates random integer between 1 and 6
# print(diceThrow) #print the random integer
 

# import random
# from random import randrange, random
# print(randrange(1,10))  #prints random integer between 1 and 9


# import random funqciis gamodzaxebit 
# from random import randrange, random #importing specific functions from random module
# prob= random() #random function generates random float between 0 and 1
# print(prob) #print the random float
# diceThrow= randrange(1,7)  #randrange function generates random integer between 1 and 6
# print(diceThrow) #print the random integer



#debugging
#syntax error
# print("start" #syntax error missing parenthesis
# print("start") #fixed
# print(3/0) #runtime error division by zero


#string and lists
# s="hello"
# print(s[0]) #h

# m="""
# This is a multi-line string.
# It can span multiple lines.
# Useful for documentation.
# """
# print(m)


#lists
# s = [5, 10, 15, 20]
# print(s)
# mylist = ["hello", 3.14, 42, "world"]
# print(mylist)

# #tuples

# myTuple= ("one",2,'three' )
# print (type(myTuple))

# s = "hello"
# print (s[ len(s)-2]) #l

# s = "python rocks"
# print(s[2] + s[-4])

#length

# fruit ="banana"
# sz = len(fruit)
# last = fruit[sz-1]
# print(last) #a
  
# singers = "Cher, Madonna, janet"

# print(singers[15:22]) 

# fruit = "banana"
# print(fruit[:3]) #ban
# print(fruit[3:]) #ana
# print(fruit[:])  #banana
# print(fruit[1:4]) #ana

# a_list = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j']

# print(a_list[2:5]) #['c', 'd', 'e']
# print(a_list[:3])  #['a', 'b', 'c']
# print(a_list[7:])  #['h', 'i', 'j']
# print(a_list[:])   #['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j']
# print(a_list[-3:]) #['h', 'i', 'j']          






# alist = [3, 67, "cat", [56, 57, "dog"], [ ], 3.14, False]
# print(alist[4:])


# L = [0.34, '6', 'SI106', 'Python', -2]
# print(len(L[1:-1]))


#Concatenation and Repetition
#შეერთება და გამეორება


# fruit= ["apple","orange" "banana", "cherry" ]

# # print ([1,2] + [3,4])

# # print(fruit+[6,7,8,9])

# # print([0,1]* 4)

# # print((fruit + [1])*4)

 
# numlist = [6,7]
# newlist= fruit + numlist

# zeros= [0]*4 


# print(fruit)
# print(numlist)

# print(newlist) 
# print(zeros)

#count and index
# a="i have had an apple on my dsk  "

# print(a.count("e"))
# print(a.count("ha"))

# z=['atoms', 4 ,' neutron', 6, 'proton',4, 'electron',4,'electron','atoms']
# print(z.count("4")) #0
# print(z.count(4))
# print(z.count("a"))   #0
# print(z.count("electron"))

#looping through lists and strings

# for name in ["alice", "bob", "charlie"]:
#     print("hello", name)

# for char in "hello":
#       print(char)


# fruits = ["apple", "banana", "cherry"]
# for fruit in fruits:
#     print(fruit) 



# nums = [1,2,3,4,5]
# accum = 0
# for num in nums:
#     accum = accum + num

# print(accum)


# nums = [1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
# accum = 0
# for w in nums:
#     accum = accum + w
#     print(accum)

# for i in range(1,6):
#     print(i)

# for i in [1,2,3,4,5]:
#     print(i)

# list(range(3))
# print(list(range(3)))  #[0, 1, 2]

# x = ["apple", "banana", "cherry"]
# for y in x:
#       print(y)



# genres = ["rock", "pop", "jazz"]
# for genre in genres:
#       print(genre)




# w= range(10) #creates a sequence of numbers from 0 to 9

# tot =0 #initializing sum variable
# for i in w:   #iterating through numbers from 0 to 9
#     print(i)  #print numbers from 0 to 9
#     tot = tot + i    # accumulating sum
#     print(tot)    #print intermediate sum
# print(tot) #print final sum





# w =range(10) #creates a sequence of numbers from 0 to 9
# tot =0 #initializing sum variable
# print("***** Before the For Loop *****")
# for num in w:  #iterating through numbers from 0 to 9
#    print("***** a new loop iteration *****")
#    print("value of num:", num)  #print numbers from 0 to 9
#    tot+= num    # accumulating sum
#    print ("value of tot:", tot)    #print intermediate sum
# print("***** end of the For Loop *****")
# print("final total:", tot) #print final sum




# n =["word", "prase", 8,("beam") ]
# for item in n:
#     print(item)
#     print(type(n)) # list



# t =" couch"
# for char in t:
#     print(char)
#     print(type(t)) # string


# y = 18
# for z in y:
#     print(z)
#     print(type(y)) # integer error

# t = ("apple", "banana", "cherry")
# for item in t:
#     print(item)
#     print(type(t)) # tuple


# t = ["apple", "banana", "cherry"]
# for item in t:
#     print(item)
#     print(type(item)) # string

# t = [ 9 , "banana", 3, "cherry"]
# for item in t:
#     print(item)
#     print(type(item)) # integer and string
# print(
# 16 - 2 * 5 // 3 + 1
# )


# print(10//3)

# print(int(53.785))
 


# alist = [1,3,5]
# print(alist * 3)




#boolean values

# print(True)
# print(type(True)) #bool
# print(type("True")) #str

# print(type(False)) #bool


# print(5==5) #True
# print(5==3) #False

# print(4 != 5) #True # not equal
# print(4 != 4) #False  # not equal

#!= not equal operator
#== equal operator

# print(3 < 5) #True
# print(5 < 3) #False
# print(5 > 2) #True
# print(2 > 5) #False
# print(3 <= 5) #True
#  print(5 <= 5) #True
# print(5==5)


# print(5><5) #syntax error

# x=5
# print(x > 3 and x < 10) #True
# print(x > 3 and x > 10) #False

# n= 25
# print(n > 10 or n < 20) #True
# print(n < 10 or n < 20) #False

# n =25
# print(n%2 == 0 or n%3 == 0)  #false
# print(n%2 == 0 or n%5 == 0)  #true
# print(not (n > 10)) #False

# comparison operators
# < less than
# > greater than
# <= less than or equal to
# >= greater than or equal to
# == equal to
# != not equal to
 
# logical operators
# and 
# or 
# not

#literal boolean values
# True
# False

 

# #the and operators
# print('p'in 'apple')
# print('x'in 'apple')
# print('p' not in 'apple')
# print('x' not in 'apple')
# print('' in 'apple') 
# print('' not in 'apple')


#membership operators
# in
# not in
# print('a' in 'banana') #True
# print('x' in 'banana') #False

# print("A" in ["Apple", "Banana", "Cherry"]) #False

#precedence - order of operations

# print(3 + 4 * 2) #11

#automated test with assert statement
#assert means "to state something strongly"
# assert type(9//5)== int
# assert type(9.0//5 ) == float

# lst = ['a', 'b', 'c']

# first_type = type(lst[0])
# for item in lst:
#     assert type(item) == first_type


# lst2 = ['a', 2, 'c']
# first_type = type(lst2[0])
# for item in lst2:
#       assert type(item) == first_type  # this will raise an AssertionError


# list1 = ['a', 'b', 'c']
# assert len(list1) < 2 # this will raise an AssertionError
# print("End of program")
# x=10
# y=10
# assert x==y
# print ("x is equal to y")


#conditional execution

# x = 10
# if x > 5:
#     print("x is greater than 5")
# print("this line is always executed")
# if x < 5:
#     print("x is less than 5") # no output
# print("this line is always executed")



# x= 14
# if x/2 ==0:
#     print("x is even") #ლუწი
# else:
#     print("x is odd")  #კენტი

# x= 15
# if x%2 ==0:
#     print("x is even") #ლუწი
# else:
#     print("x is odd")  #კენტი\




#Unary Selection, Nested Conditionals, and Chained Conditionals


#Unary function, a function that takes one argument;
#  in computer science, a unary operator is a subset of 
# unary function. Unary operation, a kind of mathematical operator that has only one operand.


# x=-10
# if x < 0:
#     print("x is negative", x, "is not valid here")
# print("this line is always executed")

# x= 5 
# y = 10

# if x < y:
#       print("x is less than y")
# else:
#       if x > y:
#           print("x is greater than y")
#       else:
#           print("x is equal to y") 


#chained conditionals
# x= 5
# y = 10
# if x < y:
#       print("x is less than y")
# elif x > y:
#       print("x is greater than y")
# else:
#       print("x is equal to y")

# x = -10



# if x < 0:
#     print("The negative number ",  x, " is not valid here.")
# if (x > 0):
#     print(x, " is a positive number")
# else:
#     print(x, " is 0")

# x=3
# y=5
# z=2
# if x < y and x < z:
#     print("a")
# elif y < x and y < z:
#     print("b")
# else:
#     print("c")


# x = 3
# y = 0
# if x < y:
#     z = x
# else:
#     if x > y:
#         z = y
#     else:
#         ## x must be equal to y
#         assert x==y
#         z = 0
# print(z)


#the accumulator pattern with conditionals and accumulating a maximum value

# phrase = "What a wonderful day to program"
# tot = 0
# for c in phrase:
#     if c != " ": 
#         tot = tot + 1  #count non-space characters   
#         print(c)  #output non-space characters
#         print(tot)  #output intermediate values 1 2 3 ...26
       
# print(tot) #output 26 


# s = "what if we went to the zoo"
# x = 0
# for i in s:
#     if i in ['a', 'e', 'i', 'o', 'u']:
#         x += 1
#         print(i)
#         print(x)
      

# print(x)


# nums = [9, 3, 8, 11, 5, 29, 2]
# best_num = 0
# for n in nums:
#     if n > best_num:
#         best_num = n
#         print("current num is:", n)
#         print("new best num found:", best_num)
      
# print(best_num)



# nums = [9, 3, 8, 11, 5, 29, 2]
# best_num = nums[0] #initialize best_num to the first element of the list
# for n in nums:    #iterate through each number in the list
#     if n > best_num:  #compare current number with best_num
#         best_num = n #update best_num if current number is greater
# print(best_num) #print the maximum number found




# words = ["water", "chair", "pen", "basket", "hi", "car"]
# num_words = 0

# for word in words:
#     if len(word) > 3:
#         num_words += 1

# print(num_words)



# ls = ['run', 'world', 'travel', 'lights', 'moon', 'baseball', 'sea']
# new = ls[2:4]
# print(new)

# nums = [4, 2, 8, 23.4, 8, 9, 545, 9, 1, 234.001, 5, 49, 8, 9 , 34, 52, 1, -2, 9.1, 4]
# sliced = nums[3:10]

# print(sliced)

#introduction : transforming sequences
#mutability
# fruit = ["apple", "banana", "cherry"]
# print(fruit)
# fruit[1] = "orange"
# fruit[0] = "kiwi"
# print(fruit)

# alist =   [ 'a', 'b', 'c', 'd', 'e' ]
# print(alist)
# alist[1:3] = [ 'x', 'y' ]
# print(alist)

# alist = [ 'a', 'b', 'c', 'd', 'e' ]
# print(alist)
# alist[1:3] = [ ]
# print(alist)



# greeting = "hello"
# greeting[0] = "H"  #strings are immutable
# print(greeting)


# greeting = "hello, world"
# new_greeting = "H" + greeting[1:] 
# print(new_greeting)
# print(greeting)


#element delete 

# a = ['one','two', 'three']
# del a[1]
# print

# alist = ['a','b','c','d'] 

#objects and references


# a = "banana"
# b = "banana"

# print(a is b)


#Cloning lists

# a = [81,82,83]
# b = a[:]

# print(a==b)
# print(a is b)

# print(  a)
# print(  b)




# mylist = []
# mylist.append(5)
# mylist.append(27)
# mylist.append(3)
# mylist.append(12)
# print(mylist)

# mylist.insert(1, 12)
# print(mylist)
# print(mylist.count(12))

# print(mylist.index(3))
# print(mylist.count(5))

# mylist.reverse()
# print(mylist)

# mylist.sort()
# print(mylist)

# mylist.remove(5)
# print(mylist)

# lastitem = mylist.pop()
# print(lastitem)
# print(mylist)


#append and concatenate

# origlist = [45,32,88]
# print(origlist)
# origlist.append("cat")
# print(origlist)

# origlist = [45,32,88]
# print(origlist)
# origlist = origlist + ["cat"]

# print(origlist)


# origlist = [45,32,88]
# print("origlist:", origlist)
# print("the identifier:", id(origlist))             #id of the list before changes
# newlist = origlist + ['cat']
# print("newlist:", newlist)
# print("the identifier:", id(newlist))              #id of the list after concatentation
# origlist.append('cat')
# print("origlist:", origlist)
# print("the identifier:", id(origlist))             #id of the list after append is used



# origPrice = float(input('Enter the original price: $'))
# discount = float(input('Enter discount percentage: '))
# newPrice = (1 - discount/100)*origPrice
# calculation = '${} discounted by {}% is ${}.'.format(origPrice, discount, newPrice)
# print(calculation)





# v = 2.34567
# print('{:.1f} {:.2f} {:.7f}'.format(v, v, v))


# lst= [3,0,9,4,1,7]
# new_list=[]
# for i in range(len(lst)):
#    new_list.append(lst[i]+5)
# print(new_list)