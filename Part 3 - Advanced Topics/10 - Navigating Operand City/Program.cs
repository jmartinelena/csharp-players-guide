Console.WriteLine(new BlockCoordinate(4, 3) + new BlockOffset(2, 0));
Console.WriteLine(new BlockCoordinate(4, 3) + Direction.East);
Console.WriteLine(new BlockOffset(2, 0) + new BlockCoordinate(4, 3));
Console.WriteLine(Direction.East + new BlockCoordinate(4, 3));

public record BlockOffset(int RowOffset, int ColumnOffset);
public enum Direction { North, East, South, West }
public record BlockCoordinate(int Row, int Column)
{
    public static BlockCoordinate operator +(BlockCoordinate coord, BlockOffset offset)
    {
        return new BlockCoordinate(coord.Row + offset.RowOffset, coord.Column + offset.ColumnOffset);
    }

    public static BlockCoordinate operator +(BlockOffset offset, BlockCoordinate coord) => coord + offset;

    public static BlockCoordinate operator +(BlockCoordinate coord, Direction dir)
    {
        BlockCoordinate blockCoordinate = dir switch
        {
            Direction.North => new BlockCoordinate(coord.Row - 1, coord.Column),
            Direction.South => new BlockCoordinate(coord.Row + 1, coord.Column),
            Direction.East => new BlockCoordinate(coord.Row, coord.Column + 1),
            Direction.West => new BlockCoordinate(coord.Row, coord.Column - 1)
        };
        return blockCoordinate;
    }

    public static BlockCoordinate operator +(Direction dir, BlockCoordinate coord) => coord + dir;
};