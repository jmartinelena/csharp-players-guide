CookieGame game = new CookieGame();

Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("There are 10 cookies. One of them is bad. You want to avoid eating the bad one.");
Console.WriteLine("At each turn you'll be asked to choose a number corresponding to the cookie you want to eat. If you choose the bad one you lose.");

Console.ForegroundColor = ConsoleColor.Yellow;
Console.WriteLine("-----------------------------------------------");
Console.ResetColor();

while (true)
{
    string currentPlayer = game.Player1Turn ? "Player 1" : "Player 2";
    Console.WriteLine($"It is {currentPlayer}'s turn.");

    try
    {
        Console.WriteLine(game.ShowEaten());
        game.EatCookie();
    }
    catch (BadCookieEatenException ex)
    {
        Console.WriteLine(ex.Message);
        string winner = game.Player1Turn ? "Player 2" : "Player 1";
        Console.WriteLine($"{winner} has won the game!");
        break;
    }
    finally
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("-----------------------------------------------");
        Console.ResetColor();
    }
}
Console.ReadKey();

public class CookieGame
{
    private int _badCookie;
    private List<int> _usedNumbers;
    private bool _player1Turn = true;

    public CookieGame()
    {
        _badCookie = new Random().Next(10);
        _usedNumbers = new List<int>();
    }

    public bool Player1Turn { get { return _player1Turn; } }

    public void EatCookie()
    {
        while (true)
        {
            Console.Write("Please choose a number between 0 and 9: ");
            string input = Console.ReadLine();
            if (int.TryParse(input, out int result) && result >= 0 && result <= 9)
            {
                if (_usedNumbers.Contains(result))
                {
                    Console.WriteLine("That number has already been chosen. Choose another one.");
                } 
                else
                {
                    _usedNumbers.Add(result);
                    Console.WriteLine($"Cookie {result} eaten.");
                    if (result == _badCookie) throw new BadCookieEatenException();
                    _player1Turn = !_player1Turn;
                    break;
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Try again.");
            }
        }
    }

    public string ShowEaten()
    {
        if (_usedNumbers.Count == 0)
        {
            return "No cookies eaten yet.";
        }
        else
        {
            string eaten = "Cookies eaten: ";
            foreach (int cookie in _usedNumbers)
            {
                eaten += $"{cookie} ";
            }
            return eaten;
        }

    }
}

public class BadCookieEatenException : Exception
{
    public BadCookieEatenException() : base("You ate the bad cookie. The game is over.")
    {

    }
}