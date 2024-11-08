using System;

namespace GamePad
{
    class Program
    {
        static void Main(string[] args)
        {
            bool playAgain = true;
            const int maxAttempts = 10;
            Random rand = new Random();

            while (playAgain)
            {
                // Reset game variables at the start of each game
                int attempts = 0;
                bool guessedCorrectly = false;
                int mike = rand.Next(0, 100);
                int guessedNumber;

                // Prompt for user name at the beginning of each game
                Console.WriteLine("Enter your name:");
                var name = Console.ReadLine();
                Console.WriteLine($"{name}, welcome! Press Enter to guess a random number from 0 - 100.");
                Console.ReadKey();

                // Start guessing loop
                while (attempts < maxAttempts && !guessedCorrectly)
                {
                    Console.WriteLine("Enter your guess:");

                    // Validate user input
                    try
                    {
                        guessedNumber = Convert.ToInt32(Console.ReadLine());
                    }
                    catch
                    {
                        Console.WriteLine("Enter a valid number from 0 - 100.");
                        continue;
                    }

                    attempts++; // Increment attempts after a valid guess

                    // Check the guessed number
                    if (guessedNumber < mike)
                    {
                        Console.WriteLine("Too Low");
                    }
                    else if (guessedNumber > mike)
                    {
                        Console.WriteLine("Too High");
                    }
                    else
                    {
                        guessedCorrectly = true;
                        Console.WriteLine("Congratulations, You Win!");
                    }
                }

                // End of game message if attempts are exhausted
                if (!guessedCorrectly)
                {
                    Console.WriteLine("You have used up all your attempts.");
                }

                // Ask if the player wants to play again
                Console.WriteLine("Do you wish to play again? (Y/N)");
                string response = Console.ReadLine().ToUpper();

                // Set `playAgain` based on user response
                playAgain = (response == "Y");
            }

            Console.WriteLine("Thank you for playing! Goodbye.");
            Console.Beep();
            
        }
    }
}
