#r "../../packages/MySql.Data/lib/net452/MySql.Data.dll"
#r "../../packages/SQLProvider/lib/net451/FSharp.Data.SqlProvider.dll"
#I "../../packages/MySql.Data/lib/net452"


open FSharp.Data.Sql.Common

open FSharp.Data.Sql

let [<Literal>] ConnectionString = "Server=localhost;Database=northwind;Uid=root;Password=1234;Allow User Variables=True;";

type Sql = SqlDataProvider<
                ConnectionString = ConnectionString,
                DatabaseVendor = Common.DatabaseProviderTypes.MYSQL >

let ctx = Sql.GetDataContext()

let products = 
    query { 
        for p in ctx.Northwind.Products do
        where (p.ProductName.Contains("Spread"))
        select (p.ProductCode, p.ProductName)
    } |> Seq.toArray

printfn "%A" products


