using SATO.Entities.Entities;
using SATO.Infrastructure.Interfaces;
using SATO.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Infrastructure.Repositories
{
    public class TempRepository:ITempRepository
    {
        public readonly SatoDbContext _dbContext;
        public TempRepository(SatoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Temp> GetTempByDate(string date)
        {
            var da = DateTime.Parse(date);
            var data = _dbContext.Temps.AsNoTracking().Where(x => x.AccessTime == da).ToList();
            return data;
        }
    }
}
