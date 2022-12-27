Console.Write("Number of estates: ");
int estates = Convert.ToInt32(Console.ReadLine());
Console.Write("Number of duchies: ");
int duchies = Convert.ToInt32(Console.ReadLine());
Console.Write("Number of provinces: ");
int provinces = Convert.ToInt32(Console.ReadLine());
int score = estates + 3 * duchies + 6 * provinces;
Console.WriteLine($"The total score is {score} points");
