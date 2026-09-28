using System;
using System.Collections.Generic;
using _06._17._26_DI;

class Program
{
    static List<User> usersList = new List<User>()
    {
        new User
        {
            Username = "Mari",
            Email = "bregvamari9@gmail.com",
            Password = "123" 
        }
    };
    static void Main(string[] args)
    {
        bool isRunning = true;

        while (isRunning)
        {
            Console.Clear();
            Console.WriteLine("=== Login / Register System ===");
            Console.WriteLine("1. Register");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Forgot Password"); 
            Console.WriteLine("4. View All Users");  
            Console.WriteLine("5. Exit");
            Console.Write("Select an option (1-5): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Register();
                    break;
                case "2":
                    Login();
                    break;
                case "3":
                    ForgotPassword();
                    break;
                case "4":
                    ViewAllUsers();
                    break;
                case "5":
                    isRunning = false;
                    break;
                default:
                    Console.WriteLine(" Invalid choice. Please select 1, 2, 3, 4, or 5.");
                    Console.WriteLine("Press any key to try again...");
                    Console.ReadKey();
                    break;
            }
        }
    }

    static void Register()
    {
        Console.Clear();
        Console.WriteLine("--- Register ---");

        Console.Write("Enter Username: ");
        string username = Console.ReadLine();

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        Random random = new Random();
        string verificationCode = random.Next(100000, 999999).ToString();

        Console.WriteLine("Sending verification code...");

        try
        {
            EmailSender sender = new EmailSender();
            string subject = "Your Verification Code";

            string body = $@"
<!DOCTYPE html>
<html lang='en'>
<head>
    <meta charset='UTF-8'>
</head>
<body style='margin: 0; padding: 0; font-family: Arial, sans-serif; background-color: #f0f4f8;'>
    <table width='100%' cellpadding='0' cellspacing='0' border='0' style='padding: 40px 10px;'>
        <tr>
            <td align='center'>
                <table width='600' cellpadding='0' cellspacing='0' border='0' style='background-color: #ffffff; border-radius: 8px; overflow: hidden; border: 1px solid #e1e8ed; box-shadow: 0 4px 6px rgba(0,0,0,0.05);'>
                    <tr>
                        <td style='background-color: #1a365d; padding: 30px; text-align: center;'>
                            <h1 style='color: #ffffff; margin: 0; font-size: 24px; font-weight: normal; letter-spacing: 1px;'>Verification Required</h1>
                        </td>
                    </tr>
                    <tr>
                        <td style='padding: 40px 30px; text-align: center;'>
                            <p style='margin: 0 0 20px 0; font-size: 18px; color: #2d3748;'>
                                Hello <strong>{username}</strong>,
                            </p>
                            <p style='margin: 0 0 30px 0; font-size: 15px; color: #718096; line-height: 1.6;'>
                                Thank you for registering. Please use the secure verification code below to confirm your email address and complete your setup.
                            </p>
                            <div style='margin-bottom: 35px;'>
                                <span style='display: inline-block; padding: 18px 36px; background-color: #f7fafc; border: 2px dashed #3182ce; border-radius: 6px; font-size: 32px; font-weight: bold; color: #2b6cb0; letter-spacing: 8px;'>
                                    {verificationCode}
                                </span>
                            </div>
                            <p style='margin: 0; font-size: 13px; color: #a0aec0;'>
                                If you did not request this code, you can safely ignore this email.
                            </p>
                        </td>
                    </tr>
                    <tr>
                        <td style='background-color: #f7fafc; padding: 20px; text-align: center; border-top: 1px solid #e2e8f0;'>
                            <p style='margin: 0; font-size: 12px; color: #a0aec0;'>
                                This is an automated message, please do not reply.
                            </p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</body>
</html>";

            sender.SendEmail(email, subject, body);

            Console.WriteLine($"Code successfully sent to {email}.");
            Console.Write("Enter the code received in your email: ");

            string inputCode = Console.ReadLine();

            if (inputCode == verificationCode)
            {
                User newUser = new User
                {
                    Username = username,
                    Email = email,
                    Password = password
                };
                usersList.Add(newUser);

                Console.WriteLine(" Registration successful!");
            }
            else
            {
                Console.WriteLine(" Invalid code! Registration cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($" An error occurred while sending the email: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void Login()
    {
        Console.Clear();
        Console.WriteLine("--- Login ---");

        Console.Write("Enter Email: ");
        string email = Console.ReadLine();

        Console.Write("Enter Password: ");
        string password = Console.ReadLine();

        bool isAuthenticated = false;
        string loggedInUser = "";

        foreach (var user in usersList)
        {
            if (user.Email == email && user.Password == password)
            {
                isAuthenticated = true;
                loggedInUser = user.Username;
                break;
            }
        }

        if (isAuthenticated)
        {
            Console.WriteLine($" Login successful! Welcome, {loggedInUser}!");
        }
        else
        {
            Console.WriteLine(" Invalid email or password.");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ForgotPassword()
    {
        Console.Clear();
        Console.WriteLine("--- Forgot Password ---");

        Console.Write("Enter your registered Email: ");
        string email = Console.ReadLine();

        User foundUser = null;
        foreach (var user in usersList)
        {
            if (user.Email == email)
            {
                foundUser = user;
                break;
            }
        }

        if (foundUser == null)
        {
            Console.WriteLine(" User with this email was not found.");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
            return;
        }

        Random random = new Random();
        string resetCode = random.Next(100000, 999999).ToString();

        Console.WriteLine("Sending password reset code...");

        try
        {
            EmailSender sender = new EmailSender();
            string subject = "Password Reset Code";

            string body = $@"
            <div style='font-family: Arial, sans-serif; padding: 20px;'>
                <h2>Password Reset Request</h2>
                <p>Hello <strong>{foundUser.Username}</strong>,</p>
                <p>Your password reset code is: <strong style='font-size: 24px; color: #e53e3e;'>{resetCode}</strong></p>
                <p style='color: #718096; font-size: 12px;'>If you didn't request this, please ignore this email.</p>
            </div>";

            sender.SendEmail(email, subject, body);

            Console.WriteLine($"Reset code successfully sent to {email}.");
            Console.Write("Enter the reset code: ");

            string inputCode = Console.ReadLine();

            if (inputCode == resetCode)
            {
                Console.Write("Enter your NEW Password: ");
                string newPassword = Console.ReadLine();

                foundUser.Password = newPassword;
                Console.WriteLine(" Password successfully updated! You can now login.");
            }
            else
            {
                Console.WriteLine(" Invalid code! Password reset cancelled.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($" An error occurred while sending the email: {ex.Message}");
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }

    static void ViewAllUsers()
    {
        Console.Clear();
        Console.WriteLine("--- Registered Users ---");

        if (usersList.Count == 0)
        {
            Console.WriteLine("No users registered yet.");
        }
        else
        {
            Console.WriteLine($"Total Users: {usersList.Count}\n");
            foreach (var user in usersList)
            {
                Console.WriteLine($"- Username: {user.Username} | Email: {user.Email}");
            }
        }

        Console.WriteLine("Press any key to continue...");
        Console.ReadKey();
    }
}