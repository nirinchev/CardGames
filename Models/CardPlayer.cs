using Prism.Mvvm;

namespace CardGames.Models
{
	// This is a view model, should be renamed to have a ViewModel suffix. Also, since it's an abstract class, should be CardPlayerViewModelBase
	abstract class CardPlayer : BindableBase
	{
		protected Deck deck = new Deck(new Card[0]);

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