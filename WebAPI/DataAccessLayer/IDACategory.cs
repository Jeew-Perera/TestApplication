using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer
{
    public interface IDACategory
    {
        List<CategoryViewModel> GetCategories();
    }
}
