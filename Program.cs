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
            Console.WriteLine($"Y = {x}");
            Console.ReadKey();
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
                if (c == '.' || c == ',') c = separateChar;
                _str += c.ToString();
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
