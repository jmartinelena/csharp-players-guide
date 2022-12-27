Game game = new Game();
game.Run();

class Game
{
    private int _round;
    private bool _player;
    private char _symbol;
    private Board _board;
    public Game()
    {
        _round = 1;
        _player = true;
        _symbol = 'X';
        _board = new Board();
    }
    public void StartRound()
    {
        int player = _player ? 1 : 2;
        this._symbol = _player ? 'X' : 'O';
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine($"Round: {_round} | Player's turn: Player {player}");
        Console.ForegroundColor = ConsoleColor.White;
        _board.Show();
    }
    public void Run()
    {
        while (true)
        {
            StartRound();
            char[,] chars = _board.Chars;
            int row;
            int col;
            while (true)
            {
                Console.Write("Which row do you want to place your move in?: ");
                row = Convert.ToInt32(Console.ReadLine());
                Console.Write("Which column do you want to place your move in?: ");
                col = Convert.ToInt32(Console.ReadLine());
                //Console.WriteLine($"Chosen: {chars[row,col]}");
                if (chars[row, col] == ' ') { break; } else { Console.WriteLine("Space already occupied, try again."); }
            }
            _board.Update(row, col, _symbol);
            _board.Show();
            //Console.WriteLine(_board.Check(_symbol));
            char result = _board.Check(_symbol);
            if (result == _symbol)
            {
                int player = _player ? 1 : 2;
                Console.WriteLine($"Player {player} has won.");
                break;
            } else if (result == 's')
            {
                Console.WriteLine("The game has tied.");
                break;
            }
            _round++;
            _player = !_player;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("-----------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

class Board
{
    private char[,] _char = new char[3, 3] { { ' ', ' ', ' ' }, { ' ', ' ', ' ' }, { ' ', ' ', ' ' } };
    public char[,] Chars { get => _char; }
    public void Update(int x, int y, char symbol)
    {
        if (_char[x,y] == ' ') _char[x, y] = symbol;
    }
    public void Show()
    {
        string board = $"2: {_char[2, 0]} | {_char[2, 1]} | {_char[2, 2]} \n";
        board += "  ---+---+--- \n";
        board += $"1: {_char[1, 0]} | {_char[1, 1]} | {_char[1, 2]} \n";
        board += "  ---+---+--- \n";
        board += $"0: {_char[0, 0]} | {_char[0, 1]} | {_char[0, 2]} \n";
        board += "   0   1   2  \n";
        Console.WriteLine(board);
    }
    public char Check(char symbol)
    {
        char result = ' ';
        for (int row = 0; row < 3; row++)
        {
            if (_char[row, 0] == symbol && _char[row, 1] == symbol && _char[row, 2] == symbol)
            {
                result = symbol;
                break;
            }
        }
        for (int col = 0; col < 3; col++)
        {
            if (_char[0, col] == symbol && _char[1, col] == symbol && _char[2, col] == symbol)
            {
                result = symbol;
                break;
            }
        }
        if ((_char[0, 0] == symbol && _char[1, 1] == symbol && _char[2, 2] == symbol) || (_char[2, 0] == symbol && _char[1, 1] == symbol && _char[0, 2] == symbol))
        {
            result = symbol;
        }
        bool hasSpace = false;
        foreach (char c in _char)
        {
            if (c==' ')
            {
                hasSpace = true;
                break;
            }
        }
        if (!hasSpace) return 's';
        return result;
    }
}
