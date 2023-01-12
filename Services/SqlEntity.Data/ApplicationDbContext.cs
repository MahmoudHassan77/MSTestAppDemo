using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

namespace SqlEntity.Data
{
    public class Operation
    {
        public int Id { get; set; }
        public int Number1 { get; set; }
        public int Number2 { get; set; }
        public int Result { get; set; }
        public string? OperationName { get; set; }
        public DateTime DateTime { get; set; }

    }

    public class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Calculator ;Integrated Security=True; TrustServerCertificate = True;");
        }

        public DbSet<Operation> Operations { get; set; }
    }
}
