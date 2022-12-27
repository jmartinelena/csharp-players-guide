int result = AskForNumberInRange("Numero del 1 al 10", 1, 10);
Console.WriteLine(result);

int AskForNumber(string text)
{
    Console.Write(text);
    string response = Console.ReadLine();
    return Convert.ToInt32(response);
}

int AskForNumberInRange(string text, int min, int max)
{
    int response;
    while (true)
    {
        Console.Write(text + " ");
        response = Convert.ToInt32(Console.ReadLine());
        if (response >= min && response <= max) { break; }
        Console.WriteLine("We go again.");
    };
    return response;
}
