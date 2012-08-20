namespace Onion.Infrastructure.Services.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Onion.Domain.Entities;
    using Onion.Domain.Interfaces;

    public class ProductsController : ApiController
    {
        private readonly IProductRepository productRepo;

        public ProductsController(IProductRepository productRepository)
        {
            this.productRepo = productRepository;
        }

        public IEnumerable<Product> Get()
        {
            return this.productRepo.GetProducts();
        }

        public IEnumerable<Product> Get(int id)
        {
            return this.productRepo.GetProductsByCategoryId(id);
        }
    }
}