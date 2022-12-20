using Microsoft.AspNetCore.Mvc;
using SATO.Application.Interfaces;

namespace SATO.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IService _service;

        public OrderController(IService service)
        {
            _service = service;
        }
        [HttpGet]
        public string Test()
        {
            return _service.Test();
        }
    }
}
