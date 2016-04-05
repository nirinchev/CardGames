using System;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Utils;

namespace CardGames.Models
{
	class Card
	{
		private Values value;
		private Suits suit;

		// TODO: convert to c# 6 getter only property
		public Values Value
		{
			get
			{
				return value;
			}
		}

		public Suits Suit
		{
			get
			{
				return suit;
			}
		}

		public Uri Uri { get; set; }

		// TODO: this is breaking MVVM. You are exposing view-related properties in your model
		public Image Image { get; set; }

		public Image BackImage { get; set; }

		public Card(Values value, Suits suit)
		{
			this.value = value;
			this.suit = suit;
			var picPath = Infos.CardMapping[this.suit.ToString() + this.value.ToString()];
			var newImage = new Image();
			Uri = new Uri(@"../Resources/" + picPath + ".png", UriKind.Relative);
			newImage.Source = new BitmapImage(Uri);
			Image = newImage;
			BackImage = Infos.CardBackImage();
		}

		public override string ToString()
		{
			return this.suit.ToString() + this.value.ToString();
		}
	}
}
