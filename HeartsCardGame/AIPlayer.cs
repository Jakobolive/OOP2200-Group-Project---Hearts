// Names: Jakob Olive, Troy Mouton
// Start Date: 2024-04-03
// File Desc: This File will contain the AI player theory used within the game, from valid list creation to validation and 
// decision making involved in playing the card.
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
        #region Constructor
        /// <summary>
        /// Base constructor that sets the name of the AIPlayer..
        /// </summary>
        /// <param name="newPlayerName"></param>
        public AIPlayer(string newPlayerName) : base(newPlayerName)
        {
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
                    return LeadCard(currentTrick, heartsBroken);
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
                    if (!heartsBroken && nonHeartCards.Count > 0)
                    {
                        return RandomCardWOHearts(nonHeartCards, currentTrick, heartsBroken);
                    }
                    // Otherwise, Hearts can be played.
                    else 
                    {
                        heartsBroken = true;
                        return RandomCard(currentTrick, heartsBroken);
                    }
                }
                else
                {
                    // Sort playable cards based on a scoring system.
                    var sortedCards = playableCards.OrderByDescending(card => CardScore(card, currentTrick)).ToList();
                    // Choose the highest scoring card, considering risk.
                    return ChooseCardConsideringRisk(sortedCards, currentTrick, heartsBroken);
                }
            }
        }

        /// <summary>
        /// This function will assist the AI Player in picking a lead card. The function will first look if the 
        /// players hand contains anything other than hearts, as it is not wise to open with a losing card. If the
        /// player has no choice but to start with a heart, it will selected the card of the lowest value.
        /// </summary>
        /// <returns></returns>
        private Card LeadCard(List<Card> currentTrick, bool heartsBroken)
        {
            // If AI player is leading the round, play the lowest non-heart card.
            var nonHeartCards = playerHand.Where(card => card.Suit != "Hearts").ToList();
            if (nonHeartCards.Count > 0)
            {
                // Sort playable cards based on a scoring system.
                var sortedCards = nonHeartCards.OrderByDescending(card => CardScore(card, currentTrick)).ToList();
                // Choose the highest scoring card, considering risk.
                return ChooseCardConsideringRisk(sortedCards, currentTrick, heartsBroken);
            }
            // If the AI player has only hearts, play the lowest heart card.
            else
            {
                // Sort playable cards based on a scoring system.
                var sortedCards = playerHand.OrderByDescending(card => CardScore(card, currentTrick)).ToList();
                // Choose the highest scoring card, considering risk.
                return ChooseCardConsideringRisk(sortedCards, currentTrick, heartsBroken);
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
        private Card RandomCard(List<Card> currentTrick, bool heartsBroken)
        {
            // Sort playable cards based on a scoring system.
            var sortedCards = playerHand.OrderByDescending(card => CardScore(card, currentTrick)).ToList();
            // Choose the highest scoring card, considering risk.
            return ChooseCardConsideringRisk(sortedCards, currentTrick, heartsBroken);
        }

        /// <summary>
        /// This function selects a random card from a list of the entire players hand, excluding the hearts.
        /// </summary>
        /// <returns></returns>
        private Card RandomCardWOHearts(List<Card> nonHeartCards, List<Card> currentTrick, bool heartsBroken)
        {
            // Sort playable cards based on a scoring system.
            var sortedCards = nonHeartCards.OrderByDescending(card => CardScore(card, currentTrick)).ToList();
            // Choose the highest scoring card, considering risk.
            return ChooseCardConsideringRisk(sortedCards, currentTrick, heartsBroken);
        }

        /// <summary>
        /// Chooses the card to play considering risk management.
        /// </summary>
        /// <param name="sortedPlayableCards">List of playable cards sorted by score.</param>
        /// <param name="currentTrick">Current trick being played.</param>
        /// <param name="heartsBroken">Whether hearts have been broken.</param>
        /// <returns>The selected card to play.</returns>
        private Card ChooseCardConsideringRisk(List<Card> sortedPlayableCards, List<Card> currentTrick, bool heartsBroken)
        {
            // Check if leading with certain cards poses a risk.
            foreach (Card card in sortedPlayableCards)
            {
                // Check if leading with a heart card is risky.
                if (card.Suit == "Hearts")
                {
                    // If hearts have not been broken and leading with a heart card would cause hearts to break, avoid it.
                    if (!heartsBroken && WillLeadToHeartsBreak(card, currentTrick))
                    {
                        continue; // Skip this card and proceed to the next one.
                    }
                }
                // If no risk is identified, play the card.
                return card;
            }
            // If all playable cards pose a risk, play the lowest scoring card (least risky).
            return sortedPlayableCards.Last();
        }

        /// <summary>
        /// Checks if leading with a heart card would cause hearts to break, risk assessment.
        /// </summary>
        /// <param name="heartCard">The heart card being considered.</param>
        /// <param name="currentTrick">Current trick being played.</param>
        /// <returns>True if leading with the heart card would cause hearts to break; otherwise, false.</returns>
        private bool WillLeadToHeartsBreak(Card heartCard, List<Card> currentTrick)
        {
            // Determine if the heart card will be the highest card in the trick.
            foreach (Card card in currentTrick)
            {
                if (card.Suit == "Hearts" && card.Value > heartCard.Value)
                {
                    return true; // Leading with the heart card will cause hearts to break.
                }
            }
            return false; // Leading with the heart card will not cause hearts to break.
        }

        /// <summary>
        /// Assigns a danger score to a card based on its value and suit to allow the AI to make a better decision.
        /// </summary>
        /// <param name="card">The card to score.</param>
        /// <returns>The danger score of the card.</returns>
        private int CardScore(Card card, List<Card> trick)
        {
            //// Start by setting the danger score to the cards value.
            //int score = card.Value;
            //// Checking if the card will be the lead.
            //if (trick.Count == 0)
            //{
            //    // Leading with the queen of spades assumes the greatest risk.
            //    if (card.Suit == "Spades" && card.Value == 12)
            //    {
            //        score += 10;
            //    }
            //    // Leading with hearts also assumes fair risk, best to be avoided.
            //    else if (card.Suit == "Hearts")
            //    {
            //        score += 8;
            //    }
            //}
            //// Otherwise, it will not lead the trick, therefore it is not such a risk if a danger card appears.
            //else if (card.Suit == "Hearts" || card.Suit == "Spades" && card.Value == 12)
            //{
            //    score += 4;
            //}
            //return score;
            // Start by setting the danger score to the card's value.
            int score = card.Value;
            // Check if the card will lead the trick.
            if (trick.Count == 0)
            {
                // Leading with certain cards assumes a higher risk.
                if (card.Suit == "Spades" && card.Value == 12) // Queen of Spades.
                {
                    score += 10; // Assume high risk.
                }
                else if (card.Suit == "Hearts")
                {
                    score += 8; // Assume moderate risk.
                }
            }
            else
            {
                // For non-leading cards, consider the suit and value.
                if (card.Suit == "Hearts" || (card.Suit == "Spades" && card.Value == 12))
                {
                    score += 4; // Assume some risk.
                }
            }
            return score;
        }
        #endregion
    }
}