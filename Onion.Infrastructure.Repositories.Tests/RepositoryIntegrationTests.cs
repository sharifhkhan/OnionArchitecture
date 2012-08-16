namespace Onion.Infrastructure.Repositories.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using NUnit.Framework;
    using Onion.Domain.Entities;

    [TestFixture]
    public class RepositoryIntegrationTests
    {
        private readonly Northwind northwind = new Northwind();

        [Test]
        public void CategoriesShouldReturnData()
        {
            var categoryRepo = new CategoryRepository(this.northwind);
            IEnumerable<Category> data = categoryRepo.GetCategories();
            Assert.That(data.Any(), "Found: " + data.Count().ToString());
        }

        [Test]
        public void ProductsShouldReturnData()
        {
            var productRepo = new ProductRepository(this.northwind);
            IEnumerable<Product> data = productRepo.GetProducts();
            System.Console.WriteLine(data.Count());
            Assert.That(data.Any(), "Found: " + data.Count().ToString());
        }

        [Test]
        public void ProductsShouldReturnDataForCategory()
        {
            var productRepo = new ProductRepository(this.northwind);
            IEnumerable<Product> data = productRepo.GetProductsByCategoryId(1);
            System.Console.WriteLine(data.Count());
            Assert.That(data.Any(), "Found: " + data.Count().ToString());
        }
    }
}