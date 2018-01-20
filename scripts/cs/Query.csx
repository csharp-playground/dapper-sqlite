#load "Config.csx"

using MySql.Data.MySqlClient;
using Dapper;
using System.Linq;
using static System.Console;

var connnection = new MySqlConnection(connectionString);

class Product {
    public int Id { set; get; }
    public string ProductName { set; get; }
}

void query() {
    var sql = @"
        SELECT 
            product_name as ProductName,   
            id as Id
        FROM products
        LIMIT @Limit
    ";

    var results = connnection.Query<Product>(sql, new { Limit = 10 });
    var list = results.AsList();

    WriteLine(list[0].ProductName);
    WriteLine(list[0].Id);
    WriteLine(list.Count);
}

void tuple() {
    var sql = @"
        SELECT 
            product_name as ProductName,   
            id as Id
        FROM products
    ";
    var results = connnection.Query<(string Name, int Id)>(sql);
    var list = results.AsList();
    WriteLine(list.Count);
    WriteLine(list[0].Name);
}

tuple();

