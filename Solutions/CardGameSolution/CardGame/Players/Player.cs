using CardGame.Cards;
using static System.Console;

namespace CardGame.Players
{
    // This Player class defines the regular player. 
    // The way a player accept cards may differ and is therefore made virtual
    public class Player : IPlayer
    {
        protected readonly ICardCollection Cards;
        public string Name { get;}

        public Player(string name, ICardCollection cards)
        {
            Name = name;
            Cards = cards;
        }

        public void ShowHand()
        {
            WriteLine($"{Name}'s hand:");
            Cards.Show();
        }

        public int GetHandTotal() => Cards.GetCardSum();


        // The default way to handle cards - may be overridden
        public virtual void AcceptCard(ICard card)
        {
            Cards.Add(card);
        }
    }
}
