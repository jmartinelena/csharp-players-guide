using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalBattle.Common
{
    public static class ConsoleHelper
    {
        public static string Ask(string question)
        {
            string? answer;

            while (true)
            {
                Console.Write(question + " ");
                Console.ForegroundColor = ConsoleColor.Cyan;

                answer = Console.ReadLine();
                Console.ResetColor();

                if (answer != null)
                {
                    Console.WriteLine();
                    return answer;
                }
                else
                {
                    Console.WriteLine("Invalid answer, try again.");
                }
            }
        }
    }
}
