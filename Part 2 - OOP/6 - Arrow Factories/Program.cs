Arrow arrow = new Arrow(Arrowhead.Steel, 60.5f, Fletching.GooseFeathers);
Console.WriteLine(arrow.GetCost());
Arrow eliteArrow = Arrow.CreateEliteArrow(ArrowType.Elite);
Console.WriteLine(eliteArrow.GetCost());

enum Arrowhead { Steel, Wood, Obsidian };
enum Fletching { Plastic, TurkeyFeathers, GooseFeathers };
enum ArrowType { Elite, Beginner, Marksman}

class Arrow
{
    private Arrowhead _arrowHead;
    private float _length;
    private Fletching _fletching;

    public Arrow(Arrowhead arrowHead, float length, Fletching fletching)
    {
        _length = (length >= 60 && length <= 100) ? length : 60; // 60 as default value if you are being funny and choose an invalid length
        _fletching = fletching;
        _arrowHead = arrowHead;
    }

    public Arrowhead Arrowhead { get { return _arrowHead; } set { _arrowHead = value; } }
    public float Length { get { return _length; } set { _length = value; } }
    public Fletching Fletching { get { return _fletching; } set { _fletching = value; } }

    public static Arrow CreateEliteArrow(ArrowType arrowType)
    {
        if (arrowType == ArrowType.Elite)
        {
            return new Arrow(Arrowhead.Steel,95,Fletching.Plastic);
        } else if (arrowType == ArrowType.Beginner)
        {
            return new Arrow(Arrowhead.Wood,75,Fletching.GooseFeathers);
        } else
        {
            return new Arrow(Arrowhead.Steel,65,Fletching.GooseFeathers);
        }
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