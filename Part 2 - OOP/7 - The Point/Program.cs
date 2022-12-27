Point point1 = new Point(2, 3);
Point point2 = new Point(-4, 0);
Console.WriteLine($"({point1.X},{point1.Y})");
Console.WriteLine($"({point2.X},{point2.Y})");

class Point
{
    public float X { get; init; }
    public float Y { get; init; }

    public Point(float x, float y)
    {
        X = x;
        Y = y;
    }
    public Point()
    {
        X = 0;
        Y = 0;
    }
}
