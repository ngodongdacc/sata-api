using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model.Customer
{
    public class CustomerResponseModel
    {
        public int CustomerID { get; set; }
        public string ContactName { get; set; }
        public string ContactPhone { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }
    }
    public class CustomerResponseProfile : Profile{
        public CustomerResponseProfile()
        {
            CreateMap<SATO.Entities.Entities.Customer, CustomerResponseModel>();
        }
}

}
