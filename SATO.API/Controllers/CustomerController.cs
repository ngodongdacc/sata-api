using Microsoft.AspNetCore.Mvc;
using SATO.Application.Common;
using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Customer;
using SATO.Application.Interfaces;
using SATO.Entities.Entities;

namespace SATO.API.Controllers
{
    [Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IService _service;

        public CustomerController(IService service)
        {
            _service = service;
        }

        [HttpPost]
        public List<Customer> CreateCustomer(CustomerRequestModel model)
        {
            return _service.InsertCustomer(model);
        }
        [HttpPost]
        public List<Customer> UpdateCustomer(CustomerRequestModel model)
        {
            return _service.UpdateCustomer(model);
        }
        [HttpPost]
        public List<Customer> DeleteCustomer(int id)
        {
            return _service.DeleteCustomer(id);
        }
        //[HttpPost]
        //public ResultModel ListCustomer(int customerId,string date)
        //{
        //    return _service.ListCustomer(customerId, date);
        //}
        [HttpGet]
        public async Task<IEnumerable<CustomerResponseModel>> GetCustomers()
        {
            return await _service.GetCustomers();
        }
        [HttpPost]
        public async Task<FilterResponseModel<IEnumerable<CustomerResponseModel>>> FillterCustomers(FilterCustomersModel filter)
        {
            return await _service.FilterCustomers(filter);
        }
        [HttpGet]
        public async Task A()
        {
            List<Test> ex = new();
            var obj1 = new Test();
            obj1.name = "A";
            obj1.checkIn = "7";
            obj1.checkOut = "17";
            var obj2 = new Test();
            obj2.name = "B";
            obj2.checkIn = "8";
            obj2.checkOut = "18";
            ex.Add(obj1);
            ex.Add(obj2);

            List<Example> data = new List<Example>();
            var dataIn = (from e in ex
                       select new Example()
                       {
                           name=e.name,
                           type="In",
                           time= e.checkIn
                       }).ToList();
            var dataOut = (from e in ex
                          select new Example()
                          {
                              name = e.name,
                              type = "Out",
                              time = e.checkOut
                          }).ToList();
            data.AddRange(dataIn);
            data.AddRange(dataOut);

            //linq to sql, linq to entity
            //data = dataIn.Union(dataOut);
        }
    }

}
