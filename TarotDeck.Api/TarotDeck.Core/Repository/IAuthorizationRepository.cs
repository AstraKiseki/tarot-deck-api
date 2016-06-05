using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarotDeck.Core.Repository
{
    public interface IAuthorizationRepository : IDisposable
    {
        Task<TarotDeckUser> FindUser(string username, string password);
        Task<IdentityResult> RegisterUser(RegistrationModel model);
    }
}
