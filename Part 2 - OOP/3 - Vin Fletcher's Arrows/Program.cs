Arrow arrow = new Arrow(Arrowhead.Steel, 60.5f, Fletching.GooseFeathers);
Console.WriteLine(arrow.GetCost());

enum Arrowhead { Steel, Wood, Obsidian };
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers };

class Arrow
{
    public Arrowhead _arrowHead;
    public float _length;
    public Fletching _fletching;

    public Arrow(Arrowhead arrowHead, float length, Fletching fletching)
    {
        _length = (length >= 60 && length <= 100) ? length : 60; // 60 as default value if you are being funny and choose an invalid length
        _fletching = fletching;
        _arrowHead = arrowHead;
    }

    public float GetCost()
    {
        int arrowHeadCost = _arrowHead switch
        {
            Arrowhead.Steel => 10,
            Arrowhead.Wood => 3,
            Arrowhead.Obsidian => 5,
            _ => 0
        };

        float lengthCost = 0.05f * _length;

        int fletchingCost = _fletching switch
        {
            Fletching.Plastic => 10,
            Fletching.TurkeyFeathers => 5,
            Fletching.GooseFeathers => 3,
            _ => 0
        };

        return (arrowHeadCost + lengthCost + fletchingCost);
    }
}
