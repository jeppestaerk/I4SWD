namespace CardGame.Cards
{
    public interface ICard
    {
        int CardValue { get; }
        CardColor Color { get; }
        int Value { get; }
    }
}