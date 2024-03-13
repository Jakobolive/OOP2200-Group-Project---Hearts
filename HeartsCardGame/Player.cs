// Names: 
// Start Date: 
// File Desc:
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeartsCardGame
{
    internal class Player
    {
        #region Variables
        // Define the string for cardSuit and cardValue. Player(String name, List<Card> hand, int points)
        private string playerName;
        private List<Card> playerHand;
        private int playerPoints;
        #endregion
        #region Constructors
        /// <summary>
        /// Creates an default constructor that does nothing for the Player object.
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// Creates a paramaterized constructor that is passed the playerName and playerHand, and playerPoints, this constructor 
        /// will then assign the assigned values to a new Player object.
        /// </summary>
        /// <param name="newPlayerName"></param>
        /// <param name="newPlayerHand"></param>
        /// <param name="newPlayerPoints"></param>
        public Card(string newPlayerName, List<Card> newPlayerHand, int newPlayerPoints)
        {
            // Assigning values.
            playerName = newPlayerName;
            playerHand = newPlayerHand;
            playerPoints = newPlayerPoints;
        }
        #endregion
        #region Getters & Setters
        /// <summary>
        /// This function is a basic getter and setter for the player's name variable.
        /// </summary>
        protected internal string PlayerName
        {
            get { return playerName; }
            set { playerName = value; }
        }

        /// <summary>
        /// This function is a basic getter and setter for the players hand variable.
        /// </summary>
        protected internal List<Card> PlayerHard
        {
            get { return playerHand; }
            set { playerHand = value; }
        }

        /// <summary>
        /// This function is a basic getter and setter for the players points variable.
        /// </summary>
        protected internal int PlayerPoints
        {
            get { return playerPoints; }
            set { playerPoints = value; }
        }
        #endregion
    }
}
