RecentNumbers recentNums = new RecentNumbers();

NumberWriter numWriter = new NumberWriter(recentNums);
Thread thread1 = new Thread(numWriter.GenerateNumbers);
thread1.Start();

NumberReader numReader = new NumberReader(recentNums);
Thread thread2 = new Thread(numReader.CheckNumbers);
thread2.Start();

class RecentNumbers
{
    private readonly object _lock = new object();
    private int _recentNumber1;
    private int _recentNumber2;

    public int RecentNumber1
    {
        get
        {
            lock (_lock)
            {
                return _recentNumber1;
            }
        }
        set
        {
            lock (_lock)
            {
                _recentNumber1 = value;
            }
        }
    }
    public int RecentNumber2
    {
        get
        {
            lock (_lock)
            {
                return _recentNumber2;
            }
        }
        set
        {
            lock (_lock)
            {
                _recentNumber2 = value;
            }
        }
    }
}

class NumberWriter
{
    private RecentNumbers _rn;
    private Random _random;
    
    public NumberWriter(RecentNumbers rn)
    {
        _rn = rn;
        _random = new Random();
    }

    public void GenerateNumbers()
    {
        while (true)
        {
            int num1 = _random.Next(0, 9);
            Console.WriteLine($"Number 1: {num1}");
            _rn.RecentNumber1 = num1;
            Thread.Sleep(1000);
            int num2 = _random.Next(0, 9);
            Console.WriteLine($"Number 2: {num2}");
            _rn.RecentNumber2 = num2;
            Thread.Sleep(1000);
        }
    }
}

class NumberReader
{
    private RecentNumbers _rn;
    public NumberReader(RecentNumbers rn)
    {
        _rn = rn;
    }

    public void CheckNumbers()
    {
        while (true)
        {
            Console.Write("\nPress any key when you think both numbers are the same: \n");
            Console.ReadKey();
            if (_rn.RecentNumber1 != _rn.RecentNumber2)
            {
                Console.WriteLine("Guessed incorrectly, the numbers are not equal");
            }
            else
            {
                Console.WriteLine("Guessed correctly, both numbers are the same");
            }
        }
    }
}