using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TarotDeck.Core.Repository;

namespace TarotDeck.Api.Infrastructure
{
    public class BaseApiController : ApiController
    {
        private ICardRepository cardRepository;
        private IDeckRepository deckRepository;

        public BaseApiController(IDeckRepository deckRepository)
        {
            this.deckRepository = deckRepository;
        }

        public BaseApiController(ICardRepository cardRepository)
        {
            this.cardRepository = cardRepository;
        }
    }
}
