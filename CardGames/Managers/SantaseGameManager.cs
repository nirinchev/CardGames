using CardGames.Models;
using CardGames.Models.Santase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace CardGames.Managers
{
	class SantaseGameManager
	{
		public SantaseDeck SantaseDeck = new SantaseDeck();
		SantaseHumanPlayer Human;
		SantaseComputerPlayer Computer;
		public SantaseGameField GameField = new SantaseGameField();
		private bool myTurn = true;
		public bool MyTurn { get { return myTurn; } private set { myTurn = value; } }

		public SantaseGameManager(SantaseHumanPlayer human, SantaseComputerPlayer computer)
		{
			this.Human = human;
			this.Human.GameField = GameField;
			this.Computer = computer;
			this.Computer.GameField = GameField;
		}

		public async Task StartGame()
		{
			SantaseDeck = new SantaseDeck();
			SantaseDeck.Shuffle();
			for (int i = 0; i < 5; i++)
			{

				await TakeCards();
			}
			GameField.PowersCard = SantaseDeck.Deal();
		}


		public int GetCardPower(Card card)
		{
			if (card.Suit == GameField.PowersCard.Suit)
			{
				return 100 + SantaseCardPoints.CardPoints[card.ToString()];
			}
			return SantaseCardPoints.CardPoints[card.ToString()];
		}

		public async Task PlayCards(Card card)
		{
			Human.PlayCard(card);
			await Task.Delay(700);
			Computer.PlayCard();
		}

		public async Task<bool> DetermineWinner()
		{
			var DoWin = false;
			await Task.Delay(700);
			if (GameField.ComputerCardPlayed.Suit == GameField.HumanCardPlayed.Suit)
			{
				if (GetCardPower(GameField.ComputerCardPlayed) > GetCardPower(GameField.HumanCardPlayed))
				{
					Computer.TakeWinningCards();
				}
				else
				{
					DoWin = true;
					Human.TakeWinningCards();
				}
			}
			else
			{
				if (GameField.ComputerCardPlayed.Suit == GameField.PowersCard.Suit)
				{
					Computer.TakeWinningCards();
				}
				else if (GameField.HumanCardPlayed.Suit == GameField.PowersCard.Suit)
				{
					DoWin = true;
					Human.TakeWinningCards();
				}
				else
				{
					if (MyTurn)
					{
						DoWin = true;
						Human.TakeWinningCards();
					}
					else
					{
						Computer.TakeWinningCards();
					}
				}
			}

			MyTurn = DoWin;
			return DoWin;
		}

		public async Task TakeCards()
		{
			await Task.Delay(100);
			if (this.SantaseDeck.Count() > 1)
			{
				var card = SantaseDeck.Deal();
				var card1 = SantaseDeck.Deal();
				Console.WriteLine(card);
				Human.TakeCard(card);
				Console.WriteLine(card1);
				Computer.TakeCard(card1);
				await Task.Delay(100);
			}
		}
	}
}
