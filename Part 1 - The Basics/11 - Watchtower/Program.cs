Console.Write("Input the value of the x coordinate: ");
int x = Convert.ToInt32(Console.ReadLine());
Console.Write("Input the value of the y coordinate: ");
int y = Convert.ToInt32(Console.ReadLine());

string enemyPosition;

if (x < 0)
{
    if (y > 0) { enemyPosition = "to the NW"; }
    else if (y == 0) { enemyPosition = "to the W"; }
    else { enemyPosition = "to the SW"; }
} else if ( x == 0)
{
    if (y > 0) { enemyPosition = "to the N"; }
    else if (y == 0) { enemyPosition = "here"; }
    else { enemyPosition = "to the S"; }
} else
{
    if (y > 0) { enemyPosition = "to the NE"; }
    else if (y == 0) { enemyPosition = "to the E"; }
    else { enemyPosition = "to the SE"; }
}

Console.WriteLine($"The enemy is {enemyPosition}!");