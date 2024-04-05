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
        /// 
        /// </summary>
        /// <param name="currentRound"></param>
        /// <returns></returns>
        public override Card PlayCard(List<Card> currentRound, bool heartsBroken)
        {
            // If this is the first play of the round, AI player can lead with any card.
            if (currentRound.Count == 0)
            {
                return LeadCard();
            }
            else
            {
                // Otherwise, play a card following the suit led, if possible.
                string leadingSuit = currentRound[0].Suit;
                var playableCards = GetPlayableCards(leadingSuit);

                // If no cards of the led suit are available, play a random card.
                if (playableCards.Count == 0)
                {
                    return RandomCard();
                }
                else
                {
                    // Otherwise, play the lowest card of the led suit
                    return playableCards.OrderBy(card => card.Value).First();
                }
            }
        }

        /// <summary>
        /// 
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
        /// 
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
        /// 
        /// </summary>
        /// <returns></returns>
        private Card RandomCard()
        {
            // Play a random card from the hand.
            return playerHand[AIRandom.Next(playerHand.Count)];
        }
        #endregion
    }
}