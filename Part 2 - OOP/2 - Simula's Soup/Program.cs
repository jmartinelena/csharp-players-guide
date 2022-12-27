(Recipe, Ingredient, Seasoning) soup = (Recipe.Soup, Ingredient.Chicken, Seasoning.Sweet);

Console.WriteLine("Available recipes: ");
for (int i=0; i<3; i++)
{
    Console.Write($"\t{i} - {(Recipe)i}");
}
Console.Write("\nChoose the corresponding number of the recipe you want: ");
int recipe = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Available ingredients: ");
for (int i = 0; i < 4; i++)
{
    Console.Write($"\t{i} - {(Ingredient)i}");
}
Console.Write("\nChoose the corresponding number of the ingredient you want: ");
int ingredient = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Available seasonings: ");
for (int i = 0; i < 3; i++)
{
    Console.Write($"\t{i} - {(Seasoning)i}");
}
Console.Write("\nChoose the corresponding number of the seasoning you want: ");
int seasoning = Convert.ToInt32(Console.ReadLine());

(Recipe, Ingredient, Seasoning) chosenMeal = ((Recipe)recipe, (Ingredient)ingredient, (Seasoning)seasoning);
Console.WriteLine($"\nMeal chosen: {chosenMeal.Item3} {chosenMeal.Item2} {chosenMeal.Item1}");

enum Recipe { Soup, Stew, Gumbo};
enum Ingredient { Mushrooms, Chicken, Carrots, Potatoes};
enum Seasoning { Spicy, Salty, Sweet};