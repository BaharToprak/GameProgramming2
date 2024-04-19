using HaticeBaharToprak_225040080_MidTerm_GameProgramming2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class ComputerPlayer : Player
{
    public int DifficultyLevel { get; set; } // Difficulty level for computer player

    public ComputerPlayer(int difficultyLevel) : base("Computer")
    {
        DifficultyLevel = difficultyLevel;
    }

    // Method to draw a card based on difficulty level
    public override Card DrawCard()
    {
        Random random = new Random();

        if (DifficultyLevel == 1) // Easy
        {
            return Deck[0]; // Always draws the first card
        }
        else if (DifficultyLevel == 2) // Medium
        {
            int index = random.Next(0, Deck.Count / 2); // Draws from the first half of the deck
            return Deck[index];
        }
        else // Hard
        {
            int index = random.Next(0, Deck.Count); // Draws a random card
            return Deck[index];
        }
    }
}
