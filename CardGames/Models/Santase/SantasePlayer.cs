using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CardGames.Models.Santase
{
	class SantasePlayer: CardPlayer
	{
		private int score = 0;

		public SantaseGameField GameField { get; set; }

		public List<Card> WinCards = new List<Card>();
 
		public int Score
		{
			get { return this.score; }
			set { SetProperty(ref this.score, value); }
		}

        public override void TakeCard(Card card)
        {
            base.TakeCard(card);
        }

		public void TakeWinningCards()
		{
			WinCards.Add(GameField.HumanCardPlayed);
			Score += SantaseCardPoints.CardPoints[GameField.HumanCardPlayed.ToString()];
			WinCards.Add(GameField.ComputerCardPlayed);
			Score += SantaseCardPoints.CardPoints[GameField.ComputerCardPlayed.ToString()];
		}

		protected bool IsPowerCard(Card card)
		{
			if (card.Suit == GameField.PowersCard.Suit)
			{
				return true;
			}
			return false;
		}

		public void GiveCards(){
			Score = 0;
			Deck = new SantaseDeck(new Card[]{});
		}

		protected int GetCardPower(Card card)
		{
			if (card.Suit == GameField.PowersCard.Suit)
			{
				return 100 + SantaseCardPoints.CardPoints[card.ToString()];
			}
			return SantaseCardPoints.CardPoints[card.ToString()];
		}

	}
}
