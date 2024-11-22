using CleanArchMvc.Application.Products.Commands;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class ProductRemoveCommandHandler : IRequestHandler<ProductRemoveCommand, Product>
    {
        private readonly IProducRepository _producRepository;
        public ProductRemoveCommandHandler(IProducRepository producRepository)
        {
            _producRepository = producRepository ??
                throw new ArgumentNullException(nameof(producRepository));
        }

        public async Task<Product> Handle(ProductRemoveCommand request, CancellationToken cancellationToken)
        {
            var product = await _producRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException("Entity could not be found.");
            }
            else
            {
                return await _producRepository.RemoveAsync(product);
            }
        }
    }
}
