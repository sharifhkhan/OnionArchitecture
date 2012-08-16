namespace Onion.Infrastructure.Repositories
{
    using System.Collections.Generic;
    using System.Linq;
    using Onion.Domain.Entities;
    using Onion.Domain.Interfaces;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly IRepositoryContext dbContext;

        public CategoryRepository(IRepositoryContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Category> GetCategories()
        {
            List<Category> categories = (from c in this.dbContext.Categories
                                         orderby c.CategoryName
                                         select c).ToList();

            return categories;
        }
    }
}