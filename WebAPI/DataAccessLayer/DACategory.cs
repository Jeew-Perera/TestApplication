using AutoMapper;
using DataAccessLayer.Models;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer
{
    public class DACategory : IDACategory
    {
        private readonly ShoppingCartContext _context;
        private readonly IMapper _iMapper;

        public DACategory(ShoppingCartContext context, IMapper iMapper)
        {
            _context = context;
            _iMapper = iMapper;
        }

        public List<CategoryViewModel> GetCategories()
        {
            var categories = _context.Category.ToList();
            var categoryViewModel = new List<CategoryViewModel>();
            return _iMapper.Map<IEnumerable<CategoryViewModel>>(categories).ToList();
        }
    }
}
