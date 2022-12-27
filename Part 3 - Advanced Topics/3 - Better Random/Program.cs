Random random = new Random();
Console.WriteLine(random.NextDouble(100));
Console.WriteLine(random.NextString("si","no","tal vez"));
Console.WriteLine(random.CoinFlip(0.75f));

public static class RandomExtensions
{
    public static double NextDouble(this Random random, double value)
    {
        return random.NextDouble() * value;
    }

    public static string NextString(this Random random, params string[] options)
    {
        return options[random.Next(options.Length)];
    }

    public static bool CoinFlip(this Random random, float chanceOfTrue = 0.5f)
    {
        return (random.NextDouble() <= chanceOfTrue);
    }
}