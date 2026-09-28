using System;

public class User
{
    public string Username { get; private set; }
    private string passwordHash;

    public User(string username)
    {
        if (string.IsNullOrWhiteSpace(username))
            throw new ArgumentException("Username cannot be empty.");

        Username = username;
    }

    public void SetPassword(string password)
    {
        if (!string.IsNullOrEmpty(password) && password.Length >= 6)
        {
           
            passwordHash = password.Length + "_" + password.GetHashCode();
        }
        else
        {
            Console.WriteLine("Error: Password must contain at least 6 characters.");
        }
    }

    public bool CheckPassword(string password)
    {
        if (string.IsNullOrEmpty(password)) return false;

        string inputHash = password.Length + "_" + password.GetHashCode();
        return passwordHash == inputHash;
    }
}