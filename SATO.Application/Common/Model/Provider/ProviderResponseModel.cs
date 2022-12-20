using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model.Provider
{
    public class ProviderResponseModel
    {
        public int ProviderId { get; set; }
        public string? ProviderCode { get; set; }
        public string? ProviderName { get; set; }
        public string? Address { get; set; }
        public string? ProviderPhone { get; set; }
        public string? ProviderEmail { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
    public class ProviderResponseProfile : Profile
    {
        public ProviderResponseProfile()
        {
            CreateMap<SATO.Entities.Entities.Provider, ProviderResponseModel>();
        }
    }
}
