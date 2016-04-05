using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using CardGames.Models;
using Utils;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace CardGames.Models.Santase
{
	class SantaseHumanPlayer : SantasePlayer, ISantaseCardPlayer
    {
		public void PlayCard(Card card)
		{
			Deck.Cards.Remove(card);
			GameField.HumanCardPlayed = card;
		}
    }
}
