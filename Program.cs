using System;

namespace HW2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetInput getInput = new GetInput();
            double x = getInput.Double("Введите Х: ");
            double z = getInput.Double("Введите Z: ");
            double k = getInput.Double("Введите K: ");
            double y = (Math.Sqrt(x * (2 + 3 * x + 4 * x * x)) + 19 * z / (15 * k)) / (Math.Sqrt(2 * z + Math.Pow(x, 4)) - 24 * z * (x + 7));
            Console.WriteLine($"Считали одной строкой. Y = {y}");
            y = Part1(x) + Part2(z, k);
            if ((k = Part3(z, x) - Part4(z, x)) == 0)
            {
                Console.WriteLine("Исключение: Деление на ноль");
                Console.ReadKey();
                return;
            }
            y /= k;
            Console.WriteLine($"Разбили на функции. Y = {y}");
            Console.ReadKey();
        }
        static double Part1(double a)
        {
            double result;
            result = 2 * a;
            result += 3 * Math.Pow(a, 2);
            result += 4 * Math.Pow(a, 3);
            result = Math.Sqrt(result);
            return result;
        }
        static double Part2(double a, double b)
        {
            if (b == 0)
            {
                Console.WriteLine("Исключение в Part2: деление на ноль");
                return 0;
            }
            double result;
            result = 19 * a;
            result /= (15 * b);
            return result;
        }
        static double Part3(double a, double b)
        {
            double result;
            result = 2 * a;
            result += Math.Pow(b, 4);
            if (result < 0)
            {
                Console.WriteLine("Исключение в Part3: извлечение SQRT из отрицательного числа");
                return 0;
            }
            result = Math.Sqrt(result);
            return result;
        }
        static double Part4(double a, double b)
        {
            double result;
            result = 24 * a;
            result *= (b + 7);
            return result;
        }

    }
    internal class GetInput
    {
        internal double Double(string _askDouble)
        {
            string _str = string.Empty;
            char c;
            ConsoleKeyInfo cki = new ConsoleKeyInfo();
            char separateChar = System.Globalization.CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator[0];
            if (Console.CursorLeft > 0) _askDouble = "\n" + _askDouble;
            Console.Write(_askDouble);
            while (true)
            {
                cki = Console.ReadKey(true);
                if (cki.Key == ConsoleKey.Backspace && _str.Length > 0)
                {
                    _str = _str.Remove(_str.Length - 1);
                    Console.Write("\b \b");
                    continue;
                }
                c = cki.KeyChar;
                if (c == '.' || c == ',')
                {
                    c = separateChar;
                }
                _str += c.ToString();
                if ((c == separateChar || c == '-') && _str.Length == 1)
                {
                    Console.Write(c);
                    continue;
                }

                if (double.TryParse(_str, out double result))
                    Console.Write(c);
                else
                    _str = _str.Remove(_str.Length - 1);
                if (cki.Key == ConsoleKey.Enter)
                {
                    Console.WriteLine();
                    return result;
                }
            }
        }
    }
}
