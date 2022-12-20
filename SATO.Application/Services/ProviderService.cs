using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Provider;
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
        public string InsertProvider(ProviderRequestModel model)
        {
            if (model == null) return Common.Message.Message.CommonMessage.NotEmpty;
            if (model.ProviderCode == null || model.ProviderName == null
                || model.Address == null || model.Address == null
                || model.ProviderPhone == null || model.ProviderEmail == null) return Common.Message.Message.CommonMessage.NotEmpty;
            try
            {
                var provider = _mapper.Map<Provider>(model);
                provider.CreatedDate = DateTime.Now;
                _unitOfWork.Repository<Provider>().Insert(provider);
                _unitOfWork.Commit();
                return Common.Message.Message.CommonMessage.Success;
            }
            catch (Exception ex)
            {
                return ex.ToString();
            }
        }
        public string UpdateProvider(ProviderRequestModel model)
        {
            if (model == null) return Common.Message.Message.CommonMessage.NotEmpty;
            if (model.ProviderId == null || model.ProviderCode == null || model.ProviderName == null
                || model.Address == null || model.Address == null
                || model.ProviderPhone == null || model.ProviderEmail == null) return Common.Message.Message.CommonMessage.NotEmpty;

            var provider = _unitOfWork.Repository<Provider>().Get(x => x.ProviderId == model.ProviderId).FirstOrDefault();
            
            if (provider != null)
            {
                try
                {
                    provider.ProviderName = model.ProviderName;
                    provider.ProviderEmail = model.ProviderEmail;
                    provider.Address = model.Address;
                    provider.ProviderCode = model.ProviderCode;
                    provider.ProviderPhone = model.ProviderPhone;
                    provider.UpdateDate = DateTime.Now;
                    _unitOfWork.Repository<Provider>().Update(provider);
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
        public string DeleteProvider(int id)
        {
            if (id == 0) return Common.Message.Message.CommonMessage.NotEmpty;
            var provider = _unitOfWork.Repository<Provider>().Get(x => x.ProviderId == id).FirstOrDefault();
            if (provider != null)
            {
                try
                {
                    var product = _unitOfWork.Repository<Product>().Get(x => x.ProviderId == provider.ProviderId).ToList();
                    if (product != null)
                    {
                        _unitOfWork.Repository<Product>().RemoveRange(product);
                    }
                    _unitOfWork.Repository<Provider>().Delete(id);
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
        public async Task<FilterResponseModel<IEnumerable<ProviderResponseModel>>> FilterProvider(FilterProviderModel filter)
        {
            IEnumerable<Provider> collas = null;
            var startTime = Convert.ToDateTime(filter.StartDate).StartTime();
            var endTime = Convert.ToDateTime(filter.EndDate).EndTime();
            var total = 0;
            try
            {
                if (filter.isExport)
                {
                    collas = _unitOfWork.Repository<Provider>().Get(out total, enableTracking: false,
                            filter: x => x.CreatedDate >= startTime && x.CreatedDate <= endTime &&
                            (string.IsNullOrEmpty(filter.Search) ||
                                 x.ProviderName.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.ProviderPhone.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.ProviderEmail.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Address.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.ProviderCode.ToUpper().Contains(filter.Search.ToUpper())));
                }
                else
                {
                    collas = _unitOfWork.Repository<Provider>().Get(out total, enableTracking: false,
                        offset: filter.Offset, limit: filter.Limit,
                            filter: x => x.CreatedDate >= startTime && x.CreatedDate <= endTime &&
                            (string.IsNullOrEmpty(filter.Search) ||
                                 x.ProviderName.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.ProviderPhone.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.ProviderEmail.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Address.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.ProviderCode.ToUpper().Contains(filter.Search.ToUpper())));
                }
                var data = _mapper.Map<IEnumerable<ProviderResponseModel>>(collas);
                if (collas.Any())
                {
                    return new FilterResponseModel<IEnumerable<ProviderResponseModel>>
                    {
                        Total = total,
                        Data = data
                    };
                }
                else
                {
                    return new FilterResponseModel<IEnumerable<ProviderResponseModel>>
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
