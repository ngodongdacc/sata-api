using Microsoft.AspNetCore.Mvc;
using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Product;
using SATO.Application.Interfaces;

namespace SATO.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IService _service;

        public ProductController(IService service)
        {
            _service = service;
        }
        [HttpPost]
        public string CreateProduct(ProductRequestModel model)
        {
            return _service.InsertProduct(model);
        }
        [HttpPost]
        public string UpdateProduct(ProductRequestModel model)
        {
            return _service.UpdateProduct(model);
        }
        [HttpPost]
        public string DeleteProduct(int id)
        {
            return _service.DeleteProduct(id);
        }
        [HttpPost]
        public async Task<FilterResponseModel<IEnumerable<ProductResponseModel>>> FillterProduct(FilterProductModel filter)
        {
            return await _service.FilterProduct(filter);
        }
    }
}
