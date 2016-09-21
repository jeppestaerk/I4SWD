using CardGame.Players;

namespace CardGame.Games
{
    // This "high total wins" is a variant (derivative) of the generic game. Therefore, it inherits from 
    // the generic Game class and implements FindWinner() in its own, game-variant-specific way
    public class HighTotalWinsGame : Game
    {
        public override IPlayer FindWinner()
        {
            if (Players.Count == 0) throw new CardGameException("No players added to game");
            var winner = Players[0];

            foreach (var player in Players)
            {
                if (player.GetHandTotal() > winner.GetHandTotal())
                    winner = player;
            }

            CurrentGameState = GameState.GameNotStarted;

            return winner;
        }
    }
}
