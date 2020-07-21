using DataAccessLayer;
using EntityLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer
{
    public class BusinessCategory : IBusinessCategory
    {
        private IDACategory _iDACategory;

        public BusinessCategory(IDACategory iDACategory)
        {
            _iDACategory = iDACategory;
        }

        public List<CategoryViewModel> GetCategories()
        {
            return _iDACategory.GetCategories().ToList();
        }
    }
}
