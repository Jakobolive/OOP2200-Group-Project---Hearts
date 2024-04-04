// Names: Jakob Olive, Troy Mouton
// Start Date: 2024-04-03
// File Desc: This 
using System;
using System.Collections.Generic;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace HeartsCardGame
{
    internal class HumanPlayer : Player
    {
        public HumanPlayer(string newPlayerName) : base(newPlayerName)
        {
        }

        public override Card PlayCard(List<Card> currentRound)
        {
            // First, check if a leading suit has been selected, if not, it must be the first card.
            if (leadingSuit == null)
            {
                // If the player selects a heart right off the bat, but the hearts are not broken, the selection is invalid.
                if (selectedCard.Suit == "Hearts" && !heartsBroken)
                {
                    // display message.
                    return false;
                }
                // Otherwise, it is not a heart or the hearts are broken, it is valid.
                else
                {
                    // Display message.
                    return true;
                }
            }
            // If the user selects a card that is not of the leading suit, and the hearts are not broken.
            if (!heartsBroken && selectedCard.Suit != leadingSuit)
            {
                // Check if the player has a valid card in their hand, if they do, reject their selection.
                if (currentPlayer.PlayerHand.Any(card => card.Suit == leadingSuit))
                {
                    // Display message.
                    return false;
                }
                // Else, according to the rules of hearts, their selection is valid as they cannot play a card of the leading suit.
                else
                {
                    // Check if the selected card is a heart, if it is, the hearts are now broken.
                    if (selectedCard.Suit == "Hearts")
                    {
                        heartsBroken = true;
                    }
                    // Display message
                    return true;
                }
            }
            // Otherwise, Either the hearts are broken or the card is of the leading suit, therefore it is valid.
            else
            {
                // Display Message.
                return true;
            }
        }

        ///// <summary>
        ///// Redo to accomodate.
        ///// </summary>
        //private void DisplayHand()
        //{
        //    for (int i = 0; i < Hand.Count; i++)
        //    {
        //        Console.WriteLine($"{i}: {Hand[i].Value} of {Hand[i].Suit}");
        //    }
        //    Console.WriteLine();
        //}
    }
}