#r "../packages/System.Configuration/System.configuration.dll"
open System.Windows.Forms
// #r "../packages/NETStandard.Library/build/netstandard2.0/ref/netstandard.dll"
#r "../packages/NETStandard.Library/build/netstandard2.0/ref/System.Transactions.dll"
#r "../packages/MySql.Data/lib/net452/MySql.Data.dll"

open MySql.Data.MySqlClient
open System.IO

let connectionString = "Server=localhost;Database=DotNetDapper;Uid=root;Password=1234;Allow User Variables=True;"
let sql = File.ReadAllText "resource/Northwind.MySql.Create.sql"

let connection = new MySqlConnection(connectionString)
connection.Open()

let create () =
    let command = new MySqlCommand(sql)
    command.Connection <- connection
    command.ExecuteNonQuery() |> ignore

create()
connection.Close()