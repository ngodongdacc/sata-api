using SATO.Application.Common.Model.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Interfaces
{
    public partial interface IService
    {
        string Insert(EmployeeRequestModel model);
        Task<List<EmployeeResponseModel>> ListEmployee();
    }
}
