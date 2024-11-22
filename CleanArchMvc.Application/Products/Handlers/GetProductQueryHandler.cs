using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Products.Handlers
{
    public class GetProductQueryHandler : IRequestHandler<GetProductQuery, IEnumerable<Product>>
    {
        private readonly IProducRepository _producRepository;
        public GetProductQueryHandler(IProducRepository producRepository)
        {
            _producRepository = producRepository;
        }

        public async Task<IEnumerable<Product>> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            return await _producRepository.GetProductAsync();
        }
    }
}
