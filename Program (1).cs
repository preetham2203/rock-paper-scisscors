using System;

namespace RockPaperScissors
{
    class Program
    {
        // Declare a static Random instance outside of any method to ensure better randomness
        static Random random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Rock, Paper, Scissors!");

            // Track game statistics
            int totalGames = 0;
            int playerWins = 0;
            int computerWins = 0;
            int ties = 0;

            bool playAgain = true;
            while (playAgain)
            {
                totalGames++;
                Console.WriteLine($"\nGame {totalGames}:");

                // Get player's choice
                string playerChoice = GetPlayerChoice();

                // Get computer's choice
                string computerChoice = GetComputerChoice();

                // Determine the winner
                string result = DetermineWinner(playerChoice, computerChoice);

                // Update statistics
                if (result == "You win!")
                {
                    playerWins++;
                }
                else if (result == "Computer wins!")
                {
                    computerWins++;
                }
                else
                {
                    ties++;
                }

                // Print round result
                Console.WriteLine($"You chose: {playerChoice}");
                Console.WriteLine($"Computer chose: {computerChoice}");
                Console.WriteLine(result);

                // Check if player wants to play again
                playAgain = AskToPlayAgain();
            }

            // Print final statistics
            Console.WriteLine($"\nTotal games played: {totalGames}");
            Console.WriteLine($"Player wins: {playerWins}");
            Console.WriteLine($"Computer wins: {computerWins}");
            Console.WriteLine($"Ties: {ties}");
            Console.WriteLine(GetOverallWinner(playerWins, computerWins));
        }

        static string GetPlayerChoice()
        {
            Console.Write("Enter your choice (rock, paper, or scissors): ");
            string choice = Console.ReadLine().ToLower();
            while (choice != "rock" && choice != "paper" && choice != "scissors")
            {
                Console.WriteLine("Invalid choice. Please enter rock, paper, or scissors.");
                Console.Write("Enter your choice: ");
                choice = Console.ReadLine().ToLower();
            }
            return choice;
        }

        static string GetComputerChoice()
        {
            // Generate a random number between 1 and 3
            int randomNumber = random.Next(1, 4);

            switch (randomNumber)
            {
                case 1:
                    return "rock";
                case 2:
                    return "paper";
                case 3:
                    return "scissors";
                default:
                    return "";
            }
        }

        static string DetermineWinner(string playerChoice, string computerChoice)
        {
            if (playerChoice == computerChoice)
            {
                return "It's a tie!";
            }
            else if ((playerChoice == "rock" && computerChoice == "scissors") ||
                     (playerChoice == "paper" && computerChoice == "rock") ||
                     (playerChoice == "scissors" && computerChoice == "paper"))
            {
                return "You win!";
            }
            else
            {
                return "Computer wins!";
            }
        }

        static bool AskToPlayAgain()
        {
            Console.Write("\nDo you want to play again? (yes/no): ");
            string response = Console.ReadLine().ToLower();
            return response == "yes" || response == "y";
        }

        static string GetOverallWinner(int playerWins, int computerWins)
        {
            if (playerWins > computerWins)
            {
                return "You won the majority of games! Congratulations!";
            }
            else if (computerWins > playerWins)
            {
                return "Computer won the majority of games! Better luck next time!";
            }
            else
            {
                return "It's a tie! No clear winner.";
            }
        }
    }
}