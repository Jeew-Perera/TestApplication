using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using EntityLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBusinessCategory _iBusinessCategory;
        public CategoryController(IBusinessCategory iBusinessCategory)
        {
            _iBusinessCategory = iBusinessCategory;
        }

        [HttpGet]
        [Route("Categories")]
        public List<CategoryViewModel> GetCategories()
        {
            return _iBusinessCategory.GetCategories().ToList();
        }
    }
}
