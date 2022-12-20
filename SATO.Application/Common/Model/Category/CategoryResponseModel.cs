using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model.Category
{
    public class CategoryResponseModel
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<SATO.Entities.Entities.Category, CategoryResponseModel>();
        }
    }
}
