using SATO.Application.Common.Model.Employee;
using SATO.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Services
{
    public partial class Service
    {
        public string Insert(EmployeeRequestModel model)
        {
            if (model == null) return Common.Message.Message.CommonMessage.NotEmpty;
            if (model.EmployeeCode == null || model.FirstName == null || 
                model.LastName == null|| model.EmployeeCode == null||
                model.BirthOfDate == null|| model.Address == null|| 
                model.PhoneNumber == null) return Common.Message.Message.CommonMessage.NotEmpty;
            
            try
            {
                var employee = _mapper.Map<Employee>(model);
                employee.CreatedDate = DateTime.Now;

                _unitOfWork.Repository<Employee>().Insert(employee);
                _unitOfWork.Commit();
                return Common.Message.Message.CommonMessage.Success;
            }catch(Exception ex)
            {
                return ex.ToString();
            }
        }
        public async Task<List<EmployeeResponseModel>> ListEmployee()
        {
            var total = 0;
            var response = _unitOfWork.Repository<Employee>().Get(out total, enableTracking: false);
            return _mapper.Map<List<EmployeeResponseModel>>(response);
        }
    }
}
