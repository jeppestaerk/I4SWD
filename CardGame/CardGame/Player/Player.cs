using CardGame.Card;
using System;

namespace CardGame.Player
{
    public class Player : IPlayer
    {
        public Player(string name, )
        {

        }
        public string Name { get; }
        public void ReciveCard(ICard card)
        {
            throw new NotImplementedException();
        }

        public int GetHandValue()
        {
            throw new NotImplementedException();
        }

        public void ShowHand()
        {
            throw new NotImplementedException();
        }
    }
}