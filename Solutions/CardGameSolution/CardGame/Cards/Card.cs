namespace CardGame.Cards
{
    public enum CardColor
    {
        Red = 1,
        Blue,
        Green,
        Yellow,
        Gold = 6
    };

    // Cards are implemented with a color (enum) and a card calue. From this, the Value (color x card value) is derived.
    // There's no need to implement each color as a different class as they only differ in their state.
    public class Card : ICard
    {
        public Card(CardColor cardColor, int cardValue)
        {
            Color = cardColor;
            CardValue = cardValue;
        }
        
        public int CardValue { get; }
        public CardColor Color { get; }

        public int Value => (int)Color*CardValue;
        public override string ToString() => $"{Color} {CardValue}";
    }
}
