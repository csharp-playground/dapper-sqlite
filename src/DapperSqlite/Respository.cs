using System.IO;
using Dapper;
using System.Linq;
using System.Collections.Generic;

public class Respository {
    public List<dynamic> Query(string sql) {
        using (var conn = BaseRepository.Connection()) {
            conn.Open();
            var rs = conn.Query<dynamic>(sql).ToList();
            return rs;
        }
    }

    public List<Customer> GetCustomers() {
        using (var conn = BaseRepository.Connection()) {
            conn.Open();
            var rs = conn.Query<Customer>("SELECT * FROM Customer").ToList();
            return rs;
        }
    }

    public int SaveCustomers(Customer customer) {
        if (!File.Exists(BaseRepository.DbFile)) {
            File.WriteAllText(BaseRepository.DbFile, "");
            CreateDatabase();
        }

        using (var conn = BaseRepository.Connection()) {
            conn.Open();
            var id =
                conn.Query<int>(
                    $"INSERT INTO Customer (FirstName, LastName, DateOfBirth) VALUES(@FirstName, @LastName, @DateOfBirth); SELECT last_insert_rowid();",
                    customer).First();
            return id;
        }
    }

    private void CreateDatabase() {
        using (var conn = BaseRepository.Connection()) {
            conn.Open();
            conn.Execute(@"
                    create table Customer
                    (
                        Id          integer primary key AUTOINCREMENT,
                        FirstName   text not null,
                        LastName    text not null,
                        DateOfBirth DateTime not null
                    )
                ");
        }
    }
}