Console.Title = "Hunting the Manticore";
Console.Write("Player 1, how far away from the city do you want to station the Manticore? ");
int manticorePosition = Convert.ToInt32(Console.ReadLine());
Console.WriteLine("Player 2, it is your turn.");

int round = 1;
int cityHp = 15;
int manticoreHp = 10;

while (cityHp >= 0 && manticoreHp >= 0)
{
    StartRound(round);
    ShootCannon(round);
    cityHp--;
    round++;
    if (cityHp == 0 || manticoreHp == 0) { break; }
}

if (manticoreHp <= 0 && cityHp != 0) {
    Console.BackgroundColor = ConsoleColor.Green;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("The Manticore has been destroyed! The city of Consolas has been saved!");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
}
else if (manticoreHp != 0 && cityHp <= 0) {
    Console.BackgroundColor = ConsoleColor.Red;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("The Manticore has destroyed the city! The city of Consolas is no more!");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
}
else if (manticoreHp == 0 && cityHp ==0) {
    Console.BackgroundColor = ConsoleColor.Magenta;
    Console.ForegroundColor = ConsoleColor.Black;
    Console.WriteLine("Both the Manticore and the city of Consolas have been destroyed.");
    Console.BackgroundColor = ConsoleColor.Black;
    Console.ForegroundColor = ConsoleColor.White;
}

void StartRound(int currentRound)
{
    Console.ForegroundColor = ConsoleColor.Magenta;
    Console.WriteLine("________________________________________________________");
    Console.ForegroundColor = ConsoleColor.DarkCyan;
    Console.WriteLine($"STATUS: Round {round} City: {cityHp}/15 Manticore: {manticoreHp}/10");
    Console.WriteLine($"The cannon is expected to deal {ExpectedDamage(currentRound)} damage this round.");
}

int ExpectedDamage(int currentRound)
{
    int expectedDmg = 1;
    if (round % 3 == 0 && round % 5 == 0) { expectedDmg = 10; }
    else if (round % 3 == 0) { expectedDmg = 3; }
    else if (round % 5 == 0) { expectedDmg = 3; }
    return expectedDmg;
}

void ShootCannon(int currentRound)
{
    Console.ForegroundColor = ConsoleColor.Yellow;
    Console.Write("Enter desired cannon range: ");
    int cannonRange = Convert.ToInt32(Console.ReadLine());
    if (cannonRange > manticorePosition) { 
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.WriteLine("That round OVERSHOT the target."); }
    else if (cannonRange < manticorePosition) { 
        Console.ForegroundColor = ConsoleColor.Red; 
        Console.WriteLine("That round FELL SHORT of the target."); }
    else { 
        Console.ForegroundColor = ConsoleColor.Green; 
        Console.WriteLine("That round was a direct hit!"); 
        manticoreHp -= ExpectedDamage(currentRound); }
}