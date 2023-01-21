Console.Write("Enter your name: ");
string name = Console.ReadLine() ?? "unknown";

Score score = ScoreUpdater.StartScore(name);

Console.WriteLine($"Welcome, {name}.");
Console.Write(ScoreUpdater.ReadScore(score));
Console.WriteLine(" Every time you press a key on your keyboard that's not the enter key you increase your keypress" +
    " score. If you press the enter key, the game ends and saves your score to a txt file named after you.\n");

while (true)
{
    //Console.WriteLine("Press any key to increase your score, or press enter to stop.");
    Console.WriteLine(ScoreUpdater.ReadScore(score));
    if (Console.ReadKey(true).Key != ConsoleKey.Enter)
    {
        ScoreUpdater.AddPress(score);
    }
    else
    {
        break;
    }
}

Console.WriteLine("Saving your score...");
ScoreUpdater.SaveScore(score);
Console.WriteLine("Score saved. Press any key to stop the program...");
Console.ReadKey(true);

public class Score
{
    public string Name;
    public int Keypresses = 0;

    public Score(string name)
    {
        Name = name;
        Keypresses = 0;
    }

    public Score(string name, int keypresses) : this(name)
    {
        Keypresses = keypresses;
    }
}

public static class ScoreUpdater
{
    public static void AddPress(Score score)
    {
        score.Keypresses += 1;
    }

    public static Score StartScore(string name)
    {
        if (File.Exists($"{name}.txt"))
        {
            int keypresses = Convert.ToInt32(File.ReadAllText($"{name}.txt"));

            return new Score(name, keypresses);
        }
        else
        {
            return new Score(name);
        }
    }

    public static string ReadScore(Score score)
    {
        return $"Your total ammount of keypresses is: {score.Keypresses}.";
    }

    public static void SaveScore(Score score)
    {
        File.WriteAllText($"{score.Name}.txt", Convert.ToString(score.Keypresses));
    }
}