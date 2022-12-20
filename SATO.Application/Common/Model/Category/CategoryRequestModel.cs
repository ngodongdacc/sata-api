using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model.Category
{
    public class CategoryRequestModel
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Description { get; set; }
    }
    public class CategoryResponseProfile : Profile
    {
        public CategoryResponseProfile()
        {
            CreateMap<CategoryRequestModel, SATO.Entities.Entities.Category>();
        }
    }
}
