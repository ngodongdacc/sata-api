using AutoMapper;
using SATO.Application.Common.Model.Customer;
using SATO.Application.Interfaces;
using SATO.Entities.Entities;
using SATO.Infrastructure.Interfaces;
using SATO.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Services
{
    [SuppressMessage("ReSharper", "ComplexConditionExpression")]
    partial class Service : IService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<SatoDbContext> _unitOfWork;
        private readonly ICustomerRepository _customerRepository;
        private readonly ITempRepository _tempRepository;
        private readonly ICardRepository _cardRepository;

        public Service(IMapper mapper, IUnitOfWork<SatoDbContext> unitOfWork, ICustomerRepository customerRepository,
            ITempRepository _tempRepository, ICardRepository _cardRepository, ITempRepository tempRepository, ICardRepository cardRepository)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _customerRepository = customerRepository;
            _tempRepository = tempRepository;
            _cardRepository = cardRepository;
        }

    }
}
