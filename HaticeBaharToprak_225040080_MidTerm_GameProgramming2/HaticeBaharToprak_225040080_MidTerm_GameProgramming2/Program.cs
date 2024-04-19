namespace HaticeBaharToprak_225040080_MidTerm_GameProgramming2
{

    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Welcome to the War Card Game!");

            int difficultyLevel = 0;

            // Get valid difficulty level from user
            while (difficultyLevel < 1 || difficultyLevel > 3)
            {
                Console.WriteLine("Select difficulty level: 1 - Easy, 2 - Medium, 3 - Hard");
                if (!int.TryParse(Console.ReadLine(), out difficultyLevel) || difficultyLevel < 1 || difficultyLevel > 3)
                {
                    Console.WriteLine("Please enter a valid difficulty level: 1, 2, or 3.");
                }
            }

            // Player and computer initialization
            Player player = new Player("Player");
            ComputerPlayer computer = new ComputerPlayer(difficultyLevel);

            // Deck creation
            List<Card> deck = new List<Card>
        {
            new Card("2", 2), new Card("3", 3), new Card("4", 4),
            new Card("5", 5), new Card("6", 6), new Card("7", 7),
            new Card("8", 8), new Card("9", 9), new Card("10", 10),
            new Card("Jack", 11), new Card("Queen", 12), new Card("King", 13), new Card("Ace", 14)
        };

            player.Deck = new List<Card>(deck);
            computer.Deck = new List<Card>(deck);

            while (player.Deck.Count > 0 && computer.Deck.Count > 0)
            {
                await player.PlayRoundAsync(computer, 10); // 10 seconds time limit per round
                Console.WriteLine($"Score - {player.Name}: {player.Score}, {computer.Name}: {computer.Score}");


                // Wait for the user to press Enter to continue
                Console.WriteLine("Press Enter to continue...");
                while (Console.ReadKey().Key != ConsoleKey.Enter) { /* Wait for Enter key */ }

                string userInput = "";

                do
                {
                    Console.WriteLine("Please, write 'Enter' and press Enter:");
                    userInput = Console.ReadLine();

                    if(userInput.ToLower() != "enter")
                    {
                        Console.WriteLine("Make sure you spell 'Enter' correctly.");
                        Console.WriteLine("\nPress Enter to try again...");

                        while (Console.ReadKey().Key != ConsoleKey.Enter)
                        {

                        }
                    }
                }


                while (userInput.ToLower() != "enter");
                {
                   
                    {
                        Console.WriteLine("Correct! You've entered 'Enter'. ");
                    }

                   
                    
                }
               

            }

            if (player.Score > computer.Score)
            {
                Console.WriteLine($"{player.Name} wins the game!");
            }
            else if (player.Score < computer.Score)
            {
                Console.WriteLine($"{computer.Name} wins the game!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        }
    }
}