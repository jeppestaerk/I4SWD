namespace CardGame.Card
{
    public class Card : ICard
    {
        public Card(CardColor cardColor, int cardNumber)
        {
            Color = cardColor;
            CardNumber = cardNumber;
        }

        public CardColor Color { get; }
        public int CardNumber { get; }

        public int CardValue { get { return (int)Color * CardNumber; } }
    }
}