Console.Write("triangle base size: ");
float triangleBase = Convert.ToSingle(Console.ReadLine());
Console.Write("triangle height size: ");
float triangleHeight = float.Parse(Console.ReadLine());
float area = triangleBase * triangleHeight / 2;
Console.WriteLine($"The triangle area is {area}");
