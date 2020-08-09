using AutoMapper;
using DataAccessLayer.Models;
using EntityLayer;
using EntityLayer.CategoryDto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ShoppingCartContext _context;
        private readonly IMapper _iMapper;

        public CategoryRepository(ShoppingCartContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }

        public async Task<IEnumerable<CategoryDisplayDto>> GetCategories()
        {
            var categories = await _context.Category.ToListAsync();
            return _iMapper.Map<CategoryDisplayDto[]>(categories);
        }
    }
}
