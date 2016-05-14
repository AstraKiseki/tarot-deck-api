using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;
using TarotDeck.Api.Infrastructure;
using TarotDeck.Core.Infrastructure;
using TarotDeck.Core.Models;
using TarotDeck.Core.Repository;

namespace TarotDeck.Api.Controllers
{
{
    public class CardsController : BaseApiController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICardRepository _cardRepository;

        public CardsController(IUnitOfWork unitOfWork, ICardRepository cardRepository) : base(cardRepository)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: api/Cards
        public IEnumerable<CardModel> GetCards()
        {
            return Mapper.Map<IEnumerable<CardModel>>(_cardRepository.GetAll());
        }

        // GET: api/Cards/5
        [ResponseType(typeof(CardModel))]
        public IHttpActionResult GetCard(int id)
        {
            Card Card = _cardRepository.GetById(id);

            if (Card == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<CardModel>(Card));
        }

        // PUT: api/Cards/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCard(int id, CardModel modelCard)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != modelCard.CardId)
            {
                return BadRequest();
            }

            var dbCard = _cardRepository.GetById(id);
            dbCard.Update(modelCard);
            _cardRepository.Update(dbCard);

            try
            {
                _unitOfWork.Commit();
            }
            catch (Exception)
            {
                if (!CardExists(id))
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

        // POST: api/Cards
        [ResponseType(typeof(CardModel))]
        public IHttpActionResult PostCard(CardModel Card)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCard = new Card();
            newCard.Update(Card);

            _cardRepository.Add(newCard);
            _unitOfWork.Commit();

            Card.CardId = newCard.Id;

            return CreatedAtRoute("DefaultApi", new { id = Card.CardId }, Card);
        }

        // DELETE: api/Cards/5
        [ResponseType(typeof(CardModel))]
        public IHttpActionResult DeleteCard(int id)
        {
            Card Card = _cardRepository.GetById(id);
            if (Card == null)
            {
                return NotFound();
            }

            _cardRepository.Delete(Card);
            _unitOfWork.Commit();

            return Ok(Mapper.Map<CardModel>(Card));
        }

        private bool CardExists(int id)
        {
            return _cardRepository.Any(u => u.Id == id);
        }
    }
}
}
