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
        #endregion
        #region Constructors
        /// <summary>
        /// Creates an default constructor that does nothing for the Card object.
        /// </summary>
        public Card()
        {

        }

        /// <summary>
        /// Creates a paramaterized constructor that is passed the assignedSuit and assignedValue, this constructor 
        /// will then assign the assigned values to a card object.
        /// </summary>
        /// <param name="assignedSuit"></param>
        /// <param name="assignedValue"></param>
        public Card(string assignedSuit, string assignedValue)
        {
            // Assigning values.
            cardSuit = assignedSuit;
            cardValue = assignedValue;
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
