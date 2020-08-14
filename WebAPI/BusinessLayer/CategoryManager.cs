using DataAccessLayer.UnitOfWork;
using EntityLayer.CategoryDto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class CategoryManager : ICategoryManager
    {
        private readonly IUnitOfWork _iUnitOfWork;

        public CategoryManager(IUnitOfWork iUnitOfWork)
        {
            _iUnitOfWork = iUnitOfWork;
        }

        public async Task<IEnumerable<CategoryDisplayDto>> GetCategories()
        {
            return await _iUnitOfWork.CategoryRepository.GetCategories();
        }
    }
}
