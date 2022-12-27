Console.WriteLine("Choose one of the following options as the delegate for the Sieve class: ");
Console.WriteLine("\t1 - IsEven\n\t2 - IsOdd\n\t3 - IsMultipleOfTen\n\tExit - breaks the loop\n");
while (true)
{
    Console.Write("Input your desired command: ");
    string input = Console.ReadLine();
    string[] options = new string[4] { "1", "2", "3", "exit" };
    if (!options.Contains(input)) { Console.WriteLine("Wrong command. Try again."); continue; }
    if (input == "exit") break;
    Sieve sieve = input switch
    {
        "1" => new Sieve(IsEven),
        "2" => new Sieve(IsOdd),
        "3" => new Sieve(IsMultipleOfTen)
    };
    while (true)
    {
        Console.Write("Input a number or 'exit': ");
        string answer = Console.ReadLine();
        if (!int.TryParse(answer, out int _) && answer != "exit") { Console.WriteLine("Not a number. Try again."); continue; }
        else if (answer == "exit") break;
        else if (int.TryParse(answer, out int result))
        {
            string isGood = sieve.IsGood(result) ? "is" : "is not";
            Console.WriteLine($"The number {result} {isGood} good.");
        }
    }
}

bool IsEven(int number)
{
    return number % 2 == 0;
}

bool IsOdd(int number)
{
    return number % 2 != 0;
}

bool IsMultipleOfTen(int number)
{
    return number % 10 == 0;
}

public class Sieve
{
    private Func<int, bool> _delegate;

    public Sieve(Func<int, bool> delegate1)
    {
        _delegate = delegate1;
    }
    
    public bool IsGood(int number)
    {
        return _delegate(number);
    }
}