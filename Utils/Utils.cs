using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Utils;

namespace CardGames
{
	class Infos
	{
		public static IDictionary<string, string> CardMapping = new Dictionary<string, string>() { 
			{Suits.Clubs.ToString() +   Values.Ace.ToString(), "c1"},
			{Suits.Clubs.ToString() +   Values.Two.ToString(), "c2"},
			{Suits.Clubs.ToString() + Values.Three.ToString(), "c3"},
			{Suits.Clubs.ToString() +  Values.Four.ToString(), "c4"},
			{Suits.Clubs.ToString() +  Values.Five.ToString(), "c5"},
			{Suits.Clubs.ToString() +   Values.Six.ToString(), "c6"},
			{Suits.Clubs.ToString() + Values.Seven.ToString(), "c7"},
			{Suits.Clubs.ToString() + Values.Eight.ToString(), "c8"},
			{Suits.Clubs.ToString() +  Values.Nine.ToString(), "c9"},
			{Suits.Clubs.ToString() +   Values.Ten.ToString(), "c10"},
			{Suits.Clubs.ToString() +  Values.Jack.ToString(), "cj"},
			{Suits.Clubs.ToString() + Values.Queen.ToString(), "cq"},
			{Suits.Clubs.ToString() +  Values.King.ToString(), "ck"},
			{Suits.Hearts.ToString() +   Values.Ace.ToString(), "h1"},
			{Suits.Hearts.ToString() +   Values.Two.ToString(), "h2"},
			{Suits.Hearts.ToString() + Values.Three.ToString(), "h3"},
			{Suits.Hearts.ToString() +  Values.Four.ToString(), "h4"},
			{Suits.Hearts.ToString() +  Values.Five.ToString(), "h5"},
			{Suits.Hearts.ToString() +   Values.Six.ToString(), "h6"},
			{Suits.Hearts.ToString() + Values.Seven.ToString(), "h7"},
			{Suits.Hearts.ToString() + Values.Eight.ToString(), "h8"},
			{Suits.Hearts.ToString() +  Values.Nine.ToString(), "h9"},
			{Suits.Hearts.ToString() +   Values.Ten.ToString(), "h10"},
			{Suits.Hearts.ToString() +  Values.Jack.ToString(), "hj"},
			{Suits.Hearts.ToString() + Values.Queen.ToString(), "hq"},
			{Suits.Hearts.ToString() +  Values.King.ToString(), "hk"},
			{Suits.Diamonds.ToString() +   Values.Ace.ToString(), "d1"},
			{Suits.Diamonds.ToString() +   Values.Two.ToString(), "d2"},
			{Suits.Diamonds.ToString() + Values.Three.ToString(), "d3"},
			{Suits.Diamonds.ToString() +  Values.Four.ToString(), "d4"},
			{Suits.Diamonds.ToString() +  Values.Five.ToString(), "d5"},
			{Suits.Diamonds.ToString() +   Values.Six.ToString(), "d6"},
			{Suits.Diamonds.ToString() + Values.Seven.ToString(), "d7"},
			{Suits.Diamonds.ToString() + Values.Eight.ToString(), "d8"},
			{Suits.Diamonds.ToString() +  Values.Nine.ToString(), "d9"},
			{Suits.Diamonds.ToString() +   Values.Ten.ToString(), "d10"},
			{Suits.Diamonds.ToString() +  Values.Jack.ToString(), "dj"},
			{Suits.Diamonds.ToString() + Values.Queen.ToString(), "dq"},
			{Suits.Diamonds.ToString() +  Values.King.ToString(), "dk"},
			{Suits.Spades.ToString() +   Values.Ace.ToString(), "s1"},
			{Suits.Spades.ToString() +   Values.Two.ToString(), "s2"},
			{Suits.Spades.ToString() + Values.Three.ToString(), "s3"},
			{Suits.Spades.ToString() +  Values.Four.ToString(), "s4"},
			{Suits.Spades.ToString() +  Values.Five.ToString(), "s5"},
			{Suits.Spades.ToString() +   Values.Six.ToString(), "s6"},
			{Suits.Spades.ToString() + Values.Seven.ToString(), "s7"},
			{Suits.Spades.ToString() + Values.Eight.ToString(), "s8"},
			{Suits.Spades.ToString() +  Values.Nine.ToString(), "s9"},
			{Suits.Spades.ToString() +   Values.Ten.ToString(), "s10"},
			{Suits.Spades.ToString() +  Values.Jack.ToString(), "sj"},
			{Suits.Spades.ToString() + Values.Queen.ToString(), "sq"},
			{Suits.Spades.ToString() +  Values.King.ToString(), "sk"},

		};

		public static Image CardBackImage()
		{
			var newImage = new Image();
			var Uri = new Uri(@"../Resources/player.png", UriKind.Relative);
			newImage.Source = new BitmapImage(Uri);
			return newImage;
		}
	}
}
