using Microsoft.AspNetCore.Mvc;
using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Provider;
using SATO.Application.Interfaces;

namespace SATO.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private readonly IService _service;

        public ProviderController(IService service)
        {
            _service = service;
        }
        [HttpPost]
        public string CreateProvider(ProviderRequestModel model)
        {
            return _service.InsertProvider(model);
        }
        [HttpPost]
        public string UpdateProvider(ProviderRequestModel model)
        {
            return _service.UpdateProvider(model);
        }
        [HttpPost]
        public string DeleteProvider(int id)
        {
            return _service.DeleteProvider(id);
        }
        [HttpPost]
        public async Task<FilterResponseModel<IEnumerable<ProviderResponseModel>>> FillterProvider(FilterProviderModel filter)
        {
            return await _service.FilterProvider(filter);
        }

    }
}
