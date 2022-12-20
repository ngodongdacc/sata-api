using Microsoft.AspNetCore.Mvc;
using SATO.Application.Common.Model.Employee;
using SATO.Application.Interfaces;

namespace SATO.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IService _service;

        public EmployeeController(IService service)
        {
            _service = service;
        }
        [HttpPost]
        public string CreateEmployee(EmployeeRequestModel model)
        {
            return _service.Insert(model);
        }
        [HttpGet]
        public async Task<List<EmployeeResponseModel>> FilterEmployee()
        {
            return await _service.ListEmployee();
        }
    }
}
