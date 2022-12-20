using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Category;
using SATO.Application.Extensions;
using SATO.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Services
{
    public partial class Service
    {
        public string InsertCategory(CategoryRequestModel model)
        {
            if (model == null) return Common.Message.Message.CommonMessage.NotEmpty;
            if (model.CategoryName == null) return Common.Message.Message.CommonMessage.NotEmpty;
            try
            {
                var category = _mapper.Map<Category>(model);
                category.CreatedDate= DateTime.Now;
                _unitOfWork.Repository<Category>().Insert(category);
                _unitOfWork.Commit();
                return Common.Message.Message.CommonMessage.Success;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string UpdateCategory(CategoryRequestModel model)
        {
            if (model == null) return Common.Message.Message.CommonMessage.NotEmpty;
            if (model.CategoryName == null) return Common.Message.Message.CommonMessage.NotEmpty;
            var category = _unitOfWork.Repository<Category>().Get(x => x.CategoryId == model.CategoryId).FirstOrDefault();
            category.CategoryName = model.CategoryName;
            category.Description = model.Description;
            category.UpdateDate = DateTime.Now;
            if (category != null)
            {
                try
                {
                    _unitOfWork.Repository<Category>().Update(category);
                    _unitOfWork.Commit();
                    return Common.Message.Message.CommonMessage.Success;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return Common.Message.Message.CommonMessage.NotExist;
            }

        }
        public string DeleteCategory(int id)
        {
            if (id == 0) return Common.Message.Message.CommonMessage.NotEmpty;
            var category = _unitOfWork.Repository<Category>().Get(x => x.CategoryId == id).FirstOrDefault();
            if (category != null)
            {
                try
                {
                    var product = _unitOfWork.Repository<Product>().Get(x => x.CategoryId == category.CategoryId).ToList();
                    if (product != null)
                    {
                        _unitOfWork.Repository<Product>().RemoveRange(product);
                    }
                    _unitOfWork.Repository<Category>().Delete(id);
                    _unitOfWork.Commit();
                    return Common.Message.Message.CommonMessage.Success;
                }
                catch (Exception ex)
                {
                    return ex.ToString();
                }
            }
            else
            {
                return Common.Message.Message.CommonMessage.NotExist;
            }
        }
        public async Task<FilterResponseModel<IEnumerable<CategoryResponseModel>>> FilterCategory(FilterCategoryModel filter)
        {
            IEnumerable<Category> collas = null;
            var startTime = Convert.ToDateTime(filter.StartDate).StartTime();
            var endTime = Convert.ToDateTime(filter.EndDate).EndTime();
            var total = 0;
            try
            {
                if (filter.isExport)
                {
                    collas = _unitOfWork.Repository<Category>().Get(out total, enableTracking: false,
                            filter: x => x.CreatedDate >= startTime && x.CreatedDate <= endTime &&
                            (string.IsNullOrEmpty(filter.Search) ||
                                 x.CategoryName.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Description.ToUpper().Contains(filter.Search.ToUpper())));
                }
                else
                {
                    collas = _unitOfWork.Repository<Category>().Get(out total, enableTracking: false,
                        offset: filter.Offset, limit: filter.Limit,
                            filter: x => x.CreatedDate >= startTime && x.CreatedDate <= endTime &&
                            (string.IsNullOrEmpty(filter.Search) ||
                                 x.CategoryName.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Description.ToUpper().Contains(filter.Search.ToUpper())));
                }
                
                if (collas.Any())
                {
                    var data = _mapper.Map<IEnumerable<CategoryResponseModel>>(collas);
                    return new FilterResponseModel<IEnumerable<CategoryResponseModel>>
                    {
                        Total = total,
                        Data = data
                    };
                }
                else
                {
                    return new FilterResponseModel<IEnumerable<CategoryResponseModel>>
                    {
                        Total = total,
                        Data = null
                    };
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex?.ToString());
            }
        }
    }
}
