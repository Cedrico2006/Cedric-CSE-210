using System;

class Program
{
    static void Main(string[] args)
    {
        Random random = new Random();

        (string book, int chapter, int startVerse, int endVerse, string wholeVerse)[] scriptures =
        {
            ("John", 3, 16, 16, "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            ("Proverbs", 3, 5, 6, "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
            ("Psalm", 23, 1, 1, "The Lord is my shepherd; I shall not want."),
            ("Philippians", 4, 13, 13, "I can do all things through Christ which strengtheneth me."),
            ("2 Nephi", 2, 25, 25, "Adam fell that men might be; and men are, that they might have joy.")
        };

        int scriptureIndex = random.Next(scriptures.Length);
        string book = scriptures[scriptureIndex].book;
        int chapter = scriptures[scriptureIndex].chapter;
        int startVerse = scriptures[scriptureIndex].startVerse;
        int endVerse = scriptures[scriptureIndex].endVerse;
        string wholeVerse = scriptures[scriptureIndex].wholeVerse;

        Reference reference;

        if (startVerse == endVerse)
        {
            reference = new Reference(book, chapter, startVerse);
        }
        else
        {
            reference = new Reference(book, chapter, startVerse, endVerse);
        }

        Scriptures scripture = new Scriptures(reference, wholeVerse);

        Console.WriteLine(scripture.GetDisplayText());

        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide 1-3 random words, or type quit to exit.");
            string choice = Console.ReadLine();

            if (choice == "quit")
            {
                break;
            }

            Console.Clear();


            int amountOfWords = random.Next(1, 4);
            scripture.Replacement(amountOfWords);

            Console.WriteLine(scripture.GetDisplayText());
        }
    }
}
