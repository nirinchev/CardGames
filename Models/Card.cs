using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using Utils;

namespace CardGames.Models
{
	class Card
	{
		private Values value;
		private Suits suit;

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

		public Uri Uri{get;set;}

		public Image Image{get;set;}

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
