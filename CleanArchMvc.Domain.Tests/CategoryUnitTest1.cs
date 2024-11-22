using CleanArchMvc.Domain.Entities;
using FluentAssertions;

namespace CleanArchMvc.Domain.Tests
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category With Valid State")]
        public void CreateCategory_WithValidadParameters_ResulObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should()
                .NotThrow<CleanArchMvc.Domain.Validation.DomainExceptionValidaion>();
        }

        [Fact]
        public void CreateCategory_NegativeIdValue_DomainExcptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidaion>()
                .WithMessage("Invalid id value");
        }

        [Fact]
        public void CreateCategory_ShortNameValue_DomainExcptionInvalidId()
        {
            Action action = () => new Category(1, "Ca");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidaion>()
                .WithMessage("Ivalid name, too short, minumum 3 charecters");
        }

        [Fact]
        public void CreateCategory_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidaion>()
                .WithMessage("Ivalid name.Name is required");
        }
        [Fact]
        public void CreateCategory_WithNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, null);
            action.Should()
                .Throw<CleanArchMvc.Domain.Validation.DomainExceptionValidaion>();
        }
    }
}
