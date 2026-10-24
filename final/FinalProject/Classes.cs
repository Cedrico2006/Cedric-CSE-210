using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Security.Cryptography;

public class RecipeCard
{
    private bool _reversable; //Determines if Recipe is allowed to be reversed
    private Dictionary<string,int> _inputs;
    private Dictionary<string,int> _outputs;
    public RecipeCard(Dictionary<string,int> inputs, Dictionary<string,int> outputs, bool reversable)
    {
        _inputs = inputs;
        _outputs = outputs;
        _reversable = reversable;
    }

     public void Reverse() //reminder some cards can be flipped and need to think of a way to determine what is more valuable 
    {
        if (_reversable == true)
        {
            (_inputs, _outputs) = (_outputs,_inputs);
        }
        
    }

    public void Brew(Cauldron cauldron,Storage storage)
    {
        if (storage.RemoveCubes(_inputs))
        {
            cauldron.AddCubes(_outputs);
        }
         
    }

}
public class Storage 
{
    public Dictionary<string,int> _storage;

    public Storage(Dictionary<string,int> storage)
    {
        _storage = storage;
    }
    
    public virtual int AddCubes(Dictionary<string,int> inputs) 
    {
        foreach (var cube in inputs)
        {
            _storage[cube.Key] += cube.Value;
            
        }
        return 0;
    }
    

    public virtual bool RemoveCubes(Dictionary<string, int> inputs)
    {
        foreach (var cube in inputs)
        {
            if (!_storage.ContainsKey(cube.Key) || _storage[cube.Key] < cube.Value)
            {
                return false;
            }
        }

        foreach (var cube in inputs)
        {
            _storage[cube.Key] -= cube.Value;
        }

        return true;
    }

    public Dictionary<string, int> GetContents()
    {
        return new Dictionary<string, int>(_storage);
    }
      
}
public class Board : Storage
{
    private Dictionary<string, int> _limits = new Dictionary<string, int>();
    public Board(Dictionary<string,int> storage) : base(storage)
    {
        _limits = new Dictionary<string, int>()
        {
            ["red"] = 9,
            ["blue"] = 9,
            ["green"] = 9,
            ["white"] = 4,
            ["black"] = 3,
        };
        
    }
    
    public override int AddCubes(Dictionary<string,int> inputs) 
    {
       int _points = 0;
       foreach (var cube in inputs)
        {
            _storage[cube.Key] += cube.Value;
            if (_storage[cube.Key] > _limits[cube.Key])
            {
                 _points +=_storage[cube.Key] - _limits[cube.Key];

            }
    
        }
       return _points;
    }

}
public class Cauldron : Storage
{
    public Cauldron(Dictionary<string, int> storage) : base(new Dictionary<string, int>()
    {
            ["red"] = 0,
            ["blue"] = 0,
            ["green"] = 0,
            ["white"] = 0,
            ["black"] = 0
    })
    {
        
    }
    public void Clear()
    {
        foreach (var key in _storage.Keys.ToList())
        {
            _storage[key] = 0;
        }
    }
}
public class StackOfCards
{
    public List<RecipeCard> _deck = new List<RecipeCard>();
    public StackOfCards(List<RecipeCard> deck)
    {
        _deck = deck;
    }

    public void AddCard(RecipeCard card)
    {
        _deck.Add(card);
    }

    public void RemoveCard(RecipeCard card)
    {
        _deck.Remove(card);
    }

    public void MoveCard(RecipeCard card, StackOfCards going, StackOfCards from)
    {
        from.RemoveCard(card);
        going.AddCard(card);
    }

    public RecipeCard RandomCard()
    {
        int randomIndex = Random.Shared.Next(_deck.Count);
        RecipeCard randomItem = _deck[randomIndex];
        return randomItem;
    }
}
public class Deck : StackOfCards
{
    public Deck(List<RecipeCard> deck) : base (deck)
    {
        _deck = deck;
    }

