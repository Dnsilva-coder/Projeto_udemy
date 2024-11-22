using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductUpdateCommandHandler : IRequestHandler<ProductUpdateCommand, Product>
    {
        private readonly IProducRepository _producRepository;
        public ProductUpdateCommandHandler(IProducRepository producRepository)
        {
            _producRepository = producRepository ??
                throw new ArgumentNullException(nameof(producRepository));
        }

        public async Task<Product> Handle(ProductUpdateCommand request, CancellationToken cancellationToken)
        {
            var product = await _producRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException("Entity could not be found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price, request.Stock, request.Image, request.CategoryId);
                return await _producRepository.UpdateAsync(product);
            }
        }
    }
}
