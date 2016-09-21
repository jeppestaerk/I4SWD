using CardGame.Card;

namespace CardGame.Player
{
    public interface IPlayer
    {
        string Name { get; }
        void ReciveCard(ICard card);
        int GetHandValue();
        void ShowHand();
    }
}
