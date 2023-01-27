using FinalBattle;
using FinalBattle.Common;
using FinalBattle.Logic;
using FinalBattle.Logic.Actions;
using FinalBattle.Logic.Players;
using FinalBattle.Logic.Units;

string name = ConsoleHelper.Ask("True Programmer, what is your name?");

TrueProgrammer trueProgrammer = new TrueProgrammer(name);

Console.WriteLine("Game Mode Selection:");
Console.WriteLine("\t1 - Human vs. Computer");
Console.WriteLine("\t2 - Computer vs. Computer");
Console.WriteLine("\t3 - Human vs. Human");

IPlayer player1, player2;
int answer;

do
{
    string choice = ConsoleHelper.Ask("What mode do you want to use?");
    int.TryParse(choice, out answer);
    if (answer < 1 || answer > 3)
    {
        Console.WriteLine("Invalid answer, try again...");
    }
} while (answer < 1 || answer > 3);

if (answer == 1)
{
    player1 = new HumanPlayer();
    player2 = new ComputerPlayer();
}
else if (answer == 2)
{
    player1 = new ComputerPlayer();
    player2 = new ComputerPlayer();
}
else
{
    player1 = new HumanPlayer();
    player2 = new HumanPlayer();
}


Party heroParty = new Party(player1, new List<Character> { trueProgrammer });

List<Party> enemyParties = new List<Party> { 
    new Party(player2, new List<Character> { new Skeleton() }),
    new Party(player2, new List<Character> { new Skeleton(), new Skeleton() }),
    new Party(player2, new List<Character> {new UncodedOne()}) 
};

Battle battle = new Battle(heroParty, enemyParties);
battle.Run();

Console.WriteLine("\nThe game is over, you can press any key to exit...");
Console.ReadKey(true);