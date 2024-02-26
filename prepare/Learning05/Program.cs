using System;
using System.Collections.Generic;

// Base class for all shapes
class Shape
{
    private string _color;

    // Constructor
    public Shape(string color)
    {
        _color = color;
    }

    // Getter for color
    public string GetColor()
    {
        return _color;
    }

    // Virtual method for calculating area
    public virtual double GetArea()
    {
        return 0; // Default implementation returns 0
    }
}

// Derived class for Square
class Square : Shape
{
    private double _side;

    // Constructor
    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    // Override method for calculating area
    public override double GetArea()
    {
        return _side * _side;
    }
}

// Derived class for Rectangle
class Rectangle : Shape
{
    private double _length;
    private double _width;

    // Constructor
    public Rectangle(string color, double length, double width) : base(color)
    {
        _length = length;
        _width = width;
    }

    // Override method for calculating area
    public override double GetArea()
    {
        return _length * _width;
    }
}

// Derived class for Circle
class Circle : Shape
{
    private double _radius;

    // Constructor
    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    // Override method for calculating area
    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Create a list to hold shapes
        List<Shape> shapes = new List<Shape>();

        // Add shapes to the list
        shapes.Add(new Square("Red", 5));
        shapes.Add(new Rectangle("Blue", 4, 6));
        shapes.Add(new Circle("Green", 3));

        // Iterate through the list and display color and area of each shape
        foreach (Shape shape in shapes)
        {
            Console.WriteLine("Shape color: " + shape.GetColor());
            Console.WriteLine("Shape area: " + shape.GetArea());
            Console.WriteLine();
        }
    }
}
