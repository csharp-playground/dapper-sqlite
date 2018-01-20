#r "../../packages/Rezoom/lib/net45/Rezoom.dll"
#r "../../packages/Rezoom.SQL.Provider/lib/net45/Rezoom.SQL.Provider.dll"
#r "../../packages/Rezoom.SQL.Provider/lib/net45/Rezoom.SQL.Compiler.dll"
#r "../../packages/Rezoom.SQL.Provider/lib/net45/Rezoom.SQL.Mapping.dll"

open Rezoom.SQL

type Product = SQL<"""
    select * from products
""">

use context = new ConnectionContext()

let connectionString = "Server=localhost;Database=northwind;Uid=root;Password=1234;Allow User Variables=True;";

