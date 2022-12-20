using SATO.Application.Common;
using SATO.Application.Common.Model;
using SATO.Application.Common.Model.Customer;
using SATO.Application.Extensions;
using SATO.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Services
{
    public partial class Service
    {
        public List<Customer> InsertCustomer(CustomerRequestModel model)
        {
            var cus = new List<Customer>();
            var customer = _mapper.Map<Customer>(model);
            _unitOfWork.Repository<Customer>().Insert(customer);
            _unitOfWork.Commit();
            return _unitOfWork.Repository<Customer>().Get().ToList();
        }
        public List<Customer> UpdateCustomer(CustomerRequestModel model)
        {
            var customer = _unitOfWork.Repository<Customer>().Get(x => x.CustomerId == model.CustomerId).FirstOrDefault();
            customer.ContactName = model.ContactName;
            customer.ContactPhone = model.ContactPhone;
            customer.Address = model.Address;
            customer.Email = model.Email;
            customer.Description = model.Description;
            _unitOfWork.Repository<Customer>().Update(customer);
            _unitOfWork.Commit();
            return _unitOfWork.Repository<Customer>().Get().ToList();
        }
        public List<Customer> DeleteCustomer(int id)
        {
            _unitOfWork.Repository<Customer>().Delete(id);
            _unitOfWork.Commit();
            return _unitOfWork.Repository<Customer>().Get().ToList();

        }
        public async Task<IEnumerable<CustomerResponseModel>> GetCustomers()
        {
            IEnumerable<Customer> collas = null;

            collas = _unitOfWork.Repository<Customer>().Get();
            var data = _mapper.Map<IEnumerable<CustomerResponseModel>>(collas);
            return data;
        }
        public async Task<FilterResponseModel<IEnumerable<CustomerResponseModel>>> FilterCustomers(FilterCustomersModel filter)
        {
            IEnumerable<Customer> collas = null;
            var startTime = Convert.ToDateTime(filter.StartDate).StartTime();
            var endTime = Convert.ToDateTime(filter.EndDate).EndTime();
            var total = 0;
            try
            {
                if (filter.isExport)
                {
                    collas = _unitOfWork.Repository<Customer>().Get(out total, enableTracking: false,
                            filter: x => x.CreateDate >= startTime && x.CreateDate <= endTime &&
                            (string.IsNullOrEmpty(filter.Search) ||
                                 x.ContactName.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.ContactPhone.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Email.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Address.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Description.ToUpper().Contains(filter.Search.ToUpper())));
                }
                else
                {
                    collas = _unitOfWork.Repository<Customer>().Get(out total, enableTracking: false,
                        offset: filter.Offset, limit: filter.Limit,
                            filter: x => (string.IsNullOrEmpty(filter.Search) ||
                                 x.ContactName.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.ContactPhone.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Email.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Address.ToUpper().Contains(filter.Search.ToUpper()) ||
                                 x.Description.ToUpper().Contains(filter.Search.ToUpper())));
                }
                
                var data = _mapper.Map<IEnumerable<CustomerResponseModel>>(collas).ToList();
                CustomerResponseModel max = data.FirstOrDefault();
                CustomerResponseModel min = data.LastOrDefault();
                List<CustomerResponseModel> abc = null;
                
                abc.Add(max);
                abc.Add(min);
                if (collas.Any())
                {
                    return new FilterResponseModel<IEnumerable<CustomerResponseModel>>
                    {
                        Total = total,
                        Data = data
                    };
                }
                else
                {
                    return new FilterResponseModel<IEnumerable<CustomerResponseModel>>
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
