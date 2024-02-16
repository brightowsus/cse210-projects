using System;

public class Fraction
{
    private int numerator;
    private int denominator;

    // Constructor that initializes the fraction to 1/1
    public Fraction()
    {
        numerator = 1;
        denominator = 1;
    }

    // Constructor that initializes the fraction to n/1
    public Fraction(int n)
    {
        numerator = n;
        denominator = 1;
    }

    // Constructor that initializes the fraction to numerator/denominator
    public Fraction(int numerator, int denominator)
    {
        if (denominator == 0)
        {
            throw new ArgumentException("Denominator cannot be zero.");
        }
        this.numerator = numerator;
        this.denominator = denominator;
    }

    // Getter and setter for numerator
    public int Numerator
    {
        get { return numerator; }
        set { numerator = value; }
    }

    // Getter and setter for denominator
    public int Denominator
    {
        get { return denominator; }
        set
        {
            if (value == 0)
            {
                throw new ArgumentException("Denominator cannot be zero.");
            }
            denominator = value;
        }
    }

    // Method to return the fraction as a string representation
    public string GetFractionString()
    {
        return $"{numerator}/{denominator}";
    }

    // Method to return the fraction as a decimal value
    public double GetDecimalValue()
    {
        return (double)numerator / denominator;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Creating instances using different constructors
        Fraction fraction1 = new Fraction(); // Initializes to 1/1
        Fraction fraction2 = new Fraction(6); // Initializes to 6/1
        Fraction fraction3 = new Fraction(6, 7); // Initializes to 6/7

        // Displaying fractions
        Console.WriteLine("Fraction 1: " + fraction1.GetFractionString());
        Console.WriteLine("Fraction 2: " + fraction2.GetFractionString());
        Console.WriteLine("Fraction 3: " + fraction3.GetFractionString());

        // Displaying decimal values
        Console.WriteLine("Decimal value of Fraction 1: " + fraction1.GetDecimalValue());
        Console.WriteLine("Decimal value of Fraction 2: " + fraction2.GetDecimalValue());
        Console.WriteLine("Decimal value of Fraction 3: " + fraction3.GetDecimalValue());

        // Changing values using setters
        fraction1.Numerator = 3;
        fraction1.Denominator = 4;

        // Displaying updated fraction
        Console.WriteLine("Updated Fraction 1: " + fraction1.GetFractionString());
    }
}
