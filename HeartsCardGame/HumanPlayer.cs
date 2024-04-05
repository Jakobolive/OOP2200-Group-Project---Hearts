// Names: Jakob Olive, Troy Mouton
// Start Date: 2024-04-03
// File Desc: This 
#region Usings
using System;
using System.Collections.Generic;
using System.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
#endregion
namespace HeartsCardGame
{
    internal class HumanPlayer : Player
    {
        #region Variables
        private Card cardInPlay = null;
        #endregion
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPlayerName"></param>
        /// <param name="cardInPlay"></param>
        public HumanPlayer(string newPlayerName, Card cardInPlay) : base(newPlayerName)
        {
            this.cardInPlay = cardInPlay;
        }
        #endregion
        #region Getters & Setters
        /// <summary>
        /// This function is a basic getter and setter for the HumanPlayer's cardInPlay variable.
        /// </summary>
        protected internal Card CardInPlay
        {
            get { return cardInPlay; }
            set { cardInPlay = value; }
        }
        #endregion
        #region Functions
        public override Card PlayCard(List<Card> currentRound, bool heartsBroken)
        {
            // If this is the first play of the round, player can lead with any card.
            if (currentRound.Count == 0)
            {
                // Implement logic to let the human player choose a card to lead
                // For example, enable card buttons for the player to click
                // Return the selected card
                WaitForPlayerInput(); // Wait for player to click a card button
                return selectedCard; // Return the card clicked by the player
            }
            else
            {
                // Otherwise, play a card following the suit led, if possible.
                string leadingSuit = currentRound[0].Suit;
                var playableCards = GetPlayableCards(leadingSuit);

                // If no cards of the led suit are available, play a random card.
                if (playableCards.Count == 0)
                {
                    // Implement logic to select a random card from the player's hand
                    return GetRandomCard();
                }
                else
                {
                    // Otherwise, let the user select a card of the leading suit to play
                    // Display only the playable card buttons
                    DisplayPlayableCardButtons(playableCards);
                    WaitForPlayerInput(); // Wait for player to click a card button
                    return selectedCard; // Return the card clicked by the player
                }
            }
        }

        // Method to enable card buttons for the player to click
        private void DisplayPlayableCardButtons(List<Card> playableCards)
        {
            // Enable only the buttons corresponding to playable cards
        }

        // Method to wait for player input (i.e., clicking a card button)
        private void WaitForPlayerInput()
        {
            // Implement logic to wait for player to click a card button
            // When a card button is clicked, update the 'selectedCard' variable
        }

        // Example variable to hold the selected card
        private Card selectedCard;

        // Method to set the selected card (to be called when a card button is clicked)
        private void SetSelectedCard(Card card)
        {
            selectedCard = card;
        }

        ///// <summary>
        ///// Redo to accommodate.
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
    #endregion
}