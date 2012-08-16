namespace Onion.Domain.Entities.Tests
{
    using System.Collections.Generic;
    using Moq;
    using Ninject.Modules;
    using Onion.Domain.Entities;
    using Onion.Domain.Interfaces;

    public class MockRepositoryData : NinjectModule
    {
        public override void Load()
        {
            var categories = new List<Category>
                {
                    new Category { CategoryId = 1, CategoryName = "Beverages" }, 
                    new Category { CategoryId = 2, CategoryName = "Condiments" }, 
                    new Category { CategoryId = 3, CategoryName = "Confections" }
                };

            var mockCategoriesRep = new Mock<ICategoryRepository>();
            mockCategoriesRep.Setup(m => m.GetCategories()).Returns(categories);
            this.Kernel.Bind<ICategoryRepository>().ToConstant(mockCategoriesRep.Object);

            var products = new List<Product>
                {
                    new Product { ProductId = 1, ProductName = "Chai", UnitPrice = 18M, Category = categories[0] }, 
                    new Product { ProductId = 1, ProductName = "Chang", UnitPrice = 19M, Category = categories[0] }, 
                    new Product
                        {
                           ProductId = 1, ProductName = "Aniseed Syrup", UnitPrice = 10M, Category = categories[1] 
                        }
                };

            var mockProductsRep = new Mock<IProductRepository>();
            mockProductsRep.Setup(m => m.GetProducts()).Returns(products);
            this.Kernel.Bind<IProductRepository>().ToConstant(mockProductsRep.Object);
        }
    }
}