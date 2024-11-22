using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Application.Products.Queries;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using MediatR;

namespace CleanArchMvc.Application.Services
{
    public class ProductService : IProductService
    {
        private IProducRepository _producRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public ProductService(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProductDTO>> GetProducts()
        {
            var p = new GetProductQuery();
            if (p == null)
                throw new Exception($"Entity could not be loadd.");
            var result = await _mediator.Send(p);
            return _mapper.Map<IEnumerable<ProductDTO>>(result);

            //var v = await _producRepository.GetProductAsync();
            //return _mapper.Map<IEnumerable<ProductDTO>>(v);
        }

        public async Task<ProductDTO> GetProductById(int id)
        {
            var v = await _producRepository.GetByIdAsync(id);
            return _mapper.Map<ProductDTO>(v);
        }

        public async Task<ProductDTO> GetProductCategory(int id)
        {
            var v = await _producRepository.GetProductCategoryAsync(id);
            return _mapper.Map<ProductDTO>(v);
        }

        public async Task Add(ProductDTO productDto)
        {
            var v = _mapper.Map<Product>(productDto);
            await _producRepository.CreateAsync(v);
        }

        public async Task Update(ProductDTO productDto)
        {
            var v = _mapper.Map<Product>(productDto);
            await _producRepository.UpdateAsync(v);
        }

        public async Task Remove(int id)
        {
            var v = _producRepository.GetByIdAsync(id).Result;
            await _producRepository.RemoveAsync(v);
        }
    }
}
