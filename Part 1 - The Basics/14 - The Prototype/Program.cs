Console.Write("User 1, enter a number between 0 and 100: ");
int num = Convert.ToInt32(Console.ReadLine());

int guess;
Console.Write("User 2, guess the number.");

do
{
    Console.Write("What is your next guess? ");
    guess = Convert.ToInt32(Console.ReadLine());
    if (guess > num) { Console.WriteLine($"{guess} is too high."); } else if (guess < num) { Console.WriteLine($"{guess} is too low."); };
} while (guess != num);
Console.WriteLine("You've guessed correctly!");