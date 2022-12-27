//Sword sword = new Sword();
//Bow bow = new Bow();
//Axe axe = new Axe();
ColoredItem<Sword> blueSword = new ColoredItem<Sword>(new Sword(), ConsoleColor.Blue);
ColoredItem<Bow> redBow = new ColoredItem<Bow>(new Bow(), ConsoleColor.Red);
ColoredItem<Axe> greenAxe = new ColoredItem<Axe>(new Axe(), ConsoleColor.Green);
blueSword.Display();
redBow.Display();
greenAxe.Display();

public class Sword { }
public class Bow { }
public class Axe { }

public class ColoredItem<T>
{
    private T _item;
    private ConsoleColor _color;
    
    public ColoredItem(T TItem, ConsoleColor color)
    {
        _item = TItem;
        _color = color;
    }

    public void Display()
    {
        Console.ForegroundColor = _color;
        Console.WriteLine(_item.ToString());
        Console.ForegroundColor = ConsoleColor.White;
    }
}