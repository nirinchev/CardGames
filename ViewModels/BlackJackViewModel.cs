using System.Collections.ObjectModel;
using System.Windows.Controls;
using CardGames.Managers;
using CardGames.Models.BlackJack;
using Prism.Commands;
using Prism.Mvvm;

namespace CardGames.ViewModels
{
	class BlackJackViewModel : BindableBase
	{
		// TODO: this is a bad name :)
		public DelegateCommand ClickCommand { get; set; }
		public DelegateCommand DealCommand { get; set; }
		public DelegateCommand StandCommand { get; set; }

		public BlackJackHumanPlayer Human { get; private set; }
		public BlackJackComputerPlayer Computer { get; private set; }

		private bool canDeal = true;
		public bool CanDeal
		{
			get { return this.canDeal; }
			set { SetProperty(ref this.canDeal, value); }
		}
		private bool canHit = false;
		public bool CanHit
		{
			get { return this.canHit; }
			set { SetProperty(ref this.canHit, value); }
		}

		public BlackJackGameManager BlackJackGameManager { get; set; }

		// TODO: this is breaking MVVM :)
		public ObservableCollection<Image> Images { get; set; }

		public BlackJackViewModel()
		{
			Human = new BlackJackHumanPlayer();
			Computer = new BlackJackComputerPlayer();
			BlackJackGameManager = new BlackJackGameManager(Human, Computer);

			// TODO: why is there no CanExecute for those?
			ClickCommand = new DelegateCommand(Hit);
			DealCommand = new DelegateCommand(Deal);
			StandCommand = new DelegateCommand(Stand, CanStand).ObservesProperty(() => CanHit);
		}

		// TODO: use lambda, you don't need a named method for that.
		private bool CanStand()
		{
			// TODO: rewrite as return CanHit :)
			if (CanHit)
			{
				return true;
			}
			return false;
		}

		private void Hit()
		{
			BlackJackGameManager.Hit();
			CanDeal = BlackJackGameManager.CanDeal;
			CanHit = BlackJackGameManager.CanHit;
		}

		private void Deal()
		{
			BlackJackGameManager.Deal();
			CanDeal = BlackJackGameManager.CanDeal;
			CanHit = BlackJackGameManager.CanHit;
		}

		private void Stand()
		{
			BlackJackGameManager.Stand();
			CanDeal = BlackJackGameManager.CanDeal;
			CanHit = BlackJackGameManager.CanHit;
		}
	}
}
