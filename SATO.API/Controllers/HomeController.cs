using Microsoft.AspNetCore.Mvc;
using SATO.Application.Interfaces;

namespace SATO.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private readonly ITestDITransient _serviceTran;
        private readonly ITestDIScoped _serviceSco;
        private readonly ITestDISingleton _serviceSing;

        public HomeController(ITestDITransient serviceTran, ITestDIScoped serviceSco, ITestDISingleton serviceSing)
        {
            _serviceTran = serviceTran;
            _serviceSco = serviceSco;
            _serviceSing = serviceSing;
        }

        [HttpGet]
        public string TestDISing()
        {
            var tran1 = _serviceTran.ListEmployee();
            var tran2 = _serviceTran.ListEmployee();

            var scop1 = _serviceTran.ListEmployee();
            var scop2 = _serviceTran.ListEmployee();

            var sing1 = _serviceTran.ListEmployee();
            var sing2 = _serviceTran.ListEmployee();
            return "";
        }
    }
}
