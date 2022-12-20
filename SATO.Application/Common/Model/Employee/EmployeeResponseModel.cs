using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model.Employee
{
    public class EmployeeResponseModel
    {
        public int EmployeeId { get; set; }
        public string? EmployeeCode { get; set; }
        public string? LastName { get; set; }
        public string? FirstName { get; set; }
        public DateTime? BirthOfDate { get; set; }
        public string? Address { get; set; }
        public string? PhoneNumber { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? Description { get; set; }
    }
    public class EmployeeResponseProfile : Profile
    {
        public EmployeeResponseProfile()
        {
            CreateMap<SATO.Entities.Entities.Employee, EmployeeResponseModel>();
        }
    }
}
