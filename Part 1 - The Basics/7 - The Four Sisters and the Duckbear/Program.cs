Console.Write("Amount of eggs gathered today: ");
int eggsGathered = Convert.ToInt32(Console.ReadLine());
int eggsPerSister = eggsGathered / 4; // int division
int eggsLeftOver = eggsGathered % 4;
Console.WriteLine($"Each sister gets {eggsPerSister} eggs and the Duckbear gets {eggsLeftOver}");
