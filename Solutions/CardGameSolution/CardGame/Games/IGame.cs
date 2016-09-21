using CardGame.Players;

namespace CardGame.Games
{
    // The relevance of this interface cn be discussed - the Game base class is itself abstract. However, when it comes to testing 
    // (and decoupling) the software, the interface will be necessary - besides, it's virtually effort-free to define an interface.
    internal interface IGame
    {
        void AddPlayer(IPlayer player);
        void Deal(uint nCards);
        IPlayer FindWinner();
    }
}