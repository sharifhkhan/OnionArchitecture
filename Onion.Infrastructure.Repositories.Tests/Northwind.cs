namespace Onion.Infrastructure.Repositories.Tests
{
    using System.Data.Entity;
    using Onion.Domain.Entities;

    public class Northwind : DbContext, IRepositoryContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    }
}