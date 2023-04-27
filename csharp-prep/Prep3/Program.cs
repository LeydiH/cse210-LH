using System;

class Program
{
    static void Main(string[] args)
    {
        string playAgain = "yes";
        while (playAgain == "yes") {
            Random rand = new Random();
            int magicNumber = rand.Next(1, 101);
            int guessCount = 0;
            int guess = -1;
            Console.WriteLine("Magic number for testing purpose: " + magicNumber);
            Console.WriteLine("Guess the magic number between 1 and 100");
            while (guess != magicNumber) {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;
                if (guess < magicNumber) {
                    Console.WriteLine("Higher");
                } else if (guess > magicNumber) {
                    Console.WriteLine("Lower");
                } else {
                    Console.WriteLine("You guessed it!");
                }
            }
            Console.WriteLine("You took {0} guesses.", guessCount);
            Console.Write("Do you want to play again? (yes/no) ");
            playAgain = Console.ReadLine().ToLower();
        }
    }
}



        