namespace Onion.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Onion.Domain.Entities;
    using Onion.Domain.Interfaces;

    public class ProductRepository : IProductRepository
    {
        private readonly IRepositoryContext dbContext;

        public ProductRepository(IRepositoryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Product> GetProducts()
        {
            List<Product> products = (from p in this.dbContext.Products
                                      orderby p.ProductName
                                      select p).ToList();
            return products;
        }

        public IEnumerable<Product> GetProductsByCategoryId(int catId)
        {
            List<Product> filteredProducts = (from p in this.dbContext.Products
                                              where p.Category.CategoryId == catId
                                              orderby p.ProductName
                                              select p).ToList();
            return filteredProducts;
        }
    }
}