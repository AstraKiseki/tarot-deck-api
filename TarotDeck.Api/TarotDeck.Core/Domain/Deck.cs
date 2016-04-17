using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarotDeck.Core.Models;

namespace TarotDeck.Core.Domain
{
    public class Deck
    {
        //primary key
        public int DeckId { get; set; }

        public string DeckName { get; set; }
        public string DeckType { get; set; }

        public virtual ICollection<Card> Cards { get; set; }

        public void Update(DeckModel modelDeck)
        {
            DeckId = modelDeck.DeckId;
            DeckName = modelDeck.DeckName;
            DeckType = modelDeck.DeckType;
        }
    }
}
