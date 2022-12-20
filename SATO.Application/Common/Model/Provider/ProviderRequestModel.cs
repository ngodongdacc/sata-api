using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Common.Model.Provider
{
    public class ProviderRequestModel
    {
        public int ProviderId { get; set; }
        public string? ProviderCode { get; set; }
        public string? ProviderName { get; set; }
        public string? Address { get; set; }
        public string? ProviderPhone { get; set; }
        public string? ProviderEmail { get; set; }
    }
    public class ProviderProfile : Profile
    {
        public ProviderProfile()
        {
            CreateMap<ProviderRequestModel, SATO.Entities.Entities.Provider>();
        }
    }
}
