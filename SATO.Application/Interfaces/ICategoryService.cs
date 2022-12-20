using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Interfaces
{
    public partial interface IService
    {
        string InsertCategory(CategoryRequestModel model);
        string UpdateCategory(CategoryRequestModel model);
        string DeleteCategory(int id);
        Task<FilterResponseModel<IEnumerable<CategoryResponseModel>>> FilterCategory(FilterCategoryModel filter);
    }
}
