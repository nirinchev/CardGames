using CardGames.Models;

namespace CardGames
{
	interface IBlackJackPlayer
	{
		int Score { get; }

		void TakeCard(Card card);
	}
}
