

using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Reflection.Metadata.Ecma335;
using System.Security.AccessControl;

public class Scriptures
{
    private Reference _reference; 
    private List<Word> _words; 
    private Random _random;

    public Scriptures(Reference reference, string text)
    {
        _reference = reference; 
        _words = new List<Word>(); 
        _random = new Random();
        string[] words = text.Split(" ");

        foreach (string i in words)
        {
            _words.Add(new Word(i));
        }
    }


    public void Replacement(int amounttohide)
    {
       int hiddenAmount = 0;

       while (hiddenAmount < amounttohide && !IsCompletelyHidden())
        {
            int index = _random.Next(_words.Count);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenAmount += 1;
            }
        }

    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }

        }
        return true;
    }

    public string GetDisplayText()
    {
        string result = "";

        foreach (Word word in _words)
            {
                result += word.GetDisplayText() + " ";
            }

    return $"{_reference.AsString()}\n{result}";
    }  
}
public class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse) 
    { 
        _book = book; 
        _chapter = chapter; 
        _startVerse = verse; 
        _endVerse = verse; 
    }
    public Reference(string book, int chapter, int startverse, int endverse) 
    { 
        _book = book; 
        _chapter = chapter; 
        _startVerse = startverse; 
        _endVerse = endverse; 
    }

    public string AsString()
    {
        if (_startVerse == _endVerse)
        {
            return $"{_book} {_chapter}:{_startVerse}";
        }

        else return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }

}
public class Word
{
    private string _text; 
    private bool _hidden;

    public Word(string text)
    {
        _text = text; 
        _hidden = false;
    }

    public bool IsHidden()
    {
        return _hidden;
    }

    public void Hide()
    {
        _hidden = true;

    }

    public string GetDisplayText()
{
    if (_hidden)
    {
        return new string('_', _text.Length);
    }

    return _text;
}
}

