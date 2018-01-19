
using System;
using System.IO;
using Microsoft.Data.Sqlite;

public class BaseRepository {
    public static string DbFile => Path.Combine(Environment.CurrentDirectory, "SimpleDb.sqlite");
    public static SqliteConnection Connection() {
        return new SqliteConnection($"Data Source={DbFile}");
    }
}