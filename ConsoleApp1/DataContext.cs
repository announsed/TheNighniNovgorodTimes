using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ConsoleApp1
{
    internal class DataContext : DbContext
    {
        private DatabaseType _databaseType;
        private readonly IConfiguration _configuration;
        public DataContext(DatabaseType databaseType) 
        {
            _databaseType = databaseType;

            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("StringConnect.json", optional: false, reloadOnChange: true)
                .Build();

            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Reader> Readers { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = _databaseType == DatabaseType.SqlServer
            ? _configuration.GetConnectionString("SqlServerConnection")
            : _configuration.GetConnectionString("SqliteConnection");

            if (_databaseType == DatabaseType.SqlServer)
            {
                optionsBuilder.UseSqlServer(connectionString);
            }
            else
            {
                optionsBuilder.UseSqlite(connectionString);
            }
        }
    }

    public enum DatabaseType
    {
        SqlServer,
        Sqlite
    }
}
