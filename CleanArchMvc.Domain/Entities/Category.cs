using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : Entity
    {
        public string Name { get; private set; }

        public Category(string name)
        {
            ValidateDomain(name);
            Name = name;
        }

        public Category(int id, string name)
        {
            DomainExceptionValidaion.When(id < 0, "Invalid Id value");
            Id = id;
            ValidateDomain(name);
        }

        public void Update(string name)
        {

        }

        public ICollection<Product> Products { get; set; }

        private void ValidateDomain(string name)
        {
            DomainExceptionValidaion.When(string.IsNullOrEmpty(name),
                "Ivalid name.Name is required");
            DomainExceptionValidaion.When(name.Length < 3,
                "Ivalid name, too short, minumum 3 charecters");

            Name = name;
        }
    }
}

