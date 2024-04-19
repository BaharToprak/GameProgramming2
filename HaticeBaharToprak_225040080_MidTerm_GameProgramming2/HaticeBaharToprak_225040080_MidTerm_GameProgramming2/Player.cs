using HaticeBaharToprak_225040080_MidTerm_GameProgramming2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// Base class for Player
public class Player
{
    public string Name { get; set; }
    public List<Card> Deck { get; set; }
    public int Score { get; set; }

    public Player(string name)
    {
        Name = name;
        Deck = new List<Card>();
        Score = 0;
    }

    // Method to draw a card
    public virtual Card DrawCard()
    {
        Random random = new Random();
        int index = random.Next(0, Deck.Count);
        Card drawnCard = Deck[index];
        Deck.RemoveAt(index);
        return drawnCard;
    }

    // Method to change a card
    public virtual void ChangeCard()
    {
        Console.WriteLine($"{Name}, do you want to change your card? (yes/no)");
        string choice = Console.ReadLine().ToLower();

        if (choice == "yes")
        {
            Random random = new Random();
            int index = random.Next(0, Deck.Count);
            Console.WriteLine($"{Name} changed their card to {Deck[index].Name}.");
        }
        else
        {
            Console.WriteLine($"{Name} decided not to change their card.");
        }
    }

    // Method to play a round asynchronously with a time limit
    public virtual async Task PlayRoundAsync(Player opponent, int timeLimitInSeconds)
    {
        var delayTask = Task.Delay(timeLimitInSeconds * 1000);
        var roundTask = Task.Run(async () =>
        {
            ChangeCard(); // Allow player to change card

            Card playerCard = DrawCard();
            Card opponentCard = opponent.DrawCard();

            Console.WriteLine($"{Name} draws {playerCard.Name}");
            await Task.Delay(1000);
            Console.WriteLine($"{opponent.Name} draws {opponentCard.Name}");
            await Task.Delay(1000);

            if (playerCard.Value > opponentCard.Value)
            {
                Console.WriteLine($"{Name} wins the round!");
                Score++;
            }
            else if (playerCard.Value < opponentCard.Value)
            {
                Console.WriteLine($"{opponent.Name} wins the round!");
                opponent.Score++;
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }
        });

        var completedTask = await Task.WhenAny(delayTask, roundTask);
        if (completedTask == delayTask)
        {
            Console.WriteLine($"{Name} ran out of time! {opponent.Name} wins the round.");
            opponent.Score++;
        }
    }
}
