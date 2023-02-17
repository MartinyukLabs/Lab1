using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    internal class Program
    {
        public delegate double Calculate(double a, double b);
        public delegate int GetNumber();
        public static void Main()
        {
            Third();
        }
        public static void First()
        {
            while (true)
            {
                Console.Write("Input +, -, *, /:");
                char operatorSymbol = Convert.ToChar(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Input number a:");
                double a = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                Console.Write("Input number b:");
                double b = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine();
                switch (operatorSymbol)
                {
                    case '+':
                        Calculate plus = (num1, num2) => num1 + num2;
                        Console.WriteLine($"Result: { plus(a, b) }");
                        break;
                    case '-':
                        Calculate minus = (num1, num2) => num1 - num2;
                        Console.WriteLine($"Result: { minus(a, b) }");
                        break;
                    case '*':
                        Calculate mul = (num1, num2) => num1 * num2;
                        Console.WriteLine($"Result: { mul(a, b) }");
                        break;
                    case '/':
                        Calculate div = (num1, num2) => num2 == 0 ? 0 : num1 / num2;
                        Console.WriteLine($"Result: { div(a, b) }");
                        break;
                    default:
                        return;
                }
            }
        }
        public static void Second()
        {
            Console.Write("Input count of nums: ");
            int count = Convert.ToInt32(Console.ReadLine());
            List<GetNumber> delegates = new List<GetNumber>();
            Random r = new Random();
            for(int i = 0; i < count; i++)
                delegates.Add(() => r.Next(10));
            Console.WriteLine($"Avegate result: { Average(delegates) }");
        }
        static double Average(List<GetNumber> delegates)
        {
            double sum = 0;
            Console.WriteLine("Values:");
            Console.WriteLine("--------------------");
            foreach(var del in delegates)
            {
                int value = del();
                Console.WriteLine(value);
                sum += value;
            }
            Console.WriteLine("--------------------");
            return sum / delegates.Count();
        }
        public static void Third()
        {
            Console.Write("Input number a:");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Input number b:");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.Write("Input number c:");
            int c = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            Console.WriteLine($"Average result: { Average(a, b, c) }");
        }
        static double Average(int a, int b, int c) => (a + b + c) / 3;
    }
}
