// Names: Jakob Olive, Troy Mouton
// Start Date: 2024-03-13
// File Desc: This class will contains variables and constructors needed in the player class. The player objects
// will contain a name, hand (list of card objects), and the points they have for the game. The number of players
// can be chosen when the app first opens in the game setup region.
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
            // Assigning default values for the overloaded constructor.
            this.playerName = "John Doe";
            this.playerHand = new List<Card>();
            this.playerPoints = 0;
        }

        /// <summary>
        /// Creates a parameterized constructor that is passed the playerName and playerHand, and playerPoints, this constructor 
        /// will then assign the assigned values to a new Player object.
        /// </summary>
        /// <param name="newPlayerName"></param>
        /// <param name="newPlayerHand"></param>
        /// <param name="newPlayerPoints"></param>
        public Player(string newPlayerName, List<Card> newPlayerHand, int newPlayerPoints)
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
