Console.Write("Input a pass code for your new door: ");
int code = Convert.ToInt32(Console.ReadLine());
Door door = new Door(code);
Console.WriteLine("The door has been created.\nYou can use it by typing 'unlock' to unlock it, 'lock' to lock it, 'open' to open it and 'close' to close it. You can also 'change' to change the door's code.");
while (true)
{
    Console.WriteLine($"The door is currently {door.State}");
    Console.Write("What do you want to do? You can also exit with 'exit'. Answer: ");
    string response = Console.ReadLine().ToLower() ?? "exit";
    if (response == "exit") break;
    if (response == "unlock" && door.State == State.Locked)
    {
        Console.Write("Input the door's code: ");
        int guessedCode = Convert.ToInt32(Console.ReadLine());
        door.Unlock(guessedCode);
    } else if (response == "lock" && door.State == State.Closed)
    {
        door.Lock();
    } else if (response == "open" && door.State == State.Closed)
    {
        door.Open();
    } else if (response == "close" && door.State == State.Open)
    {
        door.Close();
    }
    if (response == "change")
    {
        Console.Write("Input the old door's code: ");
        int guessedCode = Convert.ToInt32(Console.ReadLine());
        Console.Write("Input the new door's code: ");
        int newCode = Convert.ToInt32(Console.ReadLine());
        door.ChangeCode(guessedCode, newCode);
    }
}

class Door
{
    private int _code;
    private State _state;
    public Door(int code)
    {
        _code = code;
        _state = State.Locked;
    }
    public State State { get { return _state; } }
    public void ChangeCode(int oldCode, int newCode)
    {
        if (oldCode == _code)
        {
            _code = newCode;
        } else
        {
            Console.WriteLine("Wrong original code, can't change the door's code to the new one.");
        }
    }
    public void Unlock(int code)
    {
        if (code == _code && _state == State.Locked)
        {
            _state = State.Closed;
        }
    }
    public void Lock()
    {
        if (_state == State.Closed)
        {
            _state = State.Locked;
        }
    }
    public void Open()
    {
        if (_state == State.Closed)
        {
            _state = State.Open;
        }
    }
    public void Close()
    {
        if (_state == State.Open)
        {
            _state = State.Closed;
        }
    }
}

enum State { Open, Closed, Locked}