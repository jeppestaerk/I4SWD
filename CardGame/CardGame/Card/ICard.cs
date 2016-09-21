namespace CardGame.Card
{
    public interface ICard
    {
        CardColor Color { get; }
        int CardNumber { get; }
        int CardValue { get; }
    }
}
