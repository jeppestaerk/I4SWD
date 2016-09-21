using CardGame.Cards;
using CardGame.Games;
using CardGame.Players;
using static System.Console;

namespace CardGame.Application
{
    class Program
    {
        static void Main(string[] args) 
        {

            var game = new HighTotalWinsGame();
            var p1 = new Player("Maverick", new CardCollection());
            var p2 = new Player("Goose", new CardCollection());
            var p3 = new Player("Charlie", new CardCollection());
            var p4 = new WeakPlayer("Weak Iceman", new CardCollection());

            game.AddPlayer(p1);
            game.AddPlayer(p2);
            game.AddPlayer(p3);
            game.AddPlayer(p4);

            game.Deal(5);

            p1.ShowHand();
            p2.ShowHand();
            p3.ShowHand();
            p4.ShowHand();
            
            var winner = game.FindWinner();
            WriteLine($"{winner.Name} wins the game with {winner.GetHandTotal()} points");

        }
    }
}
