using AutoMapper;
using SATO.Application.Common.Model.Employee;
using SATO.Application.Interfaces;
using SATO.Entities.Entities;
using SATO.Infrastructure.Interfaces;
using SATO.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Application.Services
{
    public class TestDIScoped: ITestDIScoped,ITestDITransient,ITestDISingleton
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<SatoDbContext> _unitOfWork;

        public TestDIScoped(IUnitOfWork<SatoDbContext> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        Guid id = Guid.NewGuid(); 
        public string ListEmployee()
        {
            return id.ToString();
        }
    }
}
