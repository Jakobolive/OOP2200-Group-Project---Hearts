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
        public override Card PlayCard(List<Card> currentTrick, bool heartsBroken)
        {
            
        }

        private void ValidateCards(List<Card> currentTrick)
        {
            
        }

        private void EnableValidCards() 
        {
            
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
        //    Console.Writeine();
        //}L
    }
    #endregion
}