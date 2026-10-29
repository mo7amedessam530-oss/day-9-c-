using System;
using System.Collections.Generic;

namespace CsharpTask9Solutions
{
    // 1. Enums Examples
    enum Weekdays
    {
        Monday = 1,
        Tuesday,
        Wednesday,
        Thursday,
        Friday
    }

    enum Grades : short
    {
        F = 1,
        D,
        C,
        B,
        A
    }

    enum Gender : byte
    {
        Male,
        Female
    }

    // 2. Operator Overloading Example
    public class ComplexNumber
    {
        public double Real { get; set; }
        public double Imaginary { get; set; }

        public ComplexNumber(double real, double imaginary)
        {
            Real = real;
            Imaginary = imaginary;
        }

        public static ComplexNumber operator *(ComplexNumber c1, ComplexNumber c2)
        {
            return new ComplexNumber(
                (c1.Real * c2.Real) - (c1.Imaginary * c2.Imaginary),
                (c1.Real * c2.Imaginary) + (c1.Imaginary * c2.Real)
            );
        }

        public override string ToString() => $"{Real} + {Imaginary}i";
    }

    // 3. Utility Class for Static Methods
    public static class Utility
    {
        public static double CalculateRectanglePerimeter(double length, double width)
        {
            return 2 * (length + width);
        }

        public static double CelsiusToFahrenheit(double celsius)
        {
            return (celsius * 9 / 5) + 32;
        }
    }

    // 4. Generic Helper & Stack Implementation
    public static class Helper
    {
        public static T Max<T>(T a, T b) where T : IComparable<T>
        {
            return a.CompareTo(b) > 0 ? a : b;
        }

        public static T[] ReverseArray<T>(T[] array)
        {
            T[] reversed = new T[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                reversed[i] = array[array.Length - 1 - i];
            }
            return reversed;
        }
    }

    public class CustomStack<T>
    {
        private List<T> elements = new List<T>();

        public void Push(T item)
        {
            elements.Add(item);
        }

        public T Pop()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Stack is empty.");
            T item = elements[elements.Count - 1];
            elements.RemoveAt(elements.Count - 1);
            return item;
        }

        public T Peek()
        {
            if (elements.Count == 0) throw new InvalidOperationException("Stack is empty.");
            return elements[elements.Count - 1];
        }

        public int Count => elements.Count;
    }

    // Program Entry Point
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== 1. Enums Demo ===");
            foreach (var day in Enum.GetValues(typeof(Weekdays)))
            {
                Console.WriteLine($"Day: {day}, Value: {(int)day}");
            }

            Console.WriteLine("\n=== 2. Operator Overloading Demo ===");
            ComplexNumber c1 = new ComplexNumber(2, 3);
            ComplexNumber c2 = new ComplexNumber(4, 5);
            ComplexNumber c3 = c1 * c2;
            Console.WriteLine($"({c1}) * ({c2}) = {c3}");

            Console.WriteLine("\n=== 3. Utility Methods Demo ===");
            double perimeter = Utility.CalculateRectanglePerimeter(5.0, 10.0);
            double fahrenheit = Utility.CelsiusToFahrenheit(25.0);
            Console.WriteLine($"Rectangle Perimeter: {perimeter}");
            Console.WriteLine($"25 C to Fahrenheit: {fahrenheit}");

            Console.WriteLine("\n=== 4. Generics (Max & Reverse) Demo ===");
            int maxInt = Helper.Max(15, 42);
            Console.WriteLine($"Max of 15 and 42: {maxInt}");

            string[] names = { "Ali", "Mohamed", "Omar" };
            string[] reversedNames = Helper.ReverseArray(names);
            Console.WriteLine($"Reversed Array: {string.Join(", ", reversedNames)}");

            Console.WriteLine("\n=== 5. Custom Generic Stack Demo ===");
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            Console.WriteLine($"Stack Peek: {stack.Peek()}");
            Console.WriteLine($"Popped: {stack.Pop()}");
            Console.WriteLine($"Stack Count After Pop: {stack.Count}");
        }
    }
}