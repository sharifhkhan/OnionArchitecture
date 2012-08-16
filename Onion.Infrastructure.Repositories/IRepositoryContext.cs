namespace Onion.Infrastructure.Repositories
{
    using System.Data.Entity;
    using Onion.Domain.Entities;

    public interface IRepositoryContext
    {
        DbSet<Category> Categories { get; set; }

        DbSet<Product> Products { get; set; }
    }
}