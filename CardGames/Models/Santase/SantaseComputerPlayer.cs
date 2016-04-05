using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Utils;

namespace CardGames.Models.Santase
{
	class SantaseComputerPlayer : SantasePlayer, ISantaseCardPlayer
	{
		Random randomBehaviour = new Random();

		int[] cardRatings;


		public override void TakeCard(Card card)
		{
			base.TakeCard(card);
		}

		public async Task PlayCard()
		{
		    Task.Delay(200);
			cardRatings = new int[Deck.Cards.Count];
			if (GameField.HumanCardPlayed == null)
			{
				PlayFirst();
			}
			else
			{
				PlaySecond();
			}
		}

		private void PlayFirst()
		{
			PlayCard(Deck.Cards[randomBehaviour.Next(Deck.Cards.Count)]);
		}

		private void PlaySecond()
		{
			for (int i = 0; i < Deck.Cards.Count; i++)
			{
				if (GetCardPower(Deck.Cards[i]) > GetCardPower(GameField.HumanCardPlayed))
				{
					if (Deck.Cards[i].Suit == GameField.HumanCardPlayed.Suit)
					{
						cardRatings[i] = CanTakeRegular(Deck.Cards[i]);
					}
					else
					{
						cardRatings[i] = CanTakeForce(Deck.Cards[i]);
					}
				}
				else
				{
					cardRatings[i] = CantTakeCard(Deck.Cards[i]);
				}
			}
			var cardToPlayIndex = cardRatings.ToList().IndexOf(cardRatings.Max());
			PlayCard(Deck.Cards[cardToPlayIndex]);
		}

		private int CantTakeCard(Card card)
		{
			int cardRating = 0;
			if (CheckForCouple(card))
			{
				cardRating -= 20;
			}
			if (SantaseCardPoints.CardPoints[card.ToString()] <= 4)
			{
				cardRating += 30;
			}
			else
			{
				cardRating -= 50;
			}
			return cardRating;
		}

		private bool CheckForPowerPair()
		{
			bool found = false;
			if (GameField.PowersCard.Value == Values.King || GameField.PowersCard.Value == Values.Queen) 
			{
				foreach (Card card in Deck.Cards)
				{
					if (card.Value == Values.King || card.Value == Values.Queen)
					{
						found = true;
					}
				}
			}
			return found;
		}

		private bool CheckForCouple(Card card)
		{
			bool found = false;
			foreach (Card cardCouple in Deck.Cards)
			{
				if (card.Suit == cardCouple.Suit)
				{
					if(card.Value == Values.Queen)
					{
						if (cardCouple.Value == Values.King)
						{
							found = true;
						}
					}
					else
					{
						if (cardCouple.Value == Values.Queen)
						{
							found = true;
						}
					}
				}
			}
			return found;
		}

		private int CanTakeForce(Card card)
		{
			int cardRating = 0;
			if (card.Value != Values.Ace && card.Value != Values.Ten)
			{
				if (card.Value == Values.Nine)
				{
					if(CheckForPowerPair())
					{
						cardRating -= 40;
					}
					if (SantaseCardPoints.CardPoints[GameField.HumanCardPlayed.ToString()] > 4)
					{
						cardRating += 90;
					}
					else
					{
						cardRating += 30;
					}
				}
				else if (card.Value == Values.Jack)
				{
					if (SantaseCardPoints.CardPoints[GameField.HumanCardPlayed.ToString()] > 4)
					{
						cardRating += 80;
					}
					else
					{
						cardRating += 20;
					}
				}
				else if (card.Value == Values.Queen)
				{
					if (CheckForCouple(card))
					{
						cardRating -= 40;
					}
					if (SantaseCardPoints.CardPoints[GameField.HumanCardPlayed.ToString()] > 4)
					{
						cardRating += 70;
					}
					else
					{
						cardRating += 10;
					}
				}
				else if (card.Value == Values.King)
				{
					if (CheckForCouple(card))
					{
						cardRating -= 40;
					}
					if (SantaseCardPoints.CardPoints[GameField.HumanCardPlayed.ToString()] > 4)
					{
						cardRating += 60;
					}
					else
					{
						cardRating += 0;
					}
				}
			}
			else
			{
				if (SantaseCardPoints.CardPoints[GameField.HumanCardPlayed.ToString()] > 4)
				{
					cardRating += 95;
				}
				else
				{
					cardRating += 5;
				}
			}
			return cardRating;
		}

		private int CanTakeRegular(Card card)
		{
			int cardRating = 10;
			if (SantaseCardPoints.CardPoints[GameField.HumanCardPlayed.ToString()] > 4)
			{
				cardRating += 95;
			}
			else
			{
				cardRating += 5;
			}
			return cardRating;
		}

		private void PlayCard(Card card)
		{
			Card cardClone = new Card(card.Value, card.Suit);
			Deck.Cards.Remove(card);
			GameField.ComputerCardPlayed = cardClone;
		}
	}
}
