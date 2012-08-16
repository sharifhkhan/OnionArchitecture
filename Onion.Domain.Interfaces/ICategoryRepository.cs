namespace Onion.Domain.Interfaces
{
    using System.Collections.Generic;
    using Onion.Domain.Entities;

    public interface ICategoryRepository
    {
        IEnumerable<Category> GetCategories();
    }
}