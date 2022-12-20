using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Provider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Interfaces
{
    public partial interface IService
    {
        string InsertProvider(ProviderRequestModel model);
        string UpdateProvider(ProviderRequestModel model);
        string DeleteProvider(int id);
        Task<FilterResponseModel<IEnumerable<ProviderResponseModel>>> FilterProvider(FilterProviderModel filter);
    }
}
