using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Interfaces
{
    public partial interface IService
    {
        string InsertProduct(ProductRequestModel model);
        string UpdateProduct(ProductRequestModel model);
        string DeleteProduct(int id);
        Task<FilterResponseModel<IEnumerable<ProductResponseModel>>> FilterProduct(FilterProductModel filter);
    }
}
