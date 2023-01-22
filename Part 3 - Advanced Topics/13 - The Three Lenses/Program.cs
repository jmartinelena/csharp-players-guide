int[] numbers = new int[] { 1, 9, 2, 8, 3, 7, 4, 6, 5 };

PrintResults(Procedural(numbers));
PrintResults(QuerySyntax(numbers));
PrintResults(MethodSyntax(numbers));

IEnumerable<int> Procedural(int[] array)
{
    List<int> filtered = new List<int>();

    foreach (int num in array)
    {
        if (num % 2 == 0)
        {
            filtered.Add(num);
        }
    }

    // Sorting the array with the Array.Sort() static method
    int[] filteredArray = filtered.ToArray();
    Array.Sort(filteredArray);

    for (int i = 0; i < filteredArray.Length; i++)
    {
        filteredArray[i] *= 2;
    }

    return filteredArray;
}

IEnumerable<int> QuerySyntax(int[] array)
{
    IEnumerable<int> filtered = from a in array
                                where a % 2 == 0
                                orderby a
                                select 2 * a;

    return filtered;
}

IEnumerable<int> MethodSyntax(int[] array)
{
    IEnumerable<int> filtered = array.Where(a => a % 2 == 0).OrderBy(a => a).Select(a => 2 * a);

    return filtered;
}

void PrintResults(IEnumerable<int> results)
{
    foreach (var result in results)
    {
        Console.Write($"{result} ");
    }
    Console.WriteLine();
}