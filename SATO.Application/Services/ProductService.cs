using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Product;
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
        public string InsertProduct(ProductRequestModel model)
        {
            if (model == null) return Common.Message.Message.CommonMessage.NotEmpty;
            if (model.ProductCode == null || model.ProductName == null
                || model.ProviderId == null || model.Quantity == null
                || model.Price == null) return Common.Message.Message.CommonMessage.NotEmpty;
            try
            {
                var product = _mapper.Map<Product>(model);
                product.CreatedDate = DateTime.Now;
                _unitOfWork.Repository<Product>().Insert(product);
                _unitOfWork.Commit();
                return Common.Message.Message.CommonMessage.Success;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string UpdateProduct(ProductRequestModel model)
        {
            if (model == null) return Common.Message.Message.CommonMessage.NotEmpty;
            if (model == null) return Common.Message.Message.CommonMessage.NotEmpty;
            if (model.ProductId == null || model.ProductCode == null || model.ProductName == null
                || model.ProviderId == null || model.Quantity == null
                || model.Price == null) return Common.Message.Message.CommonMessage.NotEmpty;

            var product = _unitOfWork.Repository<Product>().Get(x => x.ProductId == model.ProductId).FirstOrDefault();

            if (product != null)
            {
                try
                {
                    product.ProductName = model.ProductName;
                    product.ProductCode = model.ProductCode;
                    product.ProviderId = model.ProviderId;
                    product.Quantity = model.Quantity;
                    product.Price = model.Price;
                    product.UpdatedDate = DateTime.Now;
                    _unitOfWork.Repository<Product>().Update(product);
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
        public string DeleteProduct(int id)
        {
            if (id == 0) return Common.Message.Message.CommonMessage.NotEmpty;
            var product = _unitOfWork.Repository<Product>().Get(x => x.ProductId == id).FirstOrDefault();
            if (product != null)
            {
                try
                {
                    _unitOfWork.Repository<Product>().Delete(id);
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
        public async Task<FilterResponseModel<IEnumerable<ProductResponseModel>>> FilterProduct(FilterProductModel filter)
        {
            IEnumerable<Product> collas = null;
            var startTime = Convert.ToDateTime(filter.StartDate).StartTime();
            var endTime = Convert.ToDateTime(filter.EndDate).EndTime();
            var total = 0;
            try
            {
                if (filter.isExport)
                {
                    collas = _unitOfWork.Repository<Product>().Get(out total, enableTracking: false,
                            filter: x => x.CreatedDate >= startTime && x.CreatedDate <= endTime &&
                            (filter.CategoryID == 0 || filter.CategoryID == x.CategoryId) &&
                            (filter.ProviderID == 0 || filter.ProviderID == x.ProductId) &&
                            (string.IsNullOrEmpty(filter.Search) ||
                                 x.ProductName.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.ProductCode.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Description.ToUpper().Contains(filter.Search.ToUpper())
                                 ));
                }
                else
                {
                    collas = _unitOfWork.Repository<Product>().Get(out total, enableTracking: false,
                        offset: filter.Offset, limit: filter.Limit,
                            filter: x => x.CreatedDate >= startTime && x.CreatedDate <= endTime &&
                            (filter.CategoryID == 0 || filter.CategoryID == x.CategoryId) &&
                            (filter.ProviderID == 0 || filter.ProviderID == x.ProductId) &&
                            (string.IsNullOrEmpty(filter.Search) ||
                                 x.ProductName.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.ProductCode.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Description.ToUpper().Contains(filter.Search.ToUpper())
                                 ));
                }
                if (collas.Any())
                {
                    var data = _mapper.Map<IEnumerable<ProductResponseModel>>(collas);
                    return new FilterResponseModel<IEnumerable<ProductResponseModel>>
                    {
                        Total = total,
                        Data = data
                    };
                }
                else
                {
                    return new FilterResponseModel<IEnumerable<ProductResponseModel>>
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
