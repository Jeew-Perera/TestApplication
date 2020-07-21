using EntityLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IBusinessCategory
    {
        List<CategoryViewModel> GetCategories();
    }
}
