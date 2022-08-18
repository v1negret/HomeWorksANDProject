using System.Collections;
using System.Text.Json;

namespace HW_35
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var list = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            var bs = list.Top(30);

            Console.WriteLine(JsonSerializer.Serialize(bs));

           
        }
    }
}