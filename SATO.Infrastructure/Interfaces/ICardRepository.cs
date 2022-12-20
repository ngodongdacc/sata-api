using SATO.Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SATO.Infrastructure.Interfaces
{
    public interface ICardRepository
    {
        List<Card> GetCardByUser();
    }
}
