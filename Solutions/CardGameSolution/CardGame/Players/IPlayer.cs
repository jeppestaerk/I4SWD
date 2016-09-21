using CardGame.Cards;

namespace CardGame.Players
{
    // This interface defines a Player.
    public interface IPlayer
    {
        string Name { get; }
        void AcceptCard(ICard card);
        void ShowHand();
        int GetHandTotal();
    }
}