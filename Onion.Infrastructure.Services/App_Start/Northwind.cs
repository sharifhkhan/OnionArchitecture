namespace Onion.Infrastructure.Services.App_Start
{
    using System.Data.Entity;
    using Onion.Domain.Entities;
    using Onion.Infrastructure.Repositories;

    public class Northwind : DbContext, IRepositoryContext
    {
        public DbSet<Category> Categories { get; set; }

        public DbSet<Product> Products { get; set; }
    
    }
}