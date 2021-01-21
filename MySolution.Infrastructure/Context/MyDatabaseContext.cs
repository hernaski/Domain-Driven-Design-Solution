using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MySolution.Domain.Entities;

namespace MySolution.Infrastructure.Context
{
    public class MyDatabaseContext : IdentityDbContext
    {
        #region Constructors
        public MyDatabaseContext(DbContextOptions<MyDatabaseContext> options) : base(options) { }
        #endregion

        #region DbSets
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        #endregion

        #region Methods
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new FluentApi.CategoryFluent());
            modelBuilder.ApplyConfiguration(new FluentApi.ProductFluent());
        }
        #endregion
    }
}