Console.Title = "The Magic Cannon";
for (int i = 1; i <= 100; i++)
{
    string type;
    if (i % 3 == 0 && i % 5 == 0) { type = "Electric and Fire"; Console.ForegroundColor = ConsoleColor.Blue; }
    else if (i % 3 == 0) { type = "Fire"; Console.ForegroundColor = ConsoleColor.Red; }
    else if (i % 5 == 0) { type = "Electric"; Console.ForegroundColor = ConsoleColor.Yellow; }
    else { type = "Normal"; Console.ForegroundColor = ConsoleColor.White; };
    Console.WriteLine($"{i}: {type}");
}
