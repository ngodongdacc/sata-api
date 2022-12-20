using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model.Customer
{
    public class CustomerRequestModel
    {
        public int CustomerId { get; set; }
        public string? ContactName { get; set; }
        public string? ContactPhone { get; set; }
        public string? Address { get; set; }
        public string? Email { get; set; }
        public string? Description { get; set; }
    }
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<CustomerRequestModel, SATO.Entities.Entities.Customer>();
        }
    }
}
