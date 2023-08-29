using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

class Program
{
    private static int _catsAmmount;
    private static int _capacityOfTheBowl;
    private static int _foodPerCat;
    private static int _maxCatsAtBowl;

    private static Semaphore _semaphore;
    private static int _bowlFoodAmmount;

    private static Stopwatch _stopwatch = new Stopwatch();
    static object lock1 = new object();

    static void Main()
    {
        Console.Write("Введите количество котиков: ");
        while (!int.TryParse(Console.ReadLine(), out _catsAmmount) || _catsAmmount <= 0)
        {
            Console.Write("Некорректное значение. Введите положительное целое число: ");
        }

        Console.Write("Введите вместительность миски: ");
        while (!int.TryParse(Console.ReadLine(), out _capacityOfTheBowl) || _capacityOfTheBowl <= 0)
        {
            Console.Write("Некорректное значение. Введите положительное целое число: ");
        }

        Console.Write("Введите количество корма, который съедает котик: ");
        while (!int.TryParse(Console.ReadLine(), out _foodPerCat) || _foodPerCat <= 0 || _foodPerCat > _capacityOfTheBowl)
        {
            Console.Write($"Некорректное значение. Введите положительное целое число не больше {_capacityOfTheBowl}: ");
        }

        Console.Write("Введите максимальное количество котиков, которые могут подойти к миске: ");
        while (!int.TryParse(Console.ReadLine(), out _maxCatsAtBowl) || _maxCatsAtBowl <= 0)
        {
            Console.Write($"Некорректное значение. Введите положительное целое число: ");
        }

        _semaphore = new Semaphore(_maxCatsAtBowl, _maxCatsAtBowl);
        _bowlFoodAmmount = _capacityOfTheBowl;

        _stopwatch.Start();

        Console.WriteLine("Бабушка начинает кормить котиков. \n");

        for (int i = 0; i < _catsAmmount; i++)
        {
            int j = i;
            Task.Run(() => Eat(j));
        }

        Console.ReadLine();
    }

    static void Eat(int i)
    {
        _semaphore.WaitOne();
        while (true)
        {
            if (_bowlFoodAmmount >= _foodPerCat)
            {

                Console.WriteLine($"Кот #{i + 1} подошел к миске и начал кушать.");
                Thread.Sleep(3000);
                lock (lock1)
                {
                    _bowlFoodAmmount -= _foodPerCat;
                    Console.WriteLine($"Кот #{i + 1} наелся и отошел от миски.");


                    if (_bowlFoodAmmount < _foodPerCat)
                    {
                        Console.WriteLine("Бабушка пополняет миску. Котики должны подождать.");
                        _bowlFoodAmmount = _capacityOfTheBowl;
                        Thread.Sleep(1000);
                        Console.WriteLine("Миска пополнена.");
                    }
                }

                _semaphore.Release();

                if (Interlocked.Decrement(ref _catsAmmount) == 0)
                {
                    _stopwatch.Stop();
                    Console.WriteLine($"Все котики накормлены за {_stopwatch.Elapsed.TotalSeconds} с.");
                }

                break;
            }
        }
        
    }
}