PotionType potion = PotionType.Water;

while (true)
{
    Console.WriteLine($"Your current potion is {potion}.");

    Console.Write("\nDo you want to add ingredients to it? yes/y or no/n: ");
    string? input = Console.ReadLine();

    if (input == "no" || input == "n" || input == null) break;

    Console.WriteLine("Available ingredients: stardust, snake venom, dragon breath, shadow glass, eyeshine gem");
    Console.Write("Which ingredient do you want to add? ");
    string ingredientInput = Console.ReadLine() ?? "none";

    Ingredient ingredient = ingredientInput.ToLower() switch
    {
        "stardust" => Ingredient.Stardust,
        "venom" or "snake venom" => Ingredient.Venom,
        "dragonbreath" or "dragon breath" => Ingredient.DragonBreath,
        "shadowglass" => Ingredient.ShadowGlass,
        "eyeshinegem" or "eyeshine gem" => Ingredient.EyeshineGem,
        "none" or _ => Ingredient.None
    };

    if (ingredient == Ingredient.None && potion != PotionType.Ruined)
    {
        Console.WriteLine("You either chose to be done with the potion, or typed an invalid answer.\n");
        break;
    }

    potion = (potion, ingredient) switch
    {
        (PotionType.Water, Ingredient.Stardust) => PotionType.Elixir,
        (PotionType.Elixir, Ingredient.Venom) => PotionType.Poison,
        (PotionType.Elixir, Ingredient.DragonBreath) => PotionType.Flying,
        (PotionType.Elixir, Ingredient.ShadowGlass) => PotionType.Invisibility,
        (PotionType.Elixir, Ingredient.EyeshineGem) => PotionType.NightSight,
        (PotionType.NightSight, Ingredient.ShadowGlass) => PotionType.CloudyBrew,
        (PotionType.Invisibility, Ingredient.EyeshineGem) => PotionType.CloudyBrew,
        (PotionType.CloudyBrew, Ingredient.Stardust) => PotionType.Wraith,
        (_, _) => PotionType.Ruined
    };

    if (potion == PotionType.Ruined)
    {
        Console.WriteLine("Your potion is ruined, you'll have to start over.\n");
        potion = PotionType.Water;
    }
}

Console.WriteLine($"Your final potion is: {potion}.\n\nPress any key to stop the program...");
Console.ReadKey(true);

public enum PotionType { Water, Elixir, Poison, Flying, Invisibility, NightSight, CloudyBrew, Wraith, Ruined }
public enum Ingredient { Stardust, Venom, DragonBreath, ShadowGlass, EyeshineGem, None }