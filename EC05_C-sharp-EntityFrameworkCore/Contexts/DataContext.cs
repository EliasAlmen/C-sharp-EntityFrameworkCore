using EC05_C_sharp_EntityFrameworkCore.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EC05_C_sharp_EntityFrameworkCore.Contexts
{
    internal class DataContext : DbContext
    {

        private readonly string _connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Elias\Downloads\EC-utbildning-webbutvecklare-NET\05-Datalagring\EC05-Databases\EC05_C-sharp-EntityFrameworkCore\EC05_C-sharp-EntityFrameworkCore\Contexts\sql_db.mdf;Integrated Security=True;Connect Timeout=30";

        #region constructors

        public DataContext() 
        { 
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        #endregion

        #region overrides
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) 
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
        #endregion

        #region entities

        public DbSet<AddressEntity> Addresses { get; set; } = null!;
        public DbSet<CustomerEntity> Customers { get; set; } = null!;
        public DbSet<ProductEntity> Products { get; set; } = null!;
        public DbSet<EmployeeEntity> Employees { get; set; } = null!;
        #endregion
    }
}
