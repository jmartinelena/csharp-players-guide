Color[] colors = new Color[4] {Color.Red, Color.Green, Color.Blue, Color.Yellow};
Rank[] ranks = new Rank[] {Rank.One, Rank.Two, Rank.Three, Rank.Four, Rank.Five, Rank.Six, Rank.Seven, Rank.Eight, Rank.Nine, Rank.Ten, Rank.DollarSign, Rank.Percent, Rank.Carot, Rank.Ampersand};

foreach (Color color in colors)
{
    foreach (Rank rank in ranks)
    {
        Card card = new Card(color, rank);
        Console.WriteLine($"The {card.Color} {card.Rank}");
    }
}

enum Color { Red, Green, Blue, Yellow}
enum Rank { One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Ten, DollarSign, Percent, Carot, Ampersand}

class Card
{
    public Color Color { get; init; }
    public Rank Rank { get; init; }
    public bool IsSymbol => Rank == Rank.DollarSign || Rank == Rank.Percent || Rank == Rank.Carot || Rank == Rank.Ampersand;
    public bool IsNumber => !IsSymbol;

    public Card(Color color, Rank rank)
    {
        Color = color;
        Rank = rank;
    }
}