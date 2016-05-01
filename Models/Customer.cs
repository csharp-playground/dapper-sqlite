
using System;
using System.IO;
using System.Data.SQLite;
using Dapper;
using System.Data;
using MySql.Data.MySqlClient;
using System.Linq;

namespace Models {

    public class Customer {
        public int Id { set;get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public DateTime DateOfBirth { set; get; }
    }

    public class BaseRepository
    {
        public static string DbFile => Path.Combine(Environment.CurrentDirectory, "SimpleDb.sqlite");
        public static IDbConnection Connection()
        {
            //return new SQLiteConnection($"Data Source={DbFile}");
            return new MySqlConnection($"Data Source=localhost; User Id=root;Password=1234;Database=DapperMySql");
        }
    }

    public class Respository {
        public void SaveCustomers(Customer customer) {
            if(!File.Exists(BaseRepository.DbFile)) {
                File.WriteAllText(BaseRepository.DbFile, "");
                CreateDatabase();
            }

            using(var conn = BaseRepository.Connection()) {
                conn.Open();
                customer.Id =
                    conn.Query<int>(
                        $"INSERT INTO Customer (FirstName, LastName, DateOfBirth) VALUES(@FirstName, @LastName, @DateOfBirth); SELECT LAST_INSERT_ID();",
                        customer).First();
            }
        }

        private void CreateDatabase() {
            using(var conn = BaseRepository.Connection()){
                conn.Open();
                conn.Execute(@"
                    create table Customer
                    (
                        ID          integer primary key AUTO_INCREMENT,
                        FirstName   varchar(100) not null,
                        LastName    varchar(100) not null,
                        DateOfBirth DateTime not null
                    )
                ");
            }
        }
    }
}