#! "netcoreapp2.0"
#r "nuget: Dapper, 1.50.4"
#r "nuget: MySql.Data, 8.0.9-dmr"
#r "nuget: System.ValueTuple, 4.4.0"

using MySql.Data;
using Dapper;
using MySql.Data.MySqlClient;

var connectionString = "Server=localhost;Database=northwind;Uid=root;Password=1234;Allow User Variables=True;";