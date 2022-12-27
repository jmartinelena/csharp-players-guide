State currentState = State.Closed;

while (true)
{
    Console.Write($"The chest is currenyl {currentState}. What do you want to todo? ");
    string response = Console.ReadLine().ToLower();

    if (response == "unlock" && currentState == State.Locked) { currentState = State.Closed; };
    if (response == "open" && currentState == State.Closed) { currentState = State.Open; };
    if (response == "lock" && currentState == State.Closed) { currentState = State.Locked; };
    if (response == "close" && currentState == State.Open) { currentState = State.Closed; };
}

enum State {Locked, Closed, Open };


