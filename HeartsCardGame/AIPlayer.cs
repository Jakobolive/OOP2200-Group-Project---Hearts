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
    internal class AIPlayer : Player
    {
        #region Variables
        // Setting a general Random Instance for the AI player to use.
        private Random AIRandom;
        #endregion
        #region Constructor
        /// <summary>
        /// Base constructor that sets the name of the AIPlayer as well as initializes a Random object to be used.
        /// </summary>
        /// <param name="newPlayerName"></param>
        public AIPlayer(string newPlayerName) : base(newPlayerName)
        {
            AIRandom = new Random();
        }
        #endregion
        #region Functions
        /// <summary>
        /// This function provides a sort of validation and theory to the AI Players within the game. This function
        /// is the guide for how the AI decides upon, and makes valid choices regarding the cards they can play.
        /// The players hand will be manipulated, finding both like suits and heart cards to assign validity
        /// to the AI Players selection, and then call a function to return a valid card accordingly.
        /// </summary>
        /// <param name="currentTrick"></param>
        /// <returns></returns>
        public override Card PlayCard(List<Card> currentTrick, bool heartsBroken)
        {
            // Maybe this is the first trick of the round, lets check for the 2 of Clubs.
            Card twoOfClubs = playerHand.Find(card => card.Value == 2 && card.Suit == "Clubs");
            // If this is the first play of the round, AI player can lead with any card.
            if (currentTrick.Count == 0)
            {
                // If the two of clubs is found, we must force the AI player to play it.
                if (twoOfClubs != null)
                {
                    return twoOfClubs;
                }
                else 
                {
                    return LeadCard();
                }
            }
            else
            {
                // Otherwise, play a card following the suit led, if possible.
                string leadingSuit = currentTrick[0].Suit;
                var playableCards = GetPlayableCards(leadingSuit);

                // If no cards of the led suit are available, play a random card.
                if (playableCards.Count == 0)
                {
                    // Check if hearts are invalid to play at this time.
                    var nonHeartCards = playerHand.Where(card => card.Suit != "Hearts").ToList();
                    if (!heartsBroken || nonHeartCards.Count > 0)
                    {
                        return RandomCardWOHearts();
                    }
                    // Otherwise, Hearts can be played.
                    else 
                    {
                        return RandomCard();
                    }
                }
                else
                {
                    // Otherwise, play the lowest card of the led suit
                    return playableCards.OrderBy(card => card.Value).First();
                }
            }
        }

        /// <summary>
        /// This function will assist the AI Player in picking a lead card. The function will first look if the 
        /// players hand contains anything other than hearts, as it is not wise to open with a losing card. If the
        /// player has no choice but to start with a heart, it will selected the card of the lowest value.
        /// </summary>
        /// <returns></returns>
        private Card LeadCard()
        {
            // If AI player is leading the round, play the lowest non-heart card.
            var nonHeartCards = playerHand.Where(card => card.Suit != "Hearts").ToList();
            if (nonHeartCards.Count > 0)
            {
                return nonHeartCards.OrderBy(card => card.Value).First();
            }
            // If the AI player has only hearts, play the lowest heart card.
            else
            {
                return playerHand.OrderBy(card => card.Value).First();
            }
        }

        /// <summary>
        /// This function will create a list of playable cards for the AI to selection from. This function
        /// employs different checks to test if a list can be made of the matching suit, if this fails, the AI
        /// will try to do anything to prevent itself from playing a heart card, if it can be avoided.
        /// </summary>
        /// <param name="suit"></param>
        /// <returns></returns>
        private List<Card> GetPlayableCards(string suit)
        {
            // Get all cards in hand that match the given suit.
            var matchingSuitCards = playerHand.Where(card => card.Suit == suit).ToList();
            // If the player doesn't have cards of the given suit, return an empty list.
            if (matchingSuitCards.Count == 0)
            {
                return new List<Card>();
            }
            // Check if the player can follow suit without playing hearts.
            var nonHeartCards = matchingSuitCards.Where(card => card.Suit != "Hearts").ToList();
            if (nonHeartCards.Count > 0)
            {
                return nonHeartCards;
            }
            // If the player has only hearts in the given suit, return all cards of that suit.
            else
            {
                return matchingSuitCards;
            }
        }

        /// <summary>
        /// This function simply selects a random card from the players hand, hearts included.
        /// </summary>
        /// <returns></returns>
        private Card RandomCard()
        {
            // Play a random card from the hand.
            return playerHand[AIRandom.Next(playerHand.Count)];
        }

        /// <summary>
        /// This function selects a random card from a list of the entire players hand, excluding the hearts.
        /// </summary>
        /// <returns></returns>
        private Card RandomCardWOHearts()
        {
            // Play a random card from the hand where the suit is not hearts.
            return playerHand[AIRandom.Next(playerHand.Count)];
        }
        #endregion
    }
}