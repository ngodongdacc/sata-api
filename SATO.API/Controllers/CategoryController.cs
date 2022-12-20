using Microsoft.AspNetCore.Mvc;
using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Category;
using SATO.Application.Interfaces;

namespace SATO.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IService _service;

        public CategoryController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public string CreateCategory(CategoryRequestModel model)
        {
            return _service.InsertCategory(model);
        }
        [HttpPost]
        public string UpdateCategory(CategoryRequestModel model)
        {
            return _service.UpdateCategory(model);
        }
        [HttpPost]
        public string DeleteCategory(int id)
        {
            return _service.DeleteCategory(id);
        }
        [HttpPost]
        public async Task<FilterResponseModel<IEnumerable<CategoryResponseModel>>> FillterCustomers(FilterCategoryModel filter)
        {
            return await _service.FilterCategory(filter);
        }
    }
}
