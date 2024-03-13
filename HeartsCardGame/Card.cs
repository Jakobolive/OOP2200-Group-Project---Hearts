// Names: 
// Start Date: 
// File Desc: 
#region Using
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace HeartsCardGame
{
    internal class Card
    {
        #region Variables
        // Define the string for cardSuit and cardValue.
        private string cardSuit;
        private string cardValue;
        private bool dangerCard; // Meaning the card is either a heart or the queen of spades.
        private int pointValue; // set to 0 if it is a base card, 1 if it is in the heart suit, and 13? if it is the queen of spades.
        #endregion
        #region Constructors
        /// <summary>
        /// Creates an default constructor that does nothing for the Card object.
        /// </summary>
        public Card()
        {

        }

        /// <summary>
        /// Creates a paramaterized constructor that is passed the assignedSuit and assignedValue danger bool, and point value, this constructor 
        /// will then assign the assigned values to a card object.
        /// </summary>
        /// <param name="assignedSuit"></param>
        /// <param name="assignedValue"></param>
        /// <param name="dangerCardBool"></param>
        /// <param name="cardPointValue"></param>
        public Card(string assignedSuit, string assignedValue, bool dangerCardBool, int cardPointValue)
        {
            // Assigning values.
            cardSuit = assignedSuit;
            cardValue = assignedValue;
            dangerCard = dangerCardBool;
            pointValue = cardPointValue; 
        }
        #endregion

        #region Getters & Setters
        /// <summary>
        /// This function is a basic getter and setter for the suit variable.
        /// </summary>
        protected internal string Suit
        {
            get { return cardSuit; }
            set { cardSuit = value; }
        }

        /// <summary>
        /// This function is a basic getter and setter for the value variable.
        /// </summary>
        protected internal string Value
        {
            get { return cardValue; }
            set { cardValue = value; }
        }

        /// <summary>
        /// This function is a basic getter and setter for the danger card variable.
        /// </summary>
        protected internal bool DangerCard
        {
            get { return dangerCard; }
            set { dangerCard = value; }
        }

        /// <summary>
        /// This function is a basic getter and setter for the point value variable.
        /// </summary>
        protected internal int PointValue
        {
            get { return pointValue; }
            set { pointValue = value; }
        }
        #endregion

        #region Method
        /// <summary>
        /// This function will override the default ToString() method, this will allow the method to proform better for 
        /// our purpose of displaying a card and its information.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // Define the new cardString.
            string cardString;
            // Setting the value to the new card string to show the "value of card" and returning the string.
            cardString = Value + " of " + Suit;
            // Returning the string.
            return cardString;
        }
        #endregion
    }
}
