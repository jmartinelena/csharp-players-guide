Console.WriteLine(Add(1, 2));
Console.WriteLine(Add(2.0, 2.0));
Console.WriteLine(Add("a", "bc"));
Console.WriteLine(Add(DateTime.Now, new TimeSpan(0, 10, 10)));

dynamic Add(dynamic a, dynamic b) => a + b;