using System;
using System.Collections.Generic;
using System.Linq;


public class Student
{
    private string name;
    public string Id { get; } 
    private List<int> grades;

    public Student(string id)
    {
        Id = id;
        grades = new List<int>();
    }

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

    public void AddGrade(int grade)
    {
        if (grade >= 0 && grade <= 100)
            grades.Add(grade);
        else
            Console.WriteLine("Error: Grade must be between 0 and 100.");
    }

    public double Average
    {
        get
        {
            if (grades.Count == 0) return 0;
            return grades.Average();
        }
    }

    public List<int> GetGrades()
    {
        return new List<int>(grades);
    }
}