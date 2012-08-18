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

        public virtual string CategoryName { get; set; }

        public virtual IEnumerable<Product> Products { get; set; }
    }
}