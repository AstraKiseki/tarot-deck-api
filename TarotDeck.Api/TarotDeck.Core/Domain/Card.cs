using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarotDeck.Core.Models;

namespace TarotDeck.Core.Domain
{
    public enum CardNumber
    {

    }

    public class Card
    {
        public int CardId { get; set; }
        public int DeckId { get; set; }
        public string Suit { get; set; }
        public string Meaning { get; set; }
        public bool Reversed { get; set; }
        public string ReversedMeaning { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public CardNumber CardNumber { get; set; }

        public virtual Deck Deck { get; set; }

        public void Update(CardModel modelCard)
        {
            CardId = modelCard.CardId;
            Suit = modelCard.Description;
            Meaning = modelCard.Meaning;
            Reversed = modelCard.Reversed;
            ReversedMeaning = modelCard.ReversedMeaning;
            Image = modelCard.Image;
            Description = modelCard.Description;
            CardNumber CardNumber = modelCard.CardNumber;
        }
    }
}