Coordinate p1 = new Coordinate();
Coordinate p2 = new Coordinate(1,0);
Coordinate p3 = new Coordinate(3,3);
Console.WriteLine($"p1 ({p1}): \n\tAdjacent to p2 ({p2})? {p1.IsAdjacent(p2)}\n\tAdjacent to p3 ({p3})? {p1.IsAdjacent(p3)}");

public struct Coordinate
{
    public int Row { get; init; }
    public int Column { get; init; }

    public Coordinate(int row, int col)
    {
        Row = row; Column = col;
    }

    public bool IsAdjacent(Coordinate other)
    {
        return other.Row == this.Row || other.Column == this.Column;
    }

    public override string ToString()
    {
        return $"row: {this.Row} column: {this.Column}";
    }
}