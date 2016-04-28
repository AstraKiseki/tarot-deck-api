using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarotDeck.Core.Domain;

namespace TarotDeck.Infrastructure.Repository
{
    public class CardRepository : Repository<Card>, ICardRepository
    {
        public CardRepository(IDatabaseFactory databaseFactory) : base(databaseFactory)
        {
        }
    }
}
