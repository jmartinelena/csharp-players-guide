int[] array = new int[] { 4, 51, -7, 13, -99, 15, -8, 45, 90 };
int currentSmallest = array[0]; // Start with the first element.
foreach (int val in array)
{
    if (val < currentSmallest)
        currentSmallest = val;
}
Console.WriteLine(currentSmallest);

int total = 0;
foreach (int val in array)
    total += val;
float average = (float)total / array.Length;
Console.WriteLine(average);