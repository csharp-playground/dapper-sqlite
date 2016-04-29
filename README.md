
## สร้างโปรเจคด้วย .NET CLI

```
dotnet new
dotnet restore
dotnet run
```

## แก้ไข project.json

```json
{
  "version": "1.0.0-*",
  "compilationOptions": {
    "emitEntryPoint": true
  },
  "dependencies": {
    "Dapper": "1.42.0",
    "System.Data.SQLite": "1.0.101",
    "System.Data.SQLite.Cor": "1.0.101",
    "xunit.runner.dnx": "2.1.0-*",
    "xunit": "2.1.0"
  },
  "testRunner": "xunit",
  "commands": {
      "test": "xunit.runner.dnx"
  },
  "frameworks": {
    "dnx451": {}
  }
}
```

## ทดสอบ

```
dnx test
```

## Issue

- System.DllNotFoundException : SQLite.Interop.dll

## ลิงค์

- http://blog.maskalik.com/asp-net/sqlite-simple-database-with-dapper