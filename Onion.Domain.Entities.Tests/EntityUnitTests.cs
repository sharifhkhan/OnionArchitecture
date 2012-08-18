namespace Onion.Domain.Entities.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Ninject;
    using NUnit.Framework;
    using Onion.Domain.Entities;
    using Onion.Domain.Interfaces;

    [TestFixture]
    public class EntityUnitTests
    {
        private readonly IEnumerable<Category> categories;

        private readonly ICategoryRepository categoriesRepo;

        private readonly IKernel ninjectKernel;

        private readonly IEnumerable<Product> products;

        private readonly IProductRepository productsRepo;

        public EntityUnitTests()
        {
            this.ninjectKernel = new StandardKernel(new MockRepositoryData());
            this.categoriesRepo = this.ninjectKernel.Get<ICategoryRepository>();
            this.productsRepo = this.ninjectKernel.Get<IProductRepository>();
            this.categories = this.categoriesRepo.GetCategories();
            this.products = this.productsRepo.GetProducts();
        }

        [Test]
        public void CategoriesCountShouldMatch()
        {
            Assert.That(this.categories.Count() == 3, "expected --> 3 got --> " + this.categories.Count());
        }

        [Test]
        public void CategoriesShouldNotBeNull()
        {
            Assert.IsNotNull(this.categories);
        }

        [Test]
        public void CategoryPropertiesShouldMatchTypes()
        {
            var cat = new Category();
            Assert.That(cat.CategoryId is int, cat.CategoryId.ToString() + " is not int");
            Assert.That(cat.CategoryName is string, cat.CategoryName + " is not string");
            Assert.That(cat.Products is IEnumerable<Product>, cat.Products + " is not a list of Products");
        }

        [Test]
        public void ProductCountShouldMatch()
        {
            Assert.That(this.products.Count() == 3, "expected --> 3 got --> " + this.products.Count());
        }

        [Test]
        public void ProductPropertiesShouldMatchTypes()
        {
            var prod = new Product();
            Assert.That(prod.ProductId is int, prod.ProductId.ToString() + " is not int");
            Assert.That(prod.ProductName is string, prod.ProductName + " is not string");
            Assert.That(prod.Discontinued is bool, prod.Discontinued.ToString() + " is not bool");
            Assert.That(prod.UnitPrice is decimal, prod.UnitPrice.ToString() + " is not decimal");
            Assert.IsInstanceOf<Category>(prod.Category);
        }

        [Test]
        public void ProductsShouldNotBeNull()
        {
            Assert.IsNotNull(this.products);
        }
    }
}