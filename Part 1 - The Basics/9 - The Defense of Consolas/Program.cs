﻿Console.Write("Target row: ");
int row = Convert.ToInt32(Console.ReadLine());
Console.Write("Target column: ");
int column = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Deploy to:");
Console.BackgroundColor = ConsoleColor.Magenta;
Console.WriteLine($"\t({row+1},{column})");
Console.WriteLine($"\t({row},{column+1})");
Console.WriteLine($"\t({row-1},{column})");
Console.WriteLine($"\t({row},{column-1})");
Console.BackgroundColor = ConsoleColor.Black;
Console.Beep();