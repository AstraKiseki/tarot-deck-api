using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TarotDeck.Api.Controllers
{
    public class DecksController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public DecksController(IUnitOfWork unitOfWork, IDeckRepository deckRepository) : base(deckRepository)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Decks
        public IEnumerable<DeckModel> GetDecks()
        {
            return Mapper.Map<IEnumerable<DeckModel>>(_deckRepository.GetAll());
        }

        // GET: api/Decks/5
        [ResponseType(typeof(DeckModel))]
        public IHttpActionResult GetDeck(int id)
        {
            Deck Deck = _deckRepository.GetById(id);

            if (Deck == null)
            {
                return NotFound();
            }
            return Ok(Mapper.Map<DeckModel>(Deck));
        }

        // PUT: api/Decks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDeck(int id, DeckModel modelDeck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelDeck.Id)
            {
                return BadRequest();
            }

            var dbDeck = _deckRepository.GetById(id);
            dbDeck.Update(modelDeck);
            _deckRepository.Update(dbDeck);

            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                if (!DeckExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Decks
        [ResponseType(typeof(DeckModel))]
        public IHttpActionResult PostDeck(DeckModel Deck)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newDeck = new Deck();
            newDeck.Update(Deck);

            _deckRepository.Add(newDeck);
            _unitOfWork.Commit();

            Deck.Id = newDeck.Id;

            return CreatedAtRoute("DefaultApi", new { id = Deck.Id }, Deck);
        }

        // DELETE: api/Decks/5
        [ResponseType(typeof(DeckModel))]
        public IHttpActionResult DeleteDeck(int id)
        {
            Deck Deck = _deckRepository.GetById(id);
            if (Deck == null)
            {
                return NotFound();
            }

            _deckRepository.Delete(Deck);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<DeckModel>(Deck));
        }

        private bool DeckExists(int id)
        {
            return _deckRepository.Any(u => u.Id == id);
        }
    }
}