using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CardGames.Models;
using Utils;

namespace CardGames.Models.Santase
{
	class SantaseDeck: Deck
	{
		public SantaseDeck()
			: base()
		{
			Values[] valuesFilter = new Values[]{
				Values.Ace,
				Values.Ten,
				Values.King,
				Values.Queen,
				Values.Jack,
				Values.Nine
			};
			LeaveOnly(valuesFilter);
		}

		public SantaseDeck(Card[] cards)
			: base(cards)
		{
		}
	}
}
