Sword sword1 = new Sword(Material.Iron, Gemstone.None, 90, 20);
Sword sword2 = sword1 with {Length = 100, CrossguardWidth = 22.5f};
Sword sword3 = sword1 with { Material = Material.Steel, Gemstone = Gemstone.Sapphire };
Sword[] swords = new Sword[] { sword1, sword2, sword3 };
foreach (Sword sword in swords)
{
    Console.WriteLine(sword);
}

public enum Material { Wood, Bronze, Iron, Steel, Binarium}
public enum Gemstone { Emerald, Amber, Sapphire, Diamond, Bitstone, None}

public record Sword (Material Material, Gemstone Gemstone, float Length, float CrossguardWidth);