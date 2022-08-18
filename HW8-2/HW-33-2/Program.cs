using System.Collections.Concurrent;

namespace HW_33_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            ConcurrentDictionary<string, int> a = new ConcurrentDictionary<string, int>();
            int value = 1;
            while (true)
            {
                
                    Task.Run(() =>
                    {
                        while (true)
                        {
                            
                            foreach(var item in a.Keys)
                            {
                                a[item] += 1;
                                if (a[item] >= 100)
                                {
                                    a.TryRemove(item, out value);
                                }
                            }

                            Task.Delay(1000).Wait();
                        }
                    });

                Console.WriteLine("1 - добавить книгу, 2 - вывести список непрочитанного, 3 - выйти");
                var b = Convert.ToInt32(Console.ReadLine());
                if(b == 1)
                {
                    Console.WriteLine("Введите название книги:");
                    var bookName = Console.ReadLine();
                    var c = a.TryAdd(bookName, 0);
                    if (!c)
                    {
                        Console.WriteLine("Книга с таким названием уже есть в списке");
                    }
                }
                if(b == 2)
                {
                    Console.WriteLine();
                    foreach(var c in a)
                    {
                        Console.Write($"{c.Key} - {c.Value}%, ");
                    }
                }
                if(b == 3)
                {
                    break;
                }
            }
        }
    }
}