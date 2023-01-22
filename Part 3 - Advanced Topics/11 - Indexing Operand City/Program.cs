BlockCoordinate coordinate = new BlockCoordinate(4, 3);

Console.WriteLine(coordinate[0]);
Console.WriteLine(coordinate[1]);

public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction { North, East, South, West }
public record BlockCoordinate(int Row, int Column)
{
    // One way to do it
    //public int this[int index]
    //{
    //    get
    //    {
    //        if (index == 0) return Row;
    //        else if (index == 1) return Column;
    //        else return -1;
    //    }
    //}
    
    // You can also do it with a switch expression
    // In both cases I return -1 to any other index just to make it exhaustive, but it is not necesary as per the exercise's requirements
    public int this[int index] => index switch { 0 => Row, 1 => Column, _ => -1 };
}