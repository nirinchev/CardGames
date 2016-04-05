using System.Windows.Controls;
using CardGames.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGames
{
    interface IBlackJackPlayer
    {
		int Score { get; }
        void TakeCard(Card card);
    }
}