    private int ConvertToInt(string number)
    {
        return int.Parse(number);
    }
    public void MakeDeck()
    {
        string filePath = "Deck.txt";

        using (StreamReader reader = new StreamReader(filePath))
        {
            string line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(
                    new string[] { "||" },
                    StringSplitOptions.None
                );

                // The line starts and ends with ||, so the first
                // and last elements may be empty.
                int offset = parts[0] == "" ? 1 : 0;

                int _Oreds = ConvertToInt(parts[offset]);
                int _Oblues = ConvertToInt(parts[offset + 1]);
                int _Ogreens = ConvertToInt(parts[offset + 2]);
                int _Owhites = ConvertToInt(parts[offset + 3]);
                int _Oblacks = ConvertToInt(parts[offset + 4]);

                int _Ireds = ConvertToInt(parts[offset + 5]);
                int _Iblues = ConvertToInt(parts[offset + 6]);
                int _Igreens = ConvertToInt(parts[offset + 7]);
                int _Iwhites = ConvertToInt(parts[offset + 8]);
                int _Iblacks = ConvertToInt(parts[offset + 9]);

                bool _isreversable = bool.Parse(parts[offset + 10]);

                Dictionary<string, int> _inputs = new Dictionary<string, int>()
                {
                    ["red"] = _Ireds,
                    ["blue"] = _Iblues,
                    ["green"] = _Igreens,
                    ["white"] = _Iwhites,
                    ["black"] = _Iblacks,
                };

                Dictionary<string, int> _outputs = new Dictionary<string, int>()
                {
                    ["red"] = _Oreds,
                    ["blue"] = _Oblues,
                    ["green"] = _Ogreens,
                    ["white"] = _Owhites,
                    ["black"] = _Oblacks,
                };

                RecipeCard recipe = new RecipeCard(
                    _inputs,
                    _outputs,
                    _isreversable
                );

                _deck.Add(recipe);
            }
        }
    }
}
public class Player
{
    private StackOfCards _hand;
    public Cauldron _cauldron;
    private StackOfCards _playedcards;
    public Board _board;
    public int _points;

    public Player(Cauldron cauldron,StackOfCards deck)
    {
        _cauldron = cauldron;
        _hand = new StackOfCards(new List<RecipeCard>());
        
        for (int i = 0; i < 4; i++)
        {
            _hand.MoveCard(deck.RandomCard(),_hand,deck);
        }

        _playedcards = new StackOfCards(new List<RecipeCard>());
        _points = 0;
        _board = new Board(new Dictionary<string, int>()
        {
            ["red"] = 0,
            ["blue"] = 0,
            ["green"] = 0,
            ["white"] = 0,
            ["black"] = 0,
        });
    }
    public int Turn(StackOfCards deck,Cauldron cauldron)
    { 
        // A turn goes draw a Card 
        // dump Cauldron into storage 
        // if overflow return points
        // play a card 
        // produce all possible cards (order TBD)

        _hand.MoveCard(_hand.RandomCard(), _playedcards, _hand);
        int _OtherPlayerPoints = _board.AddCubes(cauldron._storage);
        cauldron.Clear();
        _hand.MoveCard(_hand.RandomCard(),_hand,_playedcards);

        foreach(RecipeCard card in _playedcards._deck)
        {
            card.Brew(_cauldron,_board);
        }
        return _OtherPlayerPoints;
    }

    public void PassingCardsAndCauldrons(Player otherplayer)
    {
        Cauldron tempCauldron = _cauldron;
        _cauldron = otherplayer._cauldron;
        otherplayer._cauldron = tempCauldron;

        StackOfCards tempHand = _hand;
        _hand = otherplayer._hand;
        otherplayer._hand = tempHand;
    }
}
public class Game
{
    public int _numberOfPlayers;
    public List<Player> _players;
    public Game(int numberofplayers, StackOfCards deck)
    {
        _numberOfPlayers = numberofplayers;
        _players = new List<Player>();

        for (int i = 0; i < numberofplayers; i++)
        {
            Player _player = new Player(new Cauldron(new Dictionary<string, int>()), deck);
            _player._board.AddCubes
            (
                new Dictionary<string, int>()
                    {
                        ["red"] = 4,
                        ["blue"] = 4,
                        ["green"] = 4,
                        ["white"] = 0,
                        ["black"] = 0,
                    }
            );
            _players.Add(_player);
        }
    }

    
public void Run(StackOfCards deck)
{
    for (int i = 0; i < _players.Count; i++)
    {
        Player current = _players[i];

        int points = current.Turn(deck, current._cauldron);

        Player previous = _players[(i - 1 + _numberOfPlayers) % _numberOfPlayers];

        previous._points += points;

        // Pass the cauldron and hand to the next player.
        Player next = _players[(i + 1) % _numberOfPlayers];
        current.PassingCardsAndCauldrons(next);
    }
}
 
}
public class Statisics
{
    int _rounds;
    int _players;
    double _averageScoreOfPlayers;

    public void Data(Deck deck,int players,int wincondition)
    {
        // Change Players here
        int numberOfPlayers = players;
        Game game = new Game(numberOfPlayers, deck);
        int round = 1;

        // Main game loop: Run rounds until someone reaches 5 points
        while (!game._players.Any(p => p._points >= wincondition))
        {
            game.Run(deck);
            //write data to player number and win conditon max (5,10) (player number, rounds until win, win conditon, average points of all players,)

            round++;
        }
    }
}