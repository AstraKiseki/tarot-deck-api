using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarotDeck.Core.Domain;

namespace TarotDeck.Core.Models
{
    public class CardModel
    {
            public int CardId { get; set; }
            public string Suit { get; set; }
            public string Meaning { get; set; }
            public bool Reversed { get; set; }
            public string ReversedMeaning { get; set; }
            public string Image { get; set; }
            public string Description { get; set; }
            public CardNumber CardNumber { get; set; }
    }
}