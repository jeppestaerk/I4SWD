using System;
using CardGame.Cards;

namespace CardGame.Players
{
    // Weak players can only handle up to three cards. When they are dealt their fourth card they will 
    // "drop" on of the cards they already hold.
    public class WeakPlayer : Player
    {
        private readonly Random _rnd = new Random();

        public WeakPlayer(string name, ICardCollection cards) : base(name, cards)
        {
        }

        public override void AcceptCard(ICard card)
        {
            if (Cards.Count > 2)
            {
                // Pick a random card to be removed
                Cards.RemoveCard(_rnd.Next(Cards.Count));
            }
            Cards.Add(card);
        }


    }
}
