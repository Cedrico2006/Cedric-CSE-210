using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        List<RecipeCard> stack = new List<RecipeCard>();
        Deck deck = new Deck(stack);
        deck.MakeDeck();

        Console.WriteLine("How many Players would you like (max 5)?");
        int numberOfPlayers = int.Parse(Console.ReadLine());

        Game game = new Game(numberOfPlayers, deck);
        int round = 1;


        Statisics stats = new Statisics();
        List<List<List<int>>> _alldata = new List<List<List<int>>>();

        while (round <= 100 && !game.HasWinner(5,game))
        {
            List<List<int>> _allPlayerRoundData = stats.Data(deck, game);
            _alldata.Add(_allPlayerRoundData);
            round++;
        }
        
        Console.WriteLine(stats.DataMath(_alldata));
    }
}