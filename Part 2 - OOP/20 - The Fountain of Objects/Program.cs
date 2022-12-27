using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

Game game = new Game();
game.Run();

public class Maze
{
    private string[,] _grid = new string[4, 4];
    private int _currentRow = 0;
    private int _currentCol = 0;
    private bool _fountainOn = false;
    private string _location;

    public int CurrentRow { get => _currentRow; }
    public int CurrentCol { get => _currentCol; }
    public string[,] Grid { get => _grid; }
    public bool FountainOn { get => _fountainOn; set { _fountainOn = value; } }
    public string Location { get => _location; }
    public bool Lost { get; set; }
    private int _maelstromRow;
    private int _maelstromCol;
    private bool _skip = false;
    public bool Skip { get => _skip; set => _skip = value; }

    public Maze()
    {
        _grid[0, 0] = "entrance";
        _grid[0, 2] = "fountain";
        _maelstromRow = 1;
        _maelstromCol = 1;
        _grid[_maelstromRow, _maelstromCol] = "maelstrom";
        _grid[0, 3] = "pit";
        _location = _grid[_currentRow, _currentCol];
    }

    public void Update(int row, int col)
    {
        _currentRow = row;
        _currentCol = col;
        _location = _grid[_currentRow, _currentCol];
    }

    public bool Won()
    {
        return _fountainOn && _location == "entrance";
    }

    public void CheckDanger()
    {
        bool CheckMaelstrom() { if (!(CurrentRow == _maelstromRow && CurrentCol == _maelstromCol)) { return Math.Abs(CurrentRow - _maelstromRow) <= 1 && Math.Abs(CurrentCol - _maelstromCol) <= 1; } else { return false; } };
        bool CheckPit() { if (!(CurrentRow == 0 && CurrentCol == 3)) { return Math.Abs(CurrentRow - 0) <= 1 && Math.Abs(CurrentCol - 3) <= 1; } else { return false; } }

        if (CheckMaelstrom()) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("You hear the growling and groaning of a maelstrom nearby."); }
        if (CheckPit()) { Console.ForegroundColor = ConsoleColor.Red; Console.WriteLine("You feel a draft. There is a pit in a nearby room."); }
    }

    public void Describe()
    {
        _skip = false;
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine($"You are in the room at (Row={_currentRow}), Column={_currentCol}).");
        if (_location == "entrance" && !_fountainOn)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("You see light coming from the cavern entrance.");
        }
        if (_location == "fountain" && !_fountainOn)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
        }
        if (_location == "fountain" && _fountainOn)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You hear the rushing water from The Fountain of Objects. It has been reactivated!");
        }
        if (_location == "pit")
        {
            Lost = true;
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You have fallen into a pit!\nYou lose!");
        }
        if (_location == "maelstrom")
        {
            _grid[_maelstromRow, _maelstromCol] = null;
            _maelstromRow = Math.Clamp(_maelstromRow + 1, 0, 3);
            _maelstromCol = Math.Clamp(_maelstromCol - 2, 0, 3);
            _grid[_maelstromRow, _maelstromCol] = "maelstrom";
            _currentRow = Math.Clamp(_currentRow - 1, 0, 3);
            _currentCol = Math.Clamp(_currentCol + 2, 0, 3);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("You ran into the maelstrom and got sent flying! You were moved two cells to the west and one to the north.");
            _skip = true;
            _location = _grid[_currentRow, _currentCol];
        }
        CheckDanger();
        if (Won())
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!\nYou Win!");
        }
        Console.ForegroundColor = ConsoleColor.White;
    }
}

public class Game
{
    private Maze _maze;

    public Game()
    {
        _maze = new Maze();
    }

    public void Move()
    {
        int currentRow = _maze.CurrentRow;
        int currentCol = _maze.CurrentCol;
        string location = _maze.Location;
        while (true)
        {
            Console.Write("What do you want to do? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string answer = Console.ReadLine();
            if (answer == "move north" && currentRow >=1) { _maze.Update(currentRow - 1, currentCol); break; }
            else if (answer == "move south" && currentRow <=2) { _maze.Update(currentRow + 1, currentCol); break; }
            else if (answer == "move east" && currentCol<=2) { _maze.Update(currentRow, currentCol + 1); break; }
            else if (answer == "move west" && currentCol >=1) { _maze.Update(currentRow, currentCol - 1); break; }
            else if (answer == "enable fountain" && location == "fountain") { _maze.FountainOn = true; break; }
            else if (answer == "help") { Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("The available commands are:\n\tmove north - moves up one cell (row +1)\n\tmove south - moves down one cell (row -1)\n\tmove east - moves right one cell (col +1)\n\tmove west - moves left one cell (col -1)\n\tenable fountain - enables the Fountain of Objects if in the right room"); }
            else { Console.ForegroundColor = ConsoleColor.White; Console.WriteLine("Invalid move. Try again."); }
        }       
    }

    public void Run()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;
        //Console.WriteLine("You have made your way to the Cavern of Objects, high atop jagged mountains. Within these caverns\r\nlies the Fountain of Objects, the one-time source of the River of Objects that gave life to this entire\r\nisland. By returning the Heart of Object-Oriented Programming—the gem you received from Simula\r\nafter arriving on this island—to the Fountain of Objects, you can repair and restore the fountain to its\r\nformer glory.\nThe cavern is a grid of rooms, and no natural or human-made light works within due to unnatural\r\ndarkness. You can see nothing, but you can hear and smell your way through the caverns to find the\r\nFountain of Objects, restore it, and escape to the exit.");
        Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits in search of the Fountain of Objects.\r\nLight is visible only in the entrance, and no other light is seen anywhere in the caverns.\r\nYou must navigate the Caverns with your other senses.\r\nLook out for pits. You will feel a breeze if a pit is in an adjacent room. If you enter a room with a pit, you will die.\nMaelstroms are violent forces of sentient wind. Entering a room with one could transport you to any other location in the caverns. You will be able to hear their growling and groaning in nearby rooms.\nFind the Fountain of Objects, activate it, and return to the entrance.\n\nYou can type the command help for a list of available commands.");
        Console.ForegroundColor = ConsoleColor.White;
        _maze.Lost = false;
        while (true)
        {
            _maze.Describe();
            if (_maze.Won()) break;
            if (_maze.Lost) break;
            if (_maze.Skip) { _maze.Skip = false; continue; };
            Move();
        }
    }
}