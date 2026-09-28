using System;

public class Rectangle
{
    private double width;
    private double height;

    public double Width
    {
        get { return width; }
        set
        {
            if (value > 0) width = value;
            else Console.WriteLine("Error: Width must be greater than zero.");
        }
    }

    public double Height
    {
        get { return height; }
        set
        {
            if (value > 0) height = value;
            else Console.WriteLine("Error: Height must be greater than zero.");
        }
    }

    public double Area
    {
        get { return width * height; }
    }

    public double Perimeter
    {
        get { return 2 * (width + height); }
    }
}