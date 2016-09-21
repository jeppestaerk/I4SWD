using System;

namespace CardGame
{
    public class CardGameException : Exception
    {
        public CardGameException(string msg) : base(msg)
        {
            
        }
    }
}