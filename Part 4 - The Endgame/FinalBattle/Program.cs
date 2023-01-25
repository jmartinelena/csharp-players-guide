using FinalBattle;

List<Character> heroParty = new List<Character>{ new Character("SKELETON") };
List<Character> enemyParty = new List<Character>{ new Character("SKELETON") };

bool heroPartyTurn = true;

while (true)
{
    List<Character> party = heroPartyTurn ? heroParty : enemyParty;

    foreach (Character character in party)
    {
        Console.ForegroundColor = heroPartyTurn ? ConsoleColor.Blue : ConsoleColor.Red;
        Console.WriteLine($"It is {character.Name}'s turn...");
        Console.ResetColor();

        Console.WriteLine(character.DoNothing());
        Console.WriteLine();

        Thread.Sleep(500);
    }
    
    heroPartyTurn = !heroPartyTurn;
}