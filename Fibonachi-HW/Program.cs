
using System.Diagnostics;

Stopwatch stopwatch = new Stopwatch();

int FibonachiRecursion(int n)
{
    if (n == 0 || n == 1) return n;

    return FibonachiRecursion(n - 1) + FibonachiRecursion(n - 2);

}

int FibonachiCycle(int n)
{
    if (n == 0 || n == 1) return 0;

    int FibFirst = 1;
    int FibSecond = 1;
    int sum = 0;

    int pos = 2;
    
    while (pos <= n)
    {
        sum = FibFirst + FibSecond;
        FibFirst = FibSecond;
        FibSecond = sum;
        pos++;
    }
    int result = FibFirst;
    return result;
}

stopwatch.Start();
int cn1 = FibonachiCycle(5);
stopwatch.Stop();
Console.WriteLine("Поиск 5го члена числа Фибоначчи через цикл занял: " + stopwatch.Elapsed);
stopwatch.Reset();

stopwatch.Start();
int cn2 = FibonachiCycle(10);
stopwatch.Stop();
Console.WriteLine("Поиск 10го члена числа Фибоначчи через цикл занял: " + stopwatch.Elapsed);
stopwatch.Reset();

stopwatch.Start();
int cn3 = FibonachiCycle(20);
stopwatch.Stop();
Console.WriteLine("Поиск 20го члена числа Фибоначчи через цикл занял: " + stopwatch.Elapsed);
stopwatch.Reset();

Console.WriteLine();

stopwatch.Start();
int rn1 = FibonachiRecursion(5);
stopwatch.Stop();
Console.WriteLine("Поиск 5го члена числа Фибоначчи через рекурсию занял: " + stopwatch.Elapsed);
stopwatch.Reset();

stopwatch.Start();
int rn2 = FibonachiRecursion(10);
stopwatch.Stop();
Console.WriteLine("Поиск 10го члена числа Фибоначчи через рекурсию занял: " + stopwatch.Elapsed);
stopwatch.Reset();

stopwatch.Start();
int rn3 = FibonachiRecursion(20);
stopwatch.Stop();
Console.WriteLine("Поиск 20го члена числа Фибоначчи через рекурсию занял: " + stopwatch.Elapsed);
stopwatch.Reset();

