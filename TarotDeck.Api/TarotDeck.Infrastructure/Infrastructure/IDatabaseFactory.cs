using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarotDeck.Infrastructure.Infrastructure
{
    public interface IDatabaseFactory : IDisposable
    {
        TarotDeckDataContext GetDataContext();
    }
}
