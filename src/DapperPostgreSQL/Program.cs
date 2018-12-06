using System;
using DapperPostgreSQL.Df;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using Dapper;
using System.Text;

namespace DapperPostgreSQL {
    class Program {
        static string connectionString = "Host=localhost;User Id=postgres;Password=1234;Database=Dapper";
        static void CreateDb() {
            var builder = new DbContextOptionsBuilder();
            builder.UseNpgsql(connectionString);

            var context = new MyContext(builder.Options);
            // context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        static void Insert() {
            var connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var sql = @"insert into public.""Students""(""Picture"") values(@Picture)";

            connection.Execute(sql, new {
                Picture = UTF8Encoding.UTF8.GetBytes("Hello, world!")
            });
            connection.Close();
        }

        static void Main(string[] args) {
            CreateDb();
            Insert();
        }
    }
}
