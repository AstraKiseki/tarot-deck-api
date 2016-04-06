using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TarotDeck.Core.Domain
{
    public enum CardNumber
    {
        // Intended to go 0 - 22 to allow for the Major Arcana
    }
    public class Card
    {
        public string Suit { get; set; }
        public string Meaning { get; set; }
        public bool Reversed { get; set; }
        public string ReversedMeaning { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public CardNumber CardNumber { get; set; }
    }
}
