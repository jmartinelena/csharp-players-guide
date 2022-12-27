Color color1 = new Color(100, 100, 100);
Color color2 = Color.Red;
Console.WriteLine($"R: {color1.RedChannel} G: {color1.GreenChannel} B: {color1.BlueChannel}");
Console.WriteLine($"R: {color2.RedChannel} G: {color2.GreenChannel} B: {color2.BlueChannel}");

class Color
{
    public int RedChannel { get; init; }
    public int GreenChannel { get; init; }
    public int BlueChannel { get; init; }

    public Color(int red, int green, int blue)
    {
        RedChannel = Math.Clamp(red,0,255);
        GreenChannel = Math.Clamp(green, 0, 255);
        BlueChannel = Math.Clamp(blue, 0, 255);
    }

    public static Color White { get => new Color(255, 255, 255); }
    public static Color Black { get => new Color(0, 0, 0); }
    public static Color Red { get => new Color(255, 0, 0); }
    public static Color Orange { get => new Color(255, 165, 0); }
    public static Color Yellow { get => new Color(255, 255, 0); }
    public static Color Green { get => new Color(0, 128, 0); }
    public static Color Blue { get => new Color(0, 0, 255); }
    public static Color Purple { get => new Color(128, 0, 128); }
}