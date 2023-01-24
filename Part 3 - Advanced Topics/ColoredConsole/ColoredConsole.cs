using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helper
{
    public static class ColoredConsole
    {
        public static string Prompt(string question)
        {
            string answer;

            while (true)
            {
                Console.Write(question + " ");

                Console.ForegroundColor = ConsoleColor.Cyan;
                answer = Console.ReadLine();
                Console.ResetColor();

                if (answer != null) break;
                else Console.WriteLine("Invalid answer, try again.");
            }
            return answer;
        }

        public static void WriteLine(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
            Console.ResetColor();
        }

        public static void Write(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
    }
}
