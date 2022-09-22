using AutoMapper;
using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchMvc.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _categoryRespository;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRespository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetCategories()
        {
            var categoriesEntity = await _categoryRespository.GetCategories();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categoriesEntity);
        }

        public async Task<CategoryDTO> GetById(int? id)
        {
            var categoriesEntity = await _categoryRespository.GetById(id);
            return _mapper.Map<CategoryDTO>(categoriesEntity);
        }

        public async Task Add(CategoryDTO categoryDto)
        {
            //Converter antes.
            // Usa-se uma operação inversa.
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRespository.Create(categoryEntity);
        }

        public async Task Update(CategoryDTO categoryDto)
        {
            var categoryEntity = _mapper.Map<Category>(categoryDto);
            await _categoryRespository.Update(categoryEntity);
        }
        public async Task Remove(int? id)
        {
            var categotyEntity = _categoryRespository.GetById(id).Result;
            await _categoryRespository.Remove(categotyEntity);
        }
    }
}
