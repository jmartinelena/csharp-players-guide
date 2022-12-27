Pack pack = new Pack(10, 6, 4);
Console.WriteLine($"Max volume: {pack.MaxVolume} Max items: {pack.MaxItems} Max weight: {pack.MaxWeight}");
Bow bow = new Bow();
Sword sword = new Sword();
Console.WriteLine($"Current volume: {pack.CurrentVolume} Current items: {pack.CurrentItems} Current Weight {pack.CurrentWeight}");
Console.WriteLine(pack.ToString());
bool add1 = pack.Add(sword);
Console.WriteLine(add1 ? "Added sword." : "Didn't add sword.");
Console.WriteLine($"Current volume: {pack.CurrentVolume} Current items: {pack.CurrentItems} Current Weight {pack.CurrentWeight}");
Console.WriteLine(pack.ToString());
bool add2 = pack.Add(bow);
Console.WriteLine(add2 ? "Added bow." : "Didn't add bow.");
Console.WriteLine($"Current volume: {pack.CurrentVolume} Current items: {pack.CurrentItems} Current Weight {pack.CurrentWeight}");
Console.WriteLine(pack.ToString());
Rope rope = new Rope();
bool add3 = pack.Add(rope);
Console.WriteLine(add3 ? "Added rope." : "Didn't add rope.");
Console.WriteLine($"Current volume: {pack.CurrentVolume} Current items: {pack.CurrentItems} Current Weight {pack.CurrentWeight}");
Console.WriteLine(pack.ToString());

class Pack
{
    private float _maxVolume;
    private float _maxWeight;
    private int _maxItems;
    private float _currentVolume;
    private float _currentWeight;
    private int _currentItems;
    private Item[] _items;
    public Pack(float maxVolume, float maxWeight, int maxItems)
    {
        _maxVolume = maxVolume;
        _maxWeight = maxWeight;
        _maxItems = maxItems;
        _currentItems = 0;
        _currentVolume = 0;
        _currentWeight = 0;
        _items = new Item[maxItems];
    }
    public float CurrentVolume => _currentVolume;
    public float CurrentWeight => _currentWeight;
    public int CurrentItems => _currentItems;
    public float MaxVolume => _maxVolume;
    public float MaxWeight => _maxWeight;
    public int MaxItems => _maxItems;

    public bool Add(Item item)
    {
        if (item.Weight <= MaxWeight - CurrentWeight && item.Volume <= MaxVolume - CurrentVolume && CurrentItems <= MaxItems)
        {
            _items[CurrentItems] = item;
            _currentItems++;
            _currentWeight += item.Weight;
            _currentVolume += item.Volume;
            return true;
        }
        else { return false; }
    }
    public override string ToString()
    {
        string content = "The pack contains: ";
        foreach (Item item in _items)
        {
            if (item != null) content += item.ToString()+ " ";
        }
        if (content == "The pack contains: ") content += "nothing";
        return content;
    }
}

class Item
{
    private float _volume;
    private float _weight;
    public float Volume { get { return _volume; } }
    public float Weight { get { return _weight; } }
    public Item(float volume, float weight)
    {
        _volume = volume;
        _weight = weight;
    }
}
class Arrow : Item
{
    public Arrow() : base(0.05f, 0.1f) { }
    public override string ToString()
    {
        return "Arrow";
    }
}
class Bow : Item
{
    public Bow() : base(4, 1) { }
    public override string ToString()
    {
        return "Bow";
    }
}
class Rope : Item
{
    public Rope() : base(1.5f, 1) { }
    public override string ToString()
    {
        return "Rope";
    }
}
class Food : Item
{
    public Food() : base(0.5f, 1) { }
    public override string ToString()
    {
        return "Food";
    }
}
class Water : Item
{
    public Water() : base(3, 2) { }
    public override string ToString()
    {
        return "Water";
    }
}
class Sword : Item
{
    public Sword() : base(3, 5) { }
    public override string ToString()
    {
        return "Sword";
    }
}