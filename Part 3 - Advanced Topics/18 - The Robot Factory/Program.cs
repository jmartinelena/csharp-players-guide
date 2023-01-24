using System.Dynamic;

int count = 1;

while (true)
{
    Console.WriteLine($"You are creating robot #{count}.");
    dynamic robot = new ExpandoObject();
    robot.ID = count;
    count++;

    // I don't like this method of getting the properties for the robot because it is too repetitive.
    // I tried making a method with the robot's desired property as a parameter, and then assign a value to it
    // within the method, but I couldn't get it to work.
    // Reference: https://stackoverflow.com/questions/62401329/dynamic-properties-passed-as-c-sharp-method-parameters
    //            https://stackoverflow.com/questions/11178864/pass-property-itself-to-function-as-parameter-in-c-sharp
    Console.Write("Do you want to name the robot? ");
    if (Console.ReadLine() != "no")
    {
        while (true)
        {
            Console.Write("What is it's name? ");
            string? name = Console.ReadLine();
            
            if (name != null)
            {
                robot.Name = name;
                break;
            }
            else
            {
                Console.WriteLine("Invalid name, try again.");
            }
        }
    }

    Console.Write("Does this robot have a specific size? ");
    if (Console.ReadLine() != "no")
    {
        while (true)
        {
            Console.Write("What is it's height? ");
            string? height = Console.ReadLine();

            if (int.TryParse(height, out int parsedHeight) && parsedHeight > 0)
            {
                robot.Height = parsedHeight;
                break;
            }
            else
            {
                Console.WriteLine("Invalid height, try again.");
            }
        }

        while (true)
        {
            Console.Write("What is it's width? ");
            string? width = Console.ReadLine();

            if (int.TryParse(width, out int parsedWidth) && parsedWidth > 0)
            {
                robot.Width = parsedWidth;
                break;
            }
            else
            {
                Console.WriteLine("Invalid width, try again.");
            }
        }
    }

    Console.Write("Does this robot need to be a specific color? ");
    if (Console.ReadLine() != "no")
    {
        while (true)
        {
            Console.Write("What is it's color? ");
            string? color = Console.ReadLine();

            if (color != null)
            {
                robot.Color = color;
                break;
            }
            else
            {
                Console.WriteLine("Invalid name, try again.");
            }
        }
    }

    foreach (KeyValuePair<string, object> property in (IDictionary<string, object>)robot)
    {
        Console.WriteLine($"{property.Key}: {property.Value}");
    }
}