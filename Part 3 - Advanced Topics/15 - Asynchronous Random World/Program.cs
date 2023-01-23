Console.Write("Type in a word that you want to randomly recreate: ");
string word = Console.ReadLine() ?? "none";

DateTime now = DateTime.Now;
int count = await RandomlyRecreateAsync(word);
DateTime after = DateTime.Now;

Console.WriteLine($"It took {count} times and {(after-now).TotalSeconds:0.000} seconds to randomly recreate {word}.");

int RandomlyRecreate(string word)
{
    word = word.ToLower();
    Random random = new Random();
    int attempts = 0;

    while (true)
    {
        string randomWord = "";

        for (int i = 0; i < word.Length; i++)
        {
            char randomChar = (char)('a' + random.Next(26));
            randomWord += randomChar;
        }

        attempts++;

        if (randomWord == word) break;
    }

    return attempts;
}

Task<int> RandomlyRecreateAsync(string word)
{
    return Task.Run( () => RandomlyRecreate(word) );
}