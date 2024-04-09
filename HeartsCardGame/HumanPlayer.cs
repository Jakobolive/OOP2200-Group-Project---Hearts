// Names: Jakob Olive, Troy Mouton
// Start Date: 2024-04-03
// File Desc: This 
#region Usings
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
#endregion
namespace HeartsCardGame
{
    internal class HumanPlayer : Player
    {
        #region Variables & Events
        private Card cardInPlay = null;
        #endregion
        #region Constructor
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newPlayerName"></param>
        /// <param name="cardInPlay"></param>
        public HumanPlayer(string newPlayerName) : base(newPlayerName)
        {
            cardInPlay = null;
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

        /// <summary>
        /// This method will get overridden with the below method, because we must pass the list of buttons
        /// to the function to be able to activate the correct and valid cards.
        /// </summary>
        /// <param name="currentRound"></param>
        /// <param name="heartsBroken"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public override Card PlayCard(List<Card> currentRound, bool heartsBroken)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// This function is an overload of the above overridden function from the Player.cs file.
        /// The function tests the players hand as well as the current trick of the game to help the Human
        /// Player make a card selection. Several tests will be preformed, such as hearts validity, suit matching
        /// or randoms. According to the tests(if statement) results, a list of valid cards to play will be created 
        /// and used to activate or deactivate the cards(buttons) within the game play area.
        /// </summary>
        /// <param name="currentTrick"></param>
        /// <param name="heartsBroken"></param>
        /// <returns></returns>
        public Card PlayCard(Control control, List <Button> cardButtons, List<Card> currentTrick, bool heartsBroken)
        {
            // Local variables that will be used for validation.
            var nonHeartCards = playerHand.Where(card => card.Suit != "Hearts").ToList();
            // Disable the buttons within the gameplay area.
            DisableCards(control, cardButtons);
            // If this is the first play of the round, player can lead with any card.
            if (currentTrick.Count == 0)
            {
                // Maybe this is the first trick of the round, lets check for the 2 of Clubs.
                Card twoOfClubs = playerHand.Find(card => card.Value == 2 && card.Suit == "Clubs");
                // If the two of clubs is found, we must force the player to play it.
                if (twoOfClubs != null)
                {
                    EnableCards(control, cardButtons, ForceTwoOfClubs(playerHand));
                    return cardInPlay;
                }
                // If, the game trick is starting, but hearts are not broken.
                else if (!heartsBroken || nonHeartCards.Count > 0)
                {
                    // Setting, validating, and waiting for selection when the player cannot play hearts.
                    EnableCards(control, cardButtons, ValidateCards(playerHand, heartsBroken));
                    return cardInPlay;
                }
                // Else, it is further along in the game and it is in free for all.
                else
                {
                    // Setting, validating, and waiting of selection when the player can play any card.
                    EnableCards(control, cardButtons, ValidateCards(playerHand, heartsBroken));
                    return cardInPlay;
                }
            }
            else
            {
                // Otherwise, play a card following the suit, if possible.
                string leadingSuit = currentTrick[0].Suit;
                List <Card> matchingSuits = playerHand.Where(card => card.Suit == leadingSuit).ToList();
                // If no cards of the leading suit are available, play a random card.
                if (matchingSuits.Count == 0)
                {
                    // If, hearts have not been broken and there is atleast 1 card that is not a heart.
                    if (!heartsBroken || nonHeartCards.Count > 0)
                    {
                        // Setting, validating, and waiting for selection when the player cannot play hearts.
                        EnableCards(control, cardButtons, ValidateCards(playerHand, heartsBroken));
                        return cardInPlay;
                    }
                    // Else, hearts and valid or can be broken.
                    else
                    {
                        // Setting, validating, and waiting for selection when the player can play any card.
                        EnableCards(control, cardButtons, ValidateCards(playerHand, heartsBroken));
                        return cardInPlay;
                    }
                }
                // Else, the player can play according to the leading suit.
                else
                {
                    // Setting, validating, and waiting for selection when the player has cards of the same suit.
                    EnableCards(control, cardButtons, ValidateCards(playerHand, leadingSuit)); 
                    return cardInPlay; 
                }
            }
        }

        /// <summary>
        /// This function will format a list of cards that are within the platers hand that are the same suit as 
        /// the suit string provided. 
        /// </summary>
        /// <param name="hand">The hand the player currently possesses.</param>
        /// <param name="suit">The string value of the card suit.</param>
        private List <Card> ValidateCards(List<Card> hand, string suit)
        {
            // This will return a list of the cards that contain the same string suit value as passed to the method.
            return hand.Where(card => card.Suit == suit).ToList();
        }

        /// <summary>
        /// This function will format a list of cards that are within the players hand that are valid to play
        /// according to the rules provided, such as hearts being a valid play or not. This is an overloaded 
        /// version of the above ValidateCards() function that will format a broader list when the user has
        /// no cards of the leading suit.
        /// </summary>
        /// <param name="currentTrick"> The current trick of the game. </param>
        /// <param name="hearts"> The rules that are passed to validate the options. </param>
        private List <Card> ValidateCards(List<Card> hand, bool hearts)
        {
            // If hearts is true, the entire hand is considered valid as the player is in free for all mode.
            if (hearts)
            {
                return hand;
            }
            // Otherwise, the hearts have yet to be broken and the player can select any card BUT hearts.
            else
            {
                return hand.Where(card => card.Suit != "Hearts").ToList();
            }
        }

        /// <summary>
        /// This is a simple function that will for the user to select the two of clubs, since every game of 
        /// Hearts must begin will playing the two of clubs.
        /// </summary>
        /// <param name="hand"></param>
        /// <returns></returns>
        private List <Card> ForceTwoOfClubs(List<Card> hand)
        {
            // Return a list that only contains the two of clubs.
            return hand.Where(card => card.Value == 2 && card.Suit == "Clubs").ToList();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cardButtons"></param>
        public void DisableCards(Control control, List <Button> cardButtons)
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => DisableCards(control, cardButtons)));
                return;
            }
            foreach (var button in cardButtons)
            {
                button.Enabled = false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="control"></param>
        /// <param name="cardButtons"></param>
        /// <param name="validHand"></param>
        private void EnableCards(Control control, List <Button> cardButtons, List<Card> validHand) 
        {
            if (control.InvokeRequired)
            {
                control.Invoke(new Action(() => EnableCards(control, cardButtons, validHand)));
                return;
            }
            for (var i = 0; i < validHand.Count; i++)
            {
                foreach (var button in cardButtons)
                {
                    if (button.Name == validHand[i].NameButton()) 
                    {
                        button.Enabled = true;
                    }
                }
            }
        }
    }
    #endregion
}