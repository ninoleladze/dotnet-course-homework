using System;

public class Person
{
    private string name;
    private int age;

    public string Name
    {
        get { return name; }
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                name = value;
            else
                Console.WriteLine("Error: Name cannot be empty.");
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value >= 0 && value <= 120)
                age = value;
            else
            {
                Console.WriteLine("Error: Age must be between 0 and 120.");
                age = 0; 
            }
        }
    }
}