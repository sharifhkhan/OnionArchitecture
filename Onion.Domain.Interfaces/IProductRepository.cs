namespace Onion.Domain.Interfaces
{
    using System.Collections.Generic;
    using Onion.Domain.Entities;

    public interface IProductRepository
    {
        IEnumerable<Product> GetProducts();

        IEnumerable<Product> GetProductsByCategoryId(int categoryId);
    }
}