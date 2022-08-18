using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace TO_DO_BOT
{
    public class UserRepository
    {

        private static string ConnectionString = "Host=localhost;Port=5432;Database=To-do-DB;Username=postgres;Password=root";

        public static async Task<bool> Register(string name, string password)
        {

            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                var existsSql = $"SELECT username FROM users WHERE username LIKE '%{name}%'";
                var query = conn.Query<string>(existsSql).FirstOrDefault();
                if (query != null)
                {
                    return false;
                }
                if (name != null && password != null)
                {
                    var sql = $"INSERT INTO users(username, password) values ('{name}', '{password}')";
                    conn.Query(sql);
                    return true;
                }

                return false;
            }
        }
        public static async Task<bool> Login(string name, string password)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                if (name != null && password != null)
                {
                    String sql = $"SELECT password FROM users WHERE username LIKE '%{name}%'";
                    var db_password = conn.Query<string>(sql).FirstOrDefault();
                    if(db_password == null)
                        return false;
                    
                    if(password == db_password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public static async Task AddTaskAsync(int userId, string task)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                var sql = $"INSERT INTO users_tasks (user_id, task) VALUES ({userId}, '{task}')";  
                await conn.QueryAsync(sql);
            }
        }
        public static async Task RemoveTaskAsync(int userId, string task)
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                var sql = $"DELETE FROM users_tasks WHERE user_id = {userId} AND task LIKE '%{task}%'";
                await conn.QueryAsync(sql);
            }
        }
        public static async Task<List<string>> GetAllTasksAsync(int userId)
        {
            List<string> allTasks = new();
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                var sql = $"SELECT task FROM users_tasks WHERE user_id = {userId}";
                List<string> tasks = (List<string>) await conn.QueryAsync<string>(sql);
                var ss = new List<string>();
                foreach (var task in tasks)
                {
                    allTasks.Add(task);
                }
                return allTasks;
            }
        }
        public static int GetUserId(string username)
        {
            using(var conn = new NpgsqlConnection(ConnectionString))
            {
                var sql = $"SELECT id FROM users WHERE username LIKE '%{username}%'";
                var userId = conn.Query<int>(sql).FirstOrDefault();
                return userId;
            }
        }

    }
}
