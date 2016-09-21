using System;
using CardGame.Cards;
using CardGame.Players;

namespace CardGame.Deck
{
    // The Deck class - internal, as it is not interesting to anyone outside this namespace.
    internal class Deck : IDeck
    {
        private const int MinCardValue = 1;
        private const int MaxCardValue = 8;

        private readonly ICardCollection _cards;

        public Deck()
        {
            _cards = new CardCollection();

            var colors = Enum.GetValues(typeof(CardColor));
            foreach (CardColor c in colors)
            {
                for (var i = MinCardValue; i <= MaxCardValue; i++)
                    _cards.Add(new Card(c, i));
            }

            _cards.Shuffle();
        }

        // Deal nCards cards to player.
        public void Deal(IPlayer player, uint nCards)
        {
            for (uint i = 0; i < nCards; i++)
            {
                if (_cards.Count == 0) throw new CardGameException("Deck exhausted");

                var card = _cards.GetCard(0);
                _cards.RemoveCard(0);
                player.AcceptCard(card);
            }
        }
    }
}