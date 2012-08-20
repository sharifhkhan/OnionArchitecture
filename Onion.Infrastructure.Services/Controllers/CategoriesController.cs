namespace Onion.Infrastructure.Services.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Onion.Domain.Entities;
    using Onion.Domain.Interfaces;

    public class CategoriesController : ApiController
    {
        private readonly ICategoryRepository categoryRepo;

        public CategoriesController(ICategoryRepository categoryRepository)
        {
            this.categoryRepo = categoryRepository;
        }

        public IEnumerable<Category> Get()
        {
            return this.categoryRepo.GetCategories();
        }
    }
}