namespace Onion.Domain.Entities
{
    public class Product
    {
        public Product()
        {
            this.ProductName = string.Empty;
            this.Category = new Category();
        }

        public Category Category { get; set; }

        public virtual int CategoryId { get; set; }

        public virtual bool Discontinued { get; set; }

        public virtual int ProductId { get; set; }

        public string ProductName { get; set; }

        public virtual decimal UnitPrice { get; set; }
    }
}