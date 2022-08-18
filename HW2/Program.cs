using System;
using System.Collections;
using System.Diagnostics;
/*
/Чтобы приступить к следующему этапу жмем любую клавишу
*/



namespace HW2;

class Program{
    static void Main(string[] args){
        List<int> list = new List<int>();
        ArrayList arrayList = new ArrayList();
        LinkedList<int> linkedList = new LinkedList<int>();

        //Измерение скорости заполнения коллекций
        Stopwatch stopwatch = new Stopwatch();

        stopwatch.Start();
        for(int i = 0; i <= 1_000_000; ++i){
            list.Add(i);
        }
        stopwatch.Stop();

        Console.WriteLine($"Коллеция List заполнялась {stopwatch.ElapsedMilliseconds} миллисекунд");
        
        stopwatch.Start();
        for(int i = 0; i <= 1_000_000; ++i){
            arrayList.Add(i);
        }
        stopwatch.Stop();

        Console.WriteLine($"Коллекция ArrayList заполнялась {stopwatch.ElapsedMilliseconds} миллисекунд");

        stopwatch.Start();
        for(int i = 0; i <= 1_000_000; ++i){
            linkedList.AddLast(i);
        }
        stopwatch.Stop();
        Console.WriteLine($"Коллекция LinkedList заполнялась {stopwatch.ElapsedMilliseconds} миллисекунд");

        Console.WriteLine();
        Console.ReadKey();

        //поиск 496753-го элемента коллекций

        stopwatch.Start();
        for(int i = 0; i < list.Count; ++i){
            if (list[i] == 496752){
                Console.WriteLine($"496753-й элемент коллекции List - {list[i]}");
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Был найден за {stopwatch.ElapsedMilliseconds}");


        Console.WriteLine();

        stopwatch.Start();
        for(int i = 0; i < arrayList.Count; ++i){
            if (list[i] == 496752){
                Console.WriteLine($"496753-й элемент коллекции ArrayList - {list[i]}");
            }
        }
        stopwatch.Stop();
        Console.WriteLine($"Был найден за {stopwatch.ElapsedMilliseconds}");

        Console.WriteLine();

        stopwatch.Start();
        for(int i = 0; i < linkedList.Count; ++i){
            if (list[i] == 496752){
                Console.WriteLine($"496753-й элемент коллекции LinkedList - {list[i]}");
            }                
        }
        stopwatch.Stop();
        Console.WriteLine($"Был найден за {stopwatch.ElapsedMilliseconds}");

        Console.WriteLine();
        Console.ReadKey();
        
        //Поиск в коллекциях чисел, делящихся на 777 без остатка
        Console.WriteLine("Числа, делящиеся на 777 без остатка в разных коллекциях");
        stopwatch.Start();
        foreach(int j in list){
            if(j % 777 == 0){
                Console.Write(j + ", ");
            }
        }
        stopwatch.Stop();
        Console.WriteLine();
        Console.WriteLine($"Нашлось в List за {stopwatch.ElapsedMilliseconds}");

        stopwatch.Start();
        foreach(int j in arrayList){
            if(j % 777 == 0){
                Console.Write(j + ", ");
            }
        }
        stopwatch.Stop();
        Console.WriteLine();
        Console.WriteLine($"Нашлось в ArrayList за {stopwatch.ElapsedMilliseconds}");

        stopwatch.Start();
        foreach(int j in linkedList){
            if(j % 777 == 0){
                Console.Write(j + ", ");
            }
        }
        Console.WriteLine();
        stopwatch.Stop();
        Console.WriteLine($"Нашлось в LinkedList за {stopwatch.ElapsedMilliseconds}");

        Console.ReadKey();
    }
    
}
