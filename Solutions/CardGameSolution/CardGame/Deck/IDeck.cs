using CardGame.Players;

namespace CardGame.Deck
{
    // Interace for the Deck class
    interface IDeck
    {
        void Deal(IPlayer player, uint nCards);
    }
}