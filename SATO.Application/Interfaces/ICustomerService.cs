using SATO.Application.Common;
using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Customer;
using SATO.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Interfaces
{
    public partial interface IService
    {
        List<Customer> InsertCustomer(CustomerRequestModel model);
        List<Customer> UpdateCustomer(CustomerRequestModel model);
        List<Customer> DeleteCustomer(int id);
        Task<IEnumerable<CustomerResponseModel>> GetCustomers();
        Task<FilterResponseModel<IEnumerable<CustomerResponseModel>>> FilterCustomers(FilterCustomersModel filter);
    }
}
