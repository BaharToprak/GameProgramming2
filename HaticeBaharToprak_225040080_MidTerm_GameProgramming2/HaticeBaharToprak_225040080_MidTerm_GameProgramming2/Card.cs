using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaticeBaharToprak_225040080_MidTerm_GameProgramming2
{
    public class Card
    {
        // Property representing the name of the card.
        public string Name { get; set; }

        // Property representing the value or rank of the card.
        public int Value { get; set; }

        // Constructor method to initialize a new Card object.
        // Takes a name and a value as parameters to set the properties of the card.
        public Card(string name, int value)
        {
            Name = name;
            Value = value;
        }
    }
}