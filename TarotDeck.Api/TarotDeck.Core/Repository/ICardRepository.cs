using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarotDeck.Core.Domain;
using TarotDeck.Core.Infrastructure;

namespace TarotDeck.Core.Repository
{
    public interface ICardRepository : IRepository<Card>
    {
    }
}