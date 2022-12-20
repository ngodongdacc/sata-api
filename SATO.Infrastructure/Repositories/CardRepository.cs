using SATO.Entities.Entities;
using SATO.Infrastructure.Interfaces;
using SATO.Infrastructure.Presistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Infrastructure.Repositories
{
    public class CardRepository:ICardRepository
    {
        private readonly SatoDbContext _dbContext;

        public CardRepository(SatoDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public List<Card> GetCardByUser()
        {
            return _dbContext.Cards.ToList();
        }
    }
}
