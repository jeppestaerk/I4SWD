using System;
using System.Collections.Generic;
using System.Linq;

namespace CardGame.Cards
{
    public class CardCollection : ICardCollection
    {
        private readonly List<ICard> _cards = new List<ICard>();

        public int Count => _cards.Count;
        public int GetCardSum() => _cards.Sum(c => c.Value);

        public void Add(ICard card)
        {
            _cards.Add(card);
        }
        
        public ICard GetCard(int cardNo)
        {
            if (cardNo >= 0 && cardNo < Count) return _cards[cardNo];
            throw new CardGameException("No such card");
        }

        public void RemoveCard(int cardNo)
        {
            if (cardNo >= 0 && cardNo < Count)
                _cards.RemoveAt(cardNo);
            else
                throw new CardGameException("No such card");
        }

        public void Show()
        {
            foreach (var card in _cards)
                Console.WriteLine("  " + card);
            Console.WriteLine("");

        }

        public void Shuffle()
        {
            var rnd = new Random();

            // Shuffle the deck - 
            // http://stackoverflow.com/questions/273313/randomize-a-listt-in-c-sharp
            var n = _cards.Count;
            while (n > 1)
            {
                n--;
                var k = rnd.Next(n + 1);
                var value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }
    }
}