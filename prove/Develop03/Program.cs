using System;

namespace Develop03
{
    class Program
    {
        static void Main(string[] args)
        {
            Scripture scripture = new Scripture(new Reference("Proverbs 3:5-6"), "Trust in the LORD with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.");
            Scripture scripture2 = new Scripture(new Reference("Luke 2:19"), "But Mary kept all these things, and pondered them in her heart.");
            Scripture scripture3 = new Scripture(new Reference("Luke 1:37"), "For with God nothing shall be impossible.");

            Scripture[] scriptures = new Scripture[] { scripture, scripture2, scripture3 };
            Random random = new Random();
            int randomIndex = random.Next(0, scriptures.Length);
            Scripture randomScripture = scriptures[randomIndex];
            randomScripture.HideWords();
        }
    }

    class Scripture
    {
        private Reference _reference;
        private Word[] _words;
        private Random _random = new Random();

        public Scripture(Reference reference, string text)
        {
            _reference = reference;
            _words = text.Split(' ').Select(w => new Word(w)).ToArray();
        }

        public void HideWords()
        {
            Console.WriteLine(_reference.GetText());
            Console.WriteLine(GetScriptureText());
            Console.WriteLine("Press enter to hide words or type quit to exit.");
            string input = Console.ReadLine();
            
            while (input != "quit")
            {
                int randomIndex = _random.Next(0, _words.Length);
                _words[randomIndex].Hide();
                Console.Clear();
                Console.WriteLine(_reference.GetText());
                Console.WriteLine(GetScriptureText());
                Console.WriteLine("Press enter to hide words or type quit to exit.");
                input = Console.ReadLine();
            }
        }

        private string GetScriptureText()
        {
            return string.Join(" ", _words.Select(w => w.GetText()));
        }
    }

    class Word
    {
        private string _text;
        private bool _isHidden;

        public Word(string text)
        {
            _text = text;
            _isHidden = false;
        }

        public void Hide()
        {
            _isHidden = true;
        }

        public string GetText()
        {
            return _isHidden ? "*****" : _text;
        }
    }

    class Reference
    {
        private string _text;

        public Reference(string text)
        {
            _text = text;
        }

        public string GetText()
        {
            return _text;
        }
    }
}
