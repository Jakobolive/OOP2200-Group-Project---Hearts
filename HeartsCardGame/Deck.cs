// Names: Jakob Olive, Troy Mouton
// Start Date: 2024-03-13
// File Desc: This file will contain the class that will build the current hand for each player. This class
// will contain a list of card objects and possibly have a string name attached to it to identify the player who owns
// this hand.
#region Using
using HeartsCardGame;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
#endregion

namespace HeartsCardGame
{
    internal class Deck
    {
        #region List
        // Creating the list that will be used to carry the deck of cards.
        public List<Card> cardDeck = new List<Card>();
        #endregion

        #region Build Method
        /// <summary>
        /// Function that will build a list of 52 cards based off the standard card deck with variables that 
        /// suit the requirements of the points system within Hearts.
        /// </summary>
        public virtual void BuildDeck()
        {
            // Values that represent the suits and values for a standard deck of playing cards.
            string[] standardSuits = { "Hearts", "Clubs", "Diamonds", "Spades" };
            int[] standardValues = { 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            int points;

            // Foreach loop nested inside another that loops the suits and values to create the cards.
            foreach (var suit in standardSuits)
            {
                foreach (var value in standardValues)
                {
                    // Initialize points to 0 by default.
                    points = 0; 
                    // Validation to check if either the suit is Hearts, or if card is the Queen of Spades.
                    if (suit == "Hearts")
                    {
                        points = 1;
                    }
                    else if (suit == "Spades" && value == 12)
                    {
                        points = 13;
                    }
                    // Adding a new card(Calling Parameterized Constructor) to cardDeck.
                    cardDeck.Add(new Card(suit, value, points));
                }
            }
            // Calling the shuffle method.
            Shuffle();
        }
        #endregion

        #region Code Functions
        /// <summary>
        /// This function will use a Random object to shuffle the deck of cards
        /// </summary>
        public void Shuffle()
        {
            Random randomShuffle = new Random();
            int n = cardDeck.Count;
            while (n > 1)
            {
                n--;
                int k = randomShuffle.Next(n + 1);
                Card value = cardDeck[k];
                cardDeck[k] = cardDeck[n];
                cardDeck[n] = value;
            }
        }
        /// <summary>
        /// This function will deal cards from the main deck to each players hand, It takes the last card from the 
        /// deck, removes it from the main deck and returns it to the program to distribute in a foreach loop.
        /// </summary>
        /// <returns></returns>
        public Card Deal()
        {
            Card card = cardDeck.Last();
            cardDeck.Remove(card);
            return card;
        }

        ///// <summary>
        ///// This function will get the list and return it for use in the form.
        ///// </summary>
        ///// <returns></returns>
        //public List<Card> GetDeck()
        //{
        //    // Return the list.
        //    return cardDeck;
        //}

        ///// <summary>
        ///// This function will set the values of the current list to the values of a new list. (Used In Shuffle And Deck Creation)
        ///// </summary>
        ///// <param name="newDeck"></param>
        //public void SetDeck(List<Card> newDeck)
        //{
        //    // Setting the cardDeck to the values of a newDeck.
        //    cardDeck = newDeck;
        //}
        #endregion
    }
}
