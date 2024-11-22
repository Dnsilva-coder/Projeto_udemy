using AutoMapper;
using CleanArchMvc.Application.Dtos;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _category;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryService,IMapper mapper)
        {
            _category = categoryService;
            _mapper = mapper;
        }
        public async Task Add(CategoryDTO categoryDTO)
        {
          var v = _mapper.Map<Category>(categoryDTO);
            await _category.CreateAsync(v);
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
               var v = await _category.GetCategoriesAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(v);
        }

        public async Task<CategoryDTO> GetCategoryById(int id)
        {
               var v = await _category.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(v);
        }

        public async Task Remove(int id)
        {
            var v = _category.GetByIdAsync(id).Result;
            await _category.RemoveAsync(v);
        }

        public async Task Update(CategoryDTO categoryDTO)
        {
            var v = _mapper.Map<Category>(categoryDTO);
            await _category.UpdateAsync(v);
        }
    }
}
