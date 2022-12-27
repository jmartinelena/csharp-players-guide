Countdown(10);

void Countdown(int num)
{
    if (num == 1) { Console.WriteLine(1); return; };
    Console.WriteLine(num);
    Countdown(num - 1);
};
