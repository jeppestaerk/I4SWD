using System.Collections.Generic;
using CardGame.Players;


namespace CardGame.Games
{
    // Game controls the game. 
    // Players can be added to the game, and cards can be dealt to the registered players
    // Games come in different variants which only really differ in the way they fnd the winner of the game. Therefore,
    // this base class has an abstract FindWinner() method, implemented in the specialized game variants
    public abstract class Game : IGame
    {
        private readonly Deck.Deck _deck;
        protected readonly List<IPlayer> Players;
        protected GameState CurrentGameState;

        protected enum GameState
        {
            GameNotStarted,
            GameStarted
        }

        protected Game()
        {
            _deck = new Deck.Deck();
            Players = new List<IPlayer>();
            CurrentGameState = GameState.GameNotStarted;
        }

        public void AddPlayer(IPlayer player)
        {
            if(CurrentGameState == GameState.GameStarted) throw new CardGameException("Cannot add player when game is started");
            Players.Add(player);
        }

        public void Deal(uint cardsToDeal)
        {
            if (Players.Count == 0) throw new CardGameException("No players added to game");
            CurrentGameState = GameState.GameStarted;

            foreach (var player in Players)
            {
                _deck.Deal(player, cardsToDeal);
            }
        }

        // Games only differ in the way they find the winner. Everything else is the same.
        public abstract IPlayer FindWinner();
    }
}
