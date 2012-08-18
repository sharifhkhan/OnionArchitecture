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

            // foreach (var product in data)
            // {
            // IEnumerable list = product.GetType().GetProperties();
            // System.Console.WriteLine("---------");
            // foreach (var property in list)
            // {
            // System.Console.WriteLine("Prop is " + property);   
            // }
            // System.Console.WriteLine("---------");
            // }
            Assert.That(data.Any(), "Found: " + data.Count().ToString());
        }

        [Test]
        public void ProductsShouldReturnDataForCategory()
        {
            var productRepo = new ProductRepository(this.northwind);
            IEnumerable<Product> data = productRepo.GetProductsByCategoryId(1);
            Assert.That(data.Any(), "Found: " + data.Count().ToString());
        }
    }
}