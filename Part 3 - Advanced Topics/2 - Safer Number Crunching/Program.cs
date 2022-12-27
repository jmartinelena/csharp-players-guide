Console.Title = "Safer Number Crunching";

Console.WriteLine("---------------------------------------------");

while (true)
{
    Console.Write("Enter a valid integer number: ");
    string input = Console.ReadLine();
    if (int.TryParse(input, out int result))
    {
        Console.WriteLine($"You've entered the value {result}.");
        break;
    }
    else
    {
        Console.WriteLine("You've entered an invalid value. Try again.");
    }
}

Console.WriteLine("---------------------------------------------");


while (true)
{
    Console.Write("Enter a valid double number: ");
    string input = Console.ReadLine();
    if (double.TryParse(input, out double result))
    {
        Console.WriteLine($"You've entered the value {result}.");
        break;
    }
    else
    {
        Console.WriteLine("You've entered an invalid value. Try again.");
    }
}

Console.WriteLine("---------------------------------------------");

while (true)
{
    Console.Write("Enter a valid bool value: ");
    string input = Console.ReadLine();
    if (bool.TryParse(input, out bool result))
    {
        Console.WriteLine($"You've entered the value {result}.");
        break;
    }
    else
    {
        Console.WriteLine("You've entered an invalid value. Try again.");
    }
}

Console.WriteLine("---------------------------------------------");

Console.ReadKey();