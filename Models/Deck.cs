using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Utils;

namespace CardGames.Models
{
	class Deck
	{
		private readonly Random random = new Random();
		//public List<Card> cards = new List<Card>();
		public ObservableCollection<Card> Cards { get; private set; }

		// TODO: call the other constructor instead of duplicating the logic
		public Deck()
		{
			Cards = new ObservableCollection<Card>();
			for (int i = 0; i < 4; i++)
			{
				for (int v = 1; v < 13; v++)
				{
					Cards.Add(new Card((Values)v, (Suits)i));
				}
			}
		}

		public Deck(Card[] cards)
		{
			this.Cards = new ObservableCollection<Card>();
			foreach (Card card in cards)
			{
				this.Cards.Add(card);
			}
		}

		protected void LeaveOnly(Values[] valuesFilter)
		{
			Cards.Clear();
			for (int i = 0; i < 4; i++)
			{
				foreach (Values value in valuesFilter)
				{
					Cards.Add(new Card(value, (Suits)i));
				}
			}
		}

		public IEnumerable<Card> Filter(Values[] valuesFilter)
		{
			List<Card> filtered = new List<Card>();
			foreach (Card card in Cards)
			{
				if (Array.IndexOf(valuesFilter, card.Value) != -1)
				{
					filtered.Add(card);
				}
			}
			return filtered;
		}

		public IEnumerable<Card> Filter(Suits[] suitsFilter)
		{
			List<Card> filtered = new List<Card>();
			foreach (Card card in Cards)
			{
				if (Array.IndexOf(suitsFilter, card.Suit) != -1)
				{
					filtered.Add(card);
				}
			}
			return filtered;
		}

		public List<Card> Deal(int numberOfCards)
		{
			var Result = new List<Card>();
			for (int i = 0; i < numberOfCards; i++)
			{
				Result.Add(Cards[i]);
				Cards.RemoveAt(i);
			}
			return Result;
		}

		public Card Deal()
		{
			var Result = Cards[0];
			Cards.RemoveAt(0);
			return Result;
		}

		public void Shuffle()
		{
			ObservableCollection<Card> shuffledDeck = new ObservableCollection<Card>();
			while (Cards.Count > 0)
			{
				var randomIndex = random.Next(Cards.Count);
				shuffledDeck.Add(Cards[randomIndex]);
				Cards.RemoveAt(randomIndex);
			}
			Cards = shuffledDeck;
		}

		public virtual void AddCard(Card card)
		{
			Cards.Add(card);
		}

		public int Count()
		{
			return Cards.Count;
		}
	}
}
