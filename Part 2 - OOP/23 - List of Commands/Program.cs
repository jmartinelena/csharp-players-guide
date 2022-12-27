Robot robot = new Robot();
while (true)
{
    Console.Write("Write a command for the robot to do, or stop if you want to stop adding commands: ");
    string? input = Console.ReadLine();
    if (input == "stop") break;
    // You can use interfaces as types for a variable, and put any object that implements that interface into the variable
    IRobotCommand command = input switch
    {
        "on" => new OnCommand(),
        "off" => new OffCommand(),
        "north" => new NorthCommand(),
        "south" => new SouthCommand(),
        "east" => new EastCommand(),
        "west" => new WestCommand(),
        _ => new OnCommand() // Default
    };
    robot.Commands.Add(command);
}
robot.Run();
public class Robot
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool IsPowered { get; set; }
    // This following line lets you do Commands[i] = something but not Commands = new RobotCommand[x];
    // public IRobotCommand?[] Commands { get; } = new IRobotCommand?[3];
    public List<IRobotCommand> Commands { get; } = new List<IRobotCommand>();
    public void Run()
    {
        foreach (IRobotCommand? command in Commands)
        {
            command?.Run(this);
            Console.WriteLine($"[{X} {Y} {IsPowered}]");
        }
    }
}

public interface IRobotCommand
{
    public void Run(Robot robot);
}
public class OnCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = true;
    }
}

public class OffCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        robot.IsPowered = false;
    }
}
public class NorthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y += 1;
    }
}

public class SouthCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.Y -= 1;
    }
}

public class WestCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X -= 1;
    }
}
public class EastCommand : IRobotCommand
{
    public void Run(Robot robot)
    {
        if (robot.IsPowered) robot.X += 1;
    }
}