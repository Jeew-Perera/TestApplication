using EntityLayer;
using EntityLayer.CategoryDto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDisplayDto>> GetCategories();
    }
}
