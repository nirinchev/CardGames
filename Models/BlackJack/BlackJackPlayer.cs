using Utils;

namespace CardGames.Models.BlackJack
{
	class BlackJackPlayer : CardPlayer
	{
		private int score = 0;

		public int Score
		{
			get { return this.score; }
			set { SetProperty(ref this.score, value); }
		}

		protected int money = 0;
		public int Money
		{
			get { return this.money; }
			set { SetProperty(ref this.money, value); }
		}

		public BlackJackPlayer()
		{
			Money = 100;
		}

		public override void TakeCard(Card card)
		{
			if (card.Value == Values.Ace)
			{
				if (score + BlackJackCardPoints.CardPoints[card.ToString()] > 21)
				{
					Score += 1;
					base.TakeCard(card);
					return;
				}
			}
			Score = score + BlackJackCardPoints.CardPoints[card.ToString()];
			base.TakeCard(card);
		}

		public void GiveCards()
		{
			Score = 0;
			Deck = new BlackJackDeck(new Card[] { });
		}
	}
}
