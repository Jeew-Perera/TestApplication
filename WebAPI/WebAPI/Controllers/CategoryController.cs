using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using EntityLayer;
using EntityLayer.CategoryDto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryManager _iCategoryManager;
        public CategoryController(ICategoryManager iCategoryManager)
        {
            _iCategoryManager = iCategoryManager;
        }

        [HttpGet]
        [Route("Categories")]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _iCategoryManager.GetCategories();
            return Ok(categories);
        }
    }
}
