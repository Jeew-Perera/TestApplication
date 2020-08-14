using EntityLayer.CategoryDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<CategoryDisplayDto>> GetCategories();
    }
}
