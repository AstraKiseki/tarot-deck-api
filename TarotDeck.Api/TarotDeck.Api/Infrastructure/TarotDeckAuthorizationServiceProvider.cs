using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using TarotDeck.Core.Repository;

namespace TarotDeck.Api.Infrastructure
{
    public class TarotDeckAuthorizationServiceProvider : OAuthAuthorizationServerProvider
    {
        private Func<IAuthorizationRepository> _authRepositoryFactory;

        private IAuthorizationRepository _authRepository => _authRepositoryFactory.Invoke();

        public TarotDeckAuthorizationServerProvider(Func<IAuthorizationRepository> authRepositoryFactory)
        {
            _authRepositoryFactory = authRepositoryFactory;
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            await Task.Factory.StartNew(() =>
            {
                context.Validated();
            });
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            //Cors
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { "*" });

            //Validate the User
            var user = await _authRepository.FindUser(context.UserName, context.Password);

            if (user == null)
            {
                context.SetError("invalid_grant", "The username or password is incorrect");

                return;
            }

            var token = new ClaimsIdentity(context.Options.AuthenticationType);

            token.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            token.AddClaim(new Claim("role", "user"));

            context.Validated(token);

        }
    }
}