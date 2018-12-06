
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DapperPostgreSQL.Df {
    public class MyContext : DbContext {
        public MyContext(DbContextOptions options) : base(options) {

        }

        public DbSet<Student> Students { set; get; }

    }

    public class Student {
        [Key]
        public int Id { set; get; }
        public byte[] Picture { set; get; }
    }
}