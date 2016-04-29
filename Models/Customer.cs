
using System;
using System.IO;
using System.Data.SQLite;
using System.Data.SQLite.Linq;
using System.Data;
using Dapper;

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
        public static SQLiteConnection Connection() {
            return new SQLiteConnection($"Data Source={DbFile}");
        }
    }

    public class Respository {
        public void SaveCustomers(Customer customer) {
            if(!File.Exists(BaseRepository.DbFile)) {
                CreateDatabase();
            }

            
        }

        private void CreateDatabase() {
            using(var conn = BaseRepository.Connection()){
                conn.Open();
                conn.Execute(@"
                    create table Customer
                    (
                        ID          integer identity primary key AUTOINCREMENT,
                        FirstName   varchar(100) not null,
                        LastName    varchar(100) not null,
                        DateOfBirth DateTime not null
                    )
                ");
            }
        }
    }
}