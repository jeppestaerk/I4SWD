namespace CardGame.Cards
{
    public interface ICardCollection
    {
        int Count { get; }

        void Add(ICard card);
        ICard GetCard(int cardNo);
        int GetCardSum();
        void RemoveCard(int cardNo);
        void Show();
        void Shuffle();
    }
}