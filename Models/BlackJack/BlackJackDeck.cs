using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Models;

namespace CardGames.Models.BlackJack
{
	class BlackJackDeck: Deck
	{
		public BlackJackDeck()
			:base()
		{
			
		}

		public BlackJackDeck(Card[] cards)
			: base(cards)
		{

		}
	}
}
