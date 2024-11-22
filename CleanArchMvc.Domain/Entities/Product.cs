using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Product : Entity
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Stock { get; private set; }
        public string Image { get; private set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Product(string name, string descritopn, decimal price, int stock, string image)
        {
            ValidateDomain(name,descritopn, price, stock, image);
        }

        public Product(int id,string name, string descritopn, decimal price, int stock, string image)
        {
            DomainExceptionValidaion.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name, descritopn, price, stock, image);
        }
        public Product()
        {
            
        }

        public void Update(string name, string descritopn, decimal price, int stock, string image, int categoryId)
        {
            ValidateDomain(name, descritopn, price, stock, image);
            CategoryId = categoryId;
        }

        private void ValidateDomain(string name, string description, decimal price, int stock, string image)
        {
            DomainExceptionValidaion.When(string.IsNullOrEmpty(name),
                "Invalid name. Name is required");

            DomainExceptionValidaion.When(name.Length < 3,
                "Invalid name, too short, minimum 3 characters");

            DomainExceptionValidaion.When(string.IsNullOrEmpty(description),
                "Invalid description. Description is required");

            DomainExceptionValidaion.When(description.Length < 5,
                "Invalid description, too short, minimum 5 characters");

            DomainExceptionValidaion.When(price < 0, "Invalid price value");

            DomainExceptionValidaion.When(stock < 0, "Invalid stock value");

            DomainExceptionValidaion.When(image?.Length > 250,
                "Invalid image name, too long, maximum 250 characters");

            Name = name;
            Description = description;
            Price = price;
            Stock = stock;
            Image = image;

        }


    }
}
