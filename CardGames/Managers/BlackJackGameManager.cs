using System.Collections.ObjectModel;
using CardGames.Models;
using CardGames.Models.BlackJack;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Threading;

namespace CardGames.Managers
{
	class BlackJackGameManager 
	{
		public BlackJackHumanPlayer Human{ get; private set; }
		public BlackJackComputerPlayer Computer{ get; private set; }
		public bool CanDeal { get; set; }
		public bool CanHit { get; set; }
		private BlackJackDeck deck = new BlackJackDeck();

	    public BlackJackGameManager(BlackJackHumanPlayer human, BlackJackComputerPlayer computer)
		{
			Computer = computer;
			Human = human;
			deck.Shuffle();
			GameEnded();
		}

		public Card Hit()
		{
			var hitted = Hit(Human);
			if(Human.Score > 21){
				GameWinner("You lose");
			}
			else if (Human.Score == 21)
			{
				GameWinner("You win");
			}
		    return hitted;
		}

		private Card Hit(IBlackJackPlayer player)
		{
			Card CardTaken = deck.Deal();
			player.TakeCard(CardTaken);
		    return CardTaken;
		}

		private void GameEnded()
		{
			CanDeal = true;
			CanHit = false;
		}

		public void Stand()
		{
			for (int i = 0; i < 9; i++)
			{
				if (Computer.Score < Human.Score)
				{
					Thread.Sleep(900);
					var cardTaken = Hit(Computer);

					Application.Current.Dispatcher.Invoke(DispatcherPriority.Background,
														  new Action(delegate { }));

					if (Computer.Score > 21)
					{
						GameWinner("You win");
						break;
					}
				}
				else if (Computer.Score == Human.Score)
				{
					if(Human.Score > 17){
						GameWinner("Draw");
						break;
					}
				}
				else if (Computer.Score > Human.Score)
				{
					GameWinner("You lose");
					break;
				}
			}
		}

		private void GameWinner(string winnerText){
			if (winnerText == "Draw")
			{
				Human.Money += 5;
			}
			else if (winnerText == "You win") 
			{
				Human.Money += 10;
			}
			MessageBox.Show(winnerText);
			GameEnded();
		}

		public void Deal()
		{
			if (Human.Money < 0)
			{
				MessageBox.Show("You totaly lost bro. Can't play again :(");
				return;
			}
			Human.Money -= 5;
			Human.GiveCards();
			CanDeal = false;
			CanHit = true;
			Computer.GiveCards();
			//while (Computer.Cards.Count > 0)
			//{
			//	Computer.Cards.RemoveAt(0);
			//}
			//while (Human.Cards.Count > 0)
			//{
			//	Human.Cards.RemoveAt(0);
			//}


			deck = new BlackJackDeck();
			deck.Shuffle();
			for (int i = 0; i < 2; i++)
			{
				Hit();
			}

		}
	}
}
