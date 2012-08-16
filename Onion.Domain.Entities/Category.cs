namespace Onion.Domain.Entities
{
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.CategoryName = string.Empty;
            this.Products = new List<Product>();
        }

        public virtual int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public IEnumerable<Product> Products { get; set; }
    }
}
