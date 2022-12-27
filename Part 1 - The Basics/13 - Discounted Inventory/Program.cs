Console.WriteLine("The following items are available: ");
Console.WriteLine("1 – Rope\r\n2 – Torches\r\n3 – Climbing Equipment\r\n4 – Clean Water\r\n5 – Machete\r\n6 – Canoe\r\n7 – Food Supplies");
Console.Write("What number do you want to see the price of? ");
int choice = Convert.ToInt32(Console.ReadLine());

double price;

price = choice switch
{
    1 => 10,
    2 => 15,
    3 => 25,
    4 => 1,
    5 => 20,
    6 => 200,
    7 => 1,
    _ => -1,
};

Console.Write("What is your name? ");
string name = Console.ReadLine();

price = name == "Chicho" ? price * 0.5 : price;

if (price != -1)
{
    Console.WriteLine($"That item costs {price} gold.");
}
else
{
    Console.WriteLine("Woops, I don't know that one.");
}