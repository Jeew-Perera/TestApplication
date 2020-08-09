using EntityLayer.CategoryDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public interface ICategoryManager
    {
        Task<IEnumerable<CategoryDisplayDto>> GetCategories();
    }
}
