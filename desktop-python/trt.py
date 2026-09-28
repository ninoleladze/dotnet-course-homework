# # Objects and Turtle Graphics

# import turtle

# # Create a screen
# wn = turtle.Screen()

# # Create a turtle named Alex
# nini = turtle.Turtle()
# nini.forward(150)  # Move forward by 150 pixels
# nini.left(90)      # Turn left by 90 degrees
# nini.forward(75)   # Move forward by 75 pixels
# nini.left(90)      # Turn left by 90 degrees again
# nini.forward(150)  # Move forward by 150 pixels
# nini.left(90)      # Turn left by 90 degrees
# nini.forward(75)   # Move forward by 75 pixels


# import turtle
# wn = turtle.Screen()
# wn.bgcolor("lightgreen")

# tess = turtle.Turtle()
# tess.pensize(5)

# nini = turtle.Turtle()
# nini.color("hotpink")

# tess.forward(80)
# tess.left(120)
# tess.forward(80)
# tess.left(120)
# tess.forward(80)
# tess.left(120)

# tess.right(180)
# tess.forward(80)

# nini.forward(50)
# nini.left(90)
# nini.forward(50)
# nini.left(90)
# nini.forward(50)
# nini.left(90)
# nini.forward(50)
# nini.left(90)

# wn.exitonclick()



# import turtle
# wn = turtle.Screen()

# elan = turtle.Turtle()

# distance = 50
# angle = 90
# for i in range(16):
#     elan.forward(distance)
#     elan.right(angle)
#     distance =distance+ 10
#     angle = angle - 3

# distance = 50
# for i in range(10):
#     print(f"Move forward {distance} and turn right 90°")
#     distance = distance + 20


# import turtle
# wn = turtle.Screen()
# wn.bgcolor("lightgreen")
# elan = turtle.Turtle()   #create a turtle named elan
# elan.color("blue")
# elan.shape("turtle")
# elan.speed(0)

# dist = 5
# elan.up()
# for i in range(30):
# 	elan.dot()
# 	elan.forward(dist)
# 	elan.right(24)
# 	dist = dist + 2
# wn.exitonclick()


# import turtle
# wn = turtle.Screen()
# alex = turtle.Turtle()
# alex.forward(150) #move forward by 150 pixels
# alex.left(90)  #turn left by 90 degrees
# alex.forward(75)    #move forward by 75 pixels

# wn.exitonclick()


#instance variables and methods
# import turtle
# wn = turtle.Screen()
# alex = turtle.Turtle()

#wn is an instance of the class Screen
#alex is an instance of the class Turtle

# import turtle
# wn = turtle.Screen()
# pent = turtle.Turtle()

# for i in range(5):
#     pent.forward(100)
#     pent.right(72)

# wn.exitonclick()

# import turtle

# wn = turtle.Screen()
# wn.bgcolor("black")

# artist = turtle.Turtle()
# artist.color("cyan")
# artist.speed(0)   
# for i in range(72):
#     artist.color("cyan")
#     artist.forward(100)
#     artist.right(144) 
#     artist.forward(100)
#     artist.right(5)  
# wn.exitonclick()



# import turtle
# import random
# import time

# wn = turtle.Screen()
# wn.setup(width=800, height=600)
# wn.bgcolor("#0b0014")  
# wn.title("💖 Floating Hearts with Sparkles ✨")
# wn.tracer(0)

# heart_colors = ["#ff69b4", "#ff1493", "#ff3366", "#ff99cc", "#ff66b2", "#ff004c"]
# hearts = []
# sparkles = []


# def draw_heart(t, size):
#     t.begin_fill()
#     t.left(140)
#     t.forward(size)
#     t.circle(-size/2, 200)
#     t.left(120)
#     t.circle(-size/2, 200)
#     t.forward(size)
#     t.end_fill()
#     t.setheading(0)

# for _ in range(12):
#     h = turtle.Turtle()
#     h.hideturtle()
#     h.penup()
#     h.speed(0)
#     h.color(random.choice(heart_colors))
#     x = random.randint(-350, 350)
#     y = random.randint(-250, 250)
#     h.goto(x, y)
#     hearts.append(h)

#     s = turtle.Turtle()
#     s.hideturtle()
#     s.penup()
#     s.speed(0)
#     s.color("white")
#     s.goto(x + random.randint(-10, 10), y + random.randint(15, 25))
#     sparkles.append(s)

# while True:
#     wn.update()
#     wn.tracer(0)
#     for i in range(len(hearts)):
#         h = hearts[i]
#         s = sparkles[i]

       
#         h.clear()
#         s.clear()


#         h.goto(h.xcor(), h.ycor() + random.uniform(1, 3))
#         if h.ycor() > 300:
#             h.goto(random.randint(-350, 350), -300)
#         h.color(random.choice(heart_colors))
#         draw_heart(h, random.randint(12, 18))


#         s.goto(h.xcor() + random.randint(-10, 10), h.ycor() + random.randint(10, 20))
#         s.color(random.choice(["white", "#ffe6f2", "#ffb3e6"]))
#         s.pensize(2)
#         s.setheading(0)
#         s.pendown()
#         s.forward(6)
#         s.penup()
#         s.backward(3)
#         s.left(90)
#         s.pendown()
#         s.forward(6)
#         s.penup()

#     wn.update()
#     time.sleep(0.05)




# import turtle
# import math
# wn = turtle.Screen()
# alex = turtle.Turtle()
# alex.right(90)
# alex.forward(50)
# alex.left(90)
# alex.forward(50) 
# alex.left(90)
# alex.forward(50)
# alex.left(90)
# alex.forward(50)
# alex.right(135)
# distance = math.sqrt(50*50/2)
# alex.forward(40)
# alex.right(90)
# alex.forward(40)



# import turtle
# wn = turtle.Screen()
# alex = turtle.Turtle()

# for i in [0,1,2,3]:
#     alex.forward(50)
#     alex.left(90)

# wn.exitonclick()


# import turtle
# wn = turtle.Screen()        
# alex = turtle.Turtle()

# for acolor in ["red", "purple", "hotpink", "blue"]:
#     alex.color(acolor)
#     alex.forward(50)
#     alex.left(90)
# wn.exitonclick()