// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using Console = System.Console;

Console.WriteLine("Hello, World!");

double _double = 1.0 / 3.0;
Console.WriteLine($"{_double}");

// homework #1
string name = "Nastja";
Console.WriteLine(name);
bool a = name.Contains("a");
bool s = name.Contains("s");
bool b = name.Contains("b");
Console.WriteLine($"Nastja contains a:{a}, s:{s}, b:{b}");

var area = Math.PI * Math.Pow(2.50, 2);
Console.WriteLine($"area: {area}");

// homework #2
string letters = "a, s, b, t";
string existLetters = "";
for(int i = 0; i < letters.Length; i++)
{
    if (name.Contains(letters[i]))
    {
        existLetters += $"{letters[i]}, ";
    }

}
Console.WriteLine($"Nastja contains letters: {existLetters}");

int sum = 20;
int result = 0;
for (int i = 1; i <= sum; i++)
{
    if (i % 3 == 0)
    {
        result += i;
    }
}
Console.WriteLine($"Sum of all integers from 1 to 20 that divide on 3: {result}");

// homework #3
List<int> fibonacciNumbers = new List<int> {1, 1};

for (int i = 3; i <= 20; i++)
{
    int previous = fibonacciNumbers[fibonacciNumbers.Count - 1];
    int previous2 = fibonacciNumbers[fibonacciNumbers.Count - 2];

    fibonacciNumbers.Add(previous + previous2);
}
{
    
}
Console.WriteLine($"Fibonacci of 20 is {fibonacciNumbers[fibonacciNumbers.Count - 1]}");

// homework #4
BankAccount account = new BankAccount("Anastasiia Husarenko", 2000);

account.MakeDeposit(2000, DateTime.Now, "Salary");
account.MakeWithdrawal(200, DateTime.Now, "Groceries");
account.MakeDeposit(100, DateTime.Now, "Gift");

Console.WriteLine(account.GetAccountHistory());


// homework #5

var engine1 = EngineFactory.Create();
var engine2 = EngineFactory.Create();

Console.WriteLine($"Engine 1 Number: {engine1.Number}");
Console.WriteLine($"Engine 2 Number: {engine2.Number}");
public class Engine
{
    public string Number { get; set; }
}
public static class EngineFactory
{
    private static int _currentEngineNumber = 1234567890;

    private static string GetEngineNumber()
    {
        DateTime currentDate = DateTime.Now.Date;

       return $"{currentDate:MMddyyyy}{++_currentEngineNumber}";
 
    }

    public static Engine Create()
    {
        string engineNumber = GetEngineNumber();
        return new Engine { Number = engineNumber };
    }
}


// homework #6
public class Point
{
    public int X { get; }
    public int Y { get; }

    public Point(int x, int y)
    {
        X = x;
        Y = y;
    }

    public double DistanceToPoint(Point otherPoint)
    {
        int deltaX = otherPoint.X - X;
        int deltaY = otherPoint.Y - Y;

        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    public double DistanceToLine(Line line)
    {
        double numerator = Math.Abs((line.End.Y - line.Start.Y) * X - (line.End.X - line.Start.X) * Y + line.End.X * line.Start.Y - line.End.Y * line.Start.X);
        double denominator = Math.Sqrt((line.End.Y - line.Start.Y) * (line.End.Y - line.Start.Y) + (line.End.X - line.Start.X) * (line.End.X - line.Start.X));

        return numerator / denominator;
    }
}

public class Line
{
    public Point Start { get; }
    public Point End { get; }

    public Line(Point start, Point end)
    {
        Start = start;
        End = end;
    }
}


class Program2
{
    public static void Main()
    {
        var point1 = new Point(8, 8);
        var point2 = new Point(0, 0);

        var distance = point1.DistanceToPoint(point2);
        Console.WriteLine($"Distance between point1 and point2: {distance}");

        var distanceToLine = point1.DistanceToLine(new Line(new Point(1, 1), new Point(5, 5)));
        Console.WriteLine($"Distance from point1 to the line: {distanceToLine}");
    }
}

//homework #7

class SumOfNumbers
{
    static int? Sum(params int?[] numbers)
    {
        if (numbers == null)
        {
            throw new ArgumentNullException(nameof(numbers));
        }

        int? result = 0;

        foreach (var number in numbers)
        {
            if (number.HasValue)
            {
                result += number.Value;
            }
        }

        return result;
    }

    static void Main()
    {
        int? sumResult = Sum(1, 2, null, 10);
       
        Console.WriteLine($"Сума: {sumResult}");
    }
}

//homework #8
class TicketPriceValidator
{
    public static int GetTicketPriceDiscount(int groupSize, DayOfWeek dayOfWeek)
    {
        if (groupSize <= 0)
        {
            throw new ArgumentException("some exception");
        }

        int discount = 0;

        switch (dayOfWeek)
        {
            case DayOfWeek.Monday:
                if (groupSize >= 5 && groupSize < 10)
                {
                    discount = 20;
                }
                else if (groupSize >= 10)
                {
                    discount = 30;
                }
                break;

            case DayOfWeek.Tuesday:
            case DayOfWeek.Wednesday:
            case DayOfWeek.Thursday:
            case DayOfWeek.Friday:
                if (groupSize >= 5 && groupSize < 10)
                {
                    discount = 10;
                }
                else if (groupSize >= 10)
                {
                    discount = 15;
                }
                break;
            
            case DayOfWeek.Saturday:
            case DayOfWeek.Sunday:
                break;

            default:
                throw new ArgumentException("some exception");
        }

        return discount;
    }
}

class Program
{
    static void Main()
    {
        try
        {
            int discount = TicketPriceValidator.GetTicketPriceDiscount(8, DayOfWeek.Monday);
            Console.WriteLine($"Discount is: {discount}%");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}


//homework #9
class Kitty
{
    public string Name { get; set; }

    public Kitty(string name)
    {
        Name = name;
    }
}

class Puppy
{
    public string Name { get; set; }

    public Puppy(string name)
    {
        Name = name;
    }
}

class Computer
{
    public string Model { get; set; }

    public Computer(string model)
    {
        Model = model;
    }
}

class ObjectConsole
{
    public static void PrintObjectName(object obj)
    {
        Console.WriteLine($"Object Type: {obj.GetType().Name}");

        switch (obj)
        {
            case Kitty cat:
                Console.WriteLine($"Cat Name: {cat.Name}");
                break;
            case Puppy dog:
                Console.WriteLine($"Dog Name: {dog.Name}");
                break;
            case Computer computer:
                Console.WriteLine($"Computer Model: {computer.Model}");
                break;
            default:
                Console.WriteLine("Unknown object type");
                break;
        }
    }
}

class Program3
{
    static void Main()
    {
        Kitty myCat = new Kitty("Whiskers");
        Puppy myDog = new Puppy("Buddy");
        Computer myComputer = new Computer("Laptop123");

        ObjectConsole.PrintObjectName(myCat);
        ObjectConsole.PrintObjectName(myDog);
        ObjectConsole.PrintObjectName(myComputer);
    }
}
