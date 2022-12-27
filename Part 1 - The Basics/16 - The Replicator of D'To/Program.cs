int[] original = new int[5];

for (int i=0; i<original.Length;i++)
{
    Console.Write("Input a number: ");
    original[i] = Convert.ToInt32(Console.ReadLine());
}

int[] copy = new int[5];

for (int i=0; i<copy.Length; i++)
{
    copy[i] = original[i];
}

string ori = "Original: ";
string copied = "Copied: ";

for (int i=0; i < original.Length; i++)
{
    ori += original[i] + " ";
    copied += copy[i] + " ";
}
Console.WriteLine($"{ori}\n{copied}");