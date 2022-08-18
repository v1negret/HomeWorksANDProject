
using Dapper;
using Npgsql;
using System.Data.SqlClient;

namespace LastHW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = DbContext.GetCustomerById(1);
            Console.WriteLine(a.FirstName + " " + a.LastName);
        }
    }
    public class DbContext
    {
        private static readonly string _connectionString = "Host=localhost;Port=5432;Database=shop;Username=postgres;Password=root";

        public static List<Customer> GetAllCustomers()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                return (List<Customer>) conn.Query<Customer>("SELECT * FROM customers");
            }
        }
        public void AddCustomer(Customer customer)
        {
            using (var conn = new NpgsqlConnection(_connectionString)) 
            {
                conn.Query($"INSERT INTO customers (firstname, lastname, age) VALUES ('@FirstName', '@LastName', @Age)",
                    new {FirstName = customer.FirstName,
                         LastName = customer.LastName,
                         Age = customer.Age});
            }
        }
        public static Customer GetCustomerById(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                return conn.Query<Customer>($@"SELECT * FROM customers WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public static List<Product> GetAllProducts()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                return (List<Product>)conn.Query<Product>("SELECT * FROM products");
            }
        }

        public void AddProduct(Product product)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Query($@"INSERT INTO products (name, description, stockquantity, price) VALUES ('@Name', '@Description', @StockQuantity, @Price)",
                    new
                    {
                        Name = product.Name,
                        Description = product.Description,
                        StockQuantity = product.StockQuantit,
                        Price = product.Price
                    });
            }
        }

        public static Customer GetProductById(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                return conn.Query<Customer>($@"SELECT * FROM products WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public static List<Order> GetAllOrders()
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                return (List<Order>) conn.Query<Order>("SELECT * FROM orders");
            }
        }
        public void AddProduct(Order order)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                conn.Query($@"INSERT INTO orders (customerid, productid, quantity) VALUES (@CustomerId, @ProductId, @Quantity)",
                    new
                    {
                        CustomerId = order.CutsomerId,
                        ProductId = order.ProductId,
                        Quantity = order.Quantity
                    });
            }
        }
        public static Customer GetOrderById(int id)
        {
            using (var conn = new NpgsqlConnection(_connectionString))
            {
                return conn.Query<Customer>($@"SELECT * FROM orders WHERE id = @Id", new { Id = id }).FirstOrDefault();
            }
        }
    }
}