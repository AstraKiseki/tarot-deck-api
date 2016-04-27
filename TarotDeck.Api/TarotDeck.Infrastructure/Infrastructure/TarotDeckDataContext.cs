using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TarotDeck.Core.Domain;

public class TarotDeckDataContext : DbContext
{
    public TarotDeckDataContext() : base("TarotDeck")
    {
        var ensureDllIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
    }

    //SQL Tables
    public IDbSet<Deck> Decks { get; set; }
    public IDbSet<Card> Cards { get; set; }

    //Model Relationships
    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        //Deck
        modelBuilder.Entity<Deck>()
                    .HasMany(d => d.Cards)
                    .WithRequired(c => c.Deck)
                    .HasForeignKey(c => c.DeckId);

        base.OnModelCreating(modelBuilder);
    }
}

