using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils;

namespace CardGames.Models.BlackJack
{
    class BlackJackCardPoints
    {
        public static IDictionary<string, int> CardPoints = new Dictionary<string, int>() { 
			{Suits.Clubs.ToString() +   Values.Ace.ToString(), 11},
			{Suits.Clubs.ToString() +   Values.Two.ToString(), 2 },
			{Suits.Clubs.ToString() + Values.Three.ToString(), 3 },
			{Suits.Clubs.ToString() +  Values.Four.ToString(), 4 },
			{Suits.Clubs.ToString() +  Values.Five.ToString(), 5 },
			{Suits.Clubs.ToString() +   Values.Six.ToString(), 6 },
			{Suits.Clubs.ToString() + Values.Seven.ToString(), 7 },
			{Suits.Clubs.ToString() + Values.Eight.ToString(), 8 },
			{Suits.Clubs.ToString() +  Values.Nine.ToString(), 9 },
			{Suits.Clubs.ToString() +   Values.Ten.ToString(), 10},
			{Suits.Clubs.ToString() +  Values.Jack.ToString(), 10},
			{Suits.Clubs.ToString() + Values.Queen.ToString(), 10},
			{Suits.Clubs.ToString() +  Values.King.ToString(), 10},
			{Suits.Hearts.ToString() +   Values.Ace.ToString(), 11},
			{Suits.Hearts.ToString() +   Values.Two.ToString(), 2 },
			{Suits.Hearts.ToString() + Values.Three.ToString(), 3 },
			{Suits.Hearts.ToString() +  Values.Four.ToString(), 4 },
			{Suits.Hearts.ToString() +  Values.Five.ToString(), 5 },
			{Suits.Hearts.ToString() +   Values.Six.ToString(), 6 },
			{Suits.Hearts.ToString() + Values.Seven.ToString(), 7 },
			{Suits.Hearts.ToString() + Values.Eight.ToString(), 8 },
			{Suits.Hearts.ToString() +  Values.Nine.ToString(), 9 },
			{Suits.Hearts.ToString() +   Values.Ten.ToString(), 10},
			{Suits.Hearts.ToString() +  Values.Jack.ToString(), 10},
			{Suits.Hearts.ToString() + Values.Queen.ToString(), 10},
			{Suits.Hearts.ToString() +  Values.King.ToString(), 10},
			{Suits.Diamonds.ToString() +   Values.Ace.ToString(), 11},
			{Suits.Diamonds.ToString() +   Values.Two.ToString(), 2 },
			{Suits.Diamonds.ToString() + Values.Three.ToString(), 3 },
			{Suits.Diamonds.ToString() +  Values.Four.ToString(), 4 },
			{Suits.Diamonds.ToString() +  Values.Five.ToString(), 5 },
			{Suits.Diamonds.ToString() +   Values.Six.ToString(), 6 },
			{Suits.Diamonds.ToString() + Values.Seven.ToString(), 7 },
			{Suits.Diamonds.ToString() + Values.Eight.ToString(), 8 },
			{Suits.Diamonds.ToString() +  Values.Nine.ToString(), 9 },
			{Suits.Diamonds.ToString() +   Values.Ten.ToString(), 10},
			{Suits.Diamonds.ToString() +  Values.Jack.ToString(), 10},
			{Suits.Diamonds.ToString() + Values.Queen.ToString(), 10},
			{Suits.Diamonds.ToString() +  Values.King.ToString(), 10},
			{Suits.Spades.ToString() +   Values.Ace.ToString(), 11},
			{Suits.Spades.ToString() +   Values.Two.ToString(), 2 },
			{Suits.Spades.ToString() + Values.Three.ToString(), 3 },
			{Suits.Spades.ToString() +  Values.Four.ToString(), 4 },
			{Suits.Spades.ToString() +  Values.Five.ToString(), 5 },
			{Suits.Spades.ToString() +   Values.Six.ToString(), 6 },
			{Suits.Spades.ToString() + Values.Seven.ToString(), 7 },
			{Suits.Spades.ToString() + Values.Eight.ToString(), 8 },
			{Suits.Spades.ToString() +  Values.Nine.ToString(), 9 },
			{Suits.Spades.ToString() +   Values.Ten.ToString(), 10},
			{Suits.Spades.ToString() +  Values.Jack.ToString(), 10},
			{Suits.Spades.ToString() + Values.Queen.ToString(), 10},
			{Suits.Spades.ToString() +  Values.King.ToString(), 10},

		};
    }
}
