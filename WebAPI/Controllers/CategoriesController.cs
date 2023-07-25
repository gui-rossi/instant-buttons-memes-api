using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace WebAPI.Controllers
{
    [Controller]
    [Route("api/Category/")]
    public class CategoriesController : Controller
    {
        private readonly ICategoriesService m_categoryService;

        public CategoriesController(ICategoriesService categoryService)
        {
            m_categoryService = categoryService;
        }

        [HttpGet("FetchCategories")]
        public async Task<dynamic> GetCategories()
        {
            var rval = await m_categoryService.GetCategoriesAsync();

            return rval;
        }
    }
}
