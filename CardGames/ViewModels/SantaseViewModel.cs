using CardGames.Managers;
using CardGames.Models;
using CardGames.Models.Santase;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace CardGames.ViewModels
{
	class SantaseViewModel: BindableBase
	{
		public SantaseComputerPlayer Computer { get; set; }
		public SantaseHumanPlayer Human { get; set; }

		private string message = "To start the game click Start button";
		public string Message
		{
			get { return this.message; }
			set { SetProperty(ref this.message, value); }
		}

		private Card powersCard;
		public Card PowersCard
		{
			get { return this.powersCard; }
			set { SetProperty(ref this.powersCard, value); }
		}

		private bool enablePlay = true;
		public bool EnablePlay
		{
			get { return this.enablePlay; }
			set { SetProperty(ref this.enablePlay, value); }
		}
		public DelegateCommand StartGame { get; set; }
        public DelegateCommand<int?> PlayCardCommand { get; set; }

		private SantaseGameManager santaseGameManager;
		private Card playerCard;
		public Card PlayerCard
		{
			get { return playerCard; }
			set {
				Card cardClone = new Card(value.Value, value.Suit);
				Human.Deck.Cards.Remove(value);
                PlayerCardLocalSet = cardClone;
                PlayCardGM(cardClone);
			}
		}

        public Card PlayerCardLocalSet
        {
            get { return playerCard; }
            set
            {
                SetProperty(ref playerCard, value);
            }
        }

		private Card compCard;
		public Card CompCard
		{
			get { return compCard; }
			set
			{
				SetProperty(ref compCard, value);
			}
		}

		public SantaseViewModel()
		{
			Human = new SantaseHumanPlayer();
			Computer = new SantaseComputerPlayer();
			santaseGameManager = new SantaseGameManager(Human, Computer);
			StartGame = new DelegateCommand(StartGameGM);
		}


        private async void StartGameGM()
        {
            await santaseGameManager.StartGame();
            PowersCard = santaseGameManager.GameField.PowersCard;
        }

		private async Task PlayCardGM(Card card)
		{
			EnablePlay = false;
			Human.PlayCard(card);
            await Task.Delay(700);
            if (santaseGameManager.MyTurn)
            {
                CompPlay();
            }
            await Task.Delay(1500);
            var winner = await santaseGameManager.DetermineWinner();

            Message = string.Format("{0} has won with {1}", winner ? "Player" : "Computer",
                (winner ? santaseGameManager.GameField.HumanCardPlayed.Value.ToString() : santaseGameManager.GameField.ComputerCardPlayed.Value.ToString()) +
                " " +
                (winner ? santaseGameManager.GameField.HumanCardPlayed.Suit.ToString() : santaseGameManager.GameField.ComputerCardPlayed.Suit.ToString()));
            CompCard = santaseGameManager.GameField.HumanCardPlayed = null;
            PlayerCardLocalSet = santaseGameManager.GameField.ComputerCardPlayed = null;
            if (santaseGameManager.SantaseDeck.Cards.Count == 2)
            {
                PowersCard = null;
            }
            await santaseGameManager.TakeCards();
            if (Human.Deck.Count() == 0 && Computer.Deck.Count() == 0)
            {
                Message = string.Format("Game has ended and the winner is {0} with {1} points",
                    Computer.Score > Human.Score ? "Computer" : "Human",
                    Computer.Score > Human.Score ? Computer.Score.ToString() : Human.Score.ToString());
            }
            if (!winner)
            {
                CompPlay();
            }
            EnablePlay = true;
		}

		private async void CompPlay()
		{
			await Computer.PlayCard();
			CompCard = santaseGameManager.GameField.ComputerCardPlayed;
			PowersCard = santaseGameManager.GameField.PowersCard;
		}
	}
}
