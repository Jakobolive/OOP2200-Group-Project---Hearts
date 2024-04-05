// Names: Jakob Olive, Troy Mouton
// Start Date: 2024-04-03
// File Desc: This 
#region Usings
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion
namespace HeartsCardGame
{
    public partial class HeartsGame : Form
    {
        #region Variables
        private Deck gameDeck;
        private List<Player> players;
        private int currentPlayerIndex;
        private List<Card> currentTrick;
        private string leadingSuit;
        private bool twoPlayerMode;
        private bool heartsBroken = false;
        #endregion
        #region Initialize 
        public HeartsGame()
        {
           InitializeComponent();
           // ApplyTheme();
           SetDefaults();
        }
        #endregion
        #region Button Functions
        /// <summary>
        /// This function will be called when the user selects the Reset Button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetGameButton_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }

        /// <summary>
        /// This function will be called when the user selects the Rules Button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RulesButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This function will be called when the user selects the Exit button.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ExitButton_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// This function will be called when the user selects the play card button, or when the user 
        /// tries to play a card.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PlayCardButton_Click(object sender, EventArgs e)
        {

        }
        #endregion
        #region Code Functions
        /// <summary>
        /// This is a basic method that will set the card game area back to its default state.
        /// </summary>
        private void SetDefaults()
        {
            MaxScoreTextBox.Text = string.Empty;
            NumOfPlayerComboBox.Text = string.Empty;
            HandNumTextBox.Text = string.Empty;
            TrickNumTextBox.Text = string.Empty;
            textBox4.Text = string.Empty;
            textBox5.Text = string.Empty;
            textBox6.Text = string.Empty;
            textBox7.Text = string.Empty;
            textBox8.Text = string.Empty;
            textBox9.Text = string.Empty;
            textBox10.Text = string.Empty;
            textBox11.Text = string.Empty;

            YourHandListView.Items.Clear();
            CurrentTrickListView.Items.Clear();
        }

        ///// <summary>
        ///// This function will apply the style theme that the user selects based off their selection.
        ///// </summary>
        //private void ApplyTheme()
        //{
        // Need to work the two player mode selection into this somehow.
        //    string selectedTheme = Properties.Settings.Default.SelectedTheme;
        //    twoPlayerMode =;
        //    // Apply styles based on selected theme
        //    switch (selectedTheme)
        //    {
        //        /// EXAMPLE THEMES FOR NOW.
        //        case "Dark":
        //            // Apply dark theme
        //            this.BackColor = Color.Black;
        //            // Additional styling for controls
        //            break;
        //        case "Light":
        //            // Apply light theme
        //            this.BackColor = Color.White;
        //            // Additional styling for controls
        //            break;
        //            // Add more cases for additional themes


        private void gameSetup()
        {
            players = new List<Player>
            {
                new AIPlayer("AI Player 1"),
                new AIPlayer("AI Player 2"),
                new AIPlayer("AI Player 3"),
                new HumanPlayer("You")
            };

            currentPlayerIndex = 0;
            currentTrick = new List<Card>();

            DealCards();
            PlayTrick();
        }

        /// <summary>
        /// This function will deal cards from the main deck housed within the Deck class and redistribute them
        /// to the players. This function uses a foreach loop to iterate through the registered players and will
        /// call the Deck.Deal function to populate the players hand accordingly. The cards are divided into
        /// different amounts depending if the user selected 2 or 4 player mode in game setup.
        /// </summary>
        private void DealCards()
        {
            foreach (Player player in players)
            {
                // This could work given that we add a bool variable for twoPlayerMode.
                if (twoPlayerMode == true)
                {
                    for (int I = 0; I < 26; I++)
                    {
                        player.AddCard(gameDeck.Deal());
                    }
                }
                else
                {
                    for (int I = 0; I < 13; I++)
                    {
                        player.AddCard(gameDeck.Deal());
                    }
                }
                //// Change later to suit player functionality due to our 2 or 4 player option.
                //for (int i = 0; i < 13; i++)
                //{
                //    player.AddCard(gameDeck.Deal());
                //}
            }
        }
        /// <summary>
        /// This function is called when the user attempts to play a card, this function will then check if that card is
        /// fit to be played (a valid card as per the rules) and set the trick accordingly. If the card is found to not be 
        /// valid, (suit not broken yet) it will simply return to the last player and allow them to make another selecton.
        /// </summary>
        private void PlayTrick()
        {
            Card card;
            currentTrick = new List<Card>();
            foreach (Player player in players)
            {
                if (player is HumanPlayer)
                {   
                    
                    card = player.PlayCard(currentTrick, heartsBroken);
                }
                else
                {
                    card = player.PlayCard(currentTrick, heartsBroken);
                }

                player.RemoveCard(card);
                currentTrick.Add(card);
                if (leadingSuit == null)
                    leadingSuit = card.Suit;
                // Check if the selected card is a heart, if it is, the hearts are now broken.
                if (card.Suit == "Hearts")
                {
                    heartsBroken = true;
                }
            }
            DetermineTrickWinner();
        }

        /// <summary>
        /// This function will find the winner given the current trick and the cards submitted to the trick.
        /// This function will also distribute the points accordingly as well as display a message to the 
        /// bottom of the playing field.
        /// </summary>
        private void DetermineTrickWinner()
        {
            // Setting the variable for the leading suit and the temp winning card.
            string winningSuit = leadingSuit;
            Card winningCard = currentTrick[0];
            // Setting a winning player to null to be searched for and set later.
            Player winningPlayer = null;
            foreach (Card card in currentTrick)
            {
                // If the suits are the same, but the rank is greater than the trick card, you have a new winner.
                if (card.Suit == winningSuit && card.Value > winningCard.Value)
                {
                    winningCard = card;
                }
            }
            winningPlayer = players.Find(player => player.PlayerHand.Contains(winningCard));
            // Set a message at the bottom of the page and distribute points to the winner.

            leadingSuit = null;
        }
        #endregion
    }
}

