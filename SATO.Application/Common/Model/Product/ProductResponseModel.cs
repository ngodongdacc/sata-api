using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model.Product
{
    public class ProductResponseModel
    {
        public int ProductId { get; set; }
        public string? ProductCode { get; set; }
        public string? ProductName { get; set; }
        public int? ProviderId { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Price { get; set; }
        public string? Description { get; set; }
        public int? CategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
    public class ProductResponseProfile : Profile
    {
        public ProductResponseProfile()
        {
            CreateMap<SATO.Entities.Entities.Product, ProductResponseModel>();
        }
    }
}
