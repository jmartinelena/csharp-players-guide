Console.WriteLine("The following items are available: ");
Console.WriteLine("1 – Rope\r\n2 – Torches\r\n3 – Climbing Equipment\r\n4 – Clean Water\r\n5 – Machete\r\n6 – Canoe\r\n7 – Food Supplies");
Console.Write("What number do you want to see the price of? ");
int choice = Convert.ToInt32(Console.ReadLine());

int price;

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

if (price != -1)
{
    Console.WriteLine($"That item costs {price} gold.");
} else
{
    Console.WriteLine("Woops, I don't know that one.");
}

/* Alternative way of doing the same thing
switch (choice)
{
    case 4:
    case 7:
        price = 1;
        break;
    case 1:
        price = 10;
        break;
    case 2:
        price = 15;
        break;
    case 3:
        price = 25;
        break;
    case 5:
        price = 20;
        break;
    case 6:
        price = 200;
        break;
    default:
        price = -1;
        break;
}
*/