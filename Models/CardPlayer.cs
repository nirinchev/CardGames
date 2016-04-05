using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Models;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Controls;
using Prism.Mvvm;

namespace CardGames.Models
{
	abstract class CardPlayer : BindableBase
    {

		protected Deck deck = new Deck(new Card[] { });

		public Deck Deck
		{
			get { return this.deck; }
			set { SetProperty(ref this.deck, value); }
		}

        
        public virtual void TakeCard(Card card)
        {
			Deck.AddCard(card);
        }
    }
}
