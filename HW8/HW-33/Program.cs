namespace HW_33
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var shop = new Shop();
            var customer = new Customer();
            customer.Subscribe(shop);
            int b = 1;
            while (true)
            {
                Console.WriteLine("A - новый товар, D - удалить товар по Id, X - выход");
                var a = Console.ReadKey();
                if (a.KeyChar.Equals('X'))
                {
                    break;
                }
                if (a.KeyChar.Equals('A'))
                {
                    Console.WriteLine();
                    shop.Add(new Item { Id = shop.Items.Count , Name = $"Товар от {DateTime.Now}" });

                    b++;
                }
                if (a.KeyChar.Equals('D'))
                {
                    Console.WriteLine("Введите id товара, который хотите удалить: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine();
                    shop.Remove(shop.Items[id]);
                }
            }
        }
    }
}