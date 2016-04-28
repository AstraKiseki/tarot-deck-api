using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarotDeck.Core.Infrastructure;

namespace TarotDeck.Infrastructure.Infrastructure
{
    public class DatabaseFactory : Disposable, IDatabaseFactory
    {
        private readonly TarotDeckDataContext _dataContext;

        public TarotDeckDataContext GetDataContext()
        {
            return _dataContext ?? new TarotDeckDataContext();
        }

        public DatabaseFactory()
        {
            _dataContext = new TarotDeckDataContext();
        }

        protected override void DisposeCore()
        {
            if (_dataContext != null) _dataContext.Dispose();
        }
    }
}
