using CardGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;


using CardGames.Views;
using Utils;
using Prism.Mvvm;
using CardGames.Models.BlackJack;
using CardGames.Managers;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Media;
using Prism.Commands;

namespace CardGames.ViewModels
{
	class BlackJackViewModel : BindableBase
    {
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

        public ObservableCollection<Image> Images { get; set; }
		
        public BlackJackViewModel()
        {
			Human = new BlackJackHumanPlayer();
			Computer = new BlackJackComputerPlayer();
            BlackJackGameManager = new BlackJackGameManager(Human, Computer);

			ClickCommand = new DelegateCommand(Hit);
			DealCommand = new DelegateCommand(Deal);
			StandCommand = new DelegateCommand(Stand, CanStand).ObservesProperty(()=>CanHit);
        }

		private bool CanStand()
		{
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
