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
        private Deck gameDeck = new Deck();
        private List<Player> players;
        private List<Button> CardButtons;
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
           GameSetup();
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


        private void GameSetup()
        {
            gameDeck.BuildDeck();
            players = new List<Player>
            {
                new HumanPlayer("You"),
                new AIPlayer("AI Player 1"),
                new AIPlayer("AI Player 2"),
                new AIPlayer("AI Player 3")
            };

            currentPlayerIndex = 0;
            currentTrick = new List<Card>();

            DealCards();
            DisplayHand((HumanPlayer)players[0]);
            //PlayTrick();
        }

        /// <summary>
        /// This method will first sort the players cards provided by suit and value and then enter a foreach loop
        /// to create the buttons on the page. The loop creates the buttons, manipulated properties of the button, as 
        /// well as adds it to a list of buttons for later use.
        /// </summary>
        private void DisplayHand(HumanPlayer humanPlayer)
        {
            // Sort the player's hand by suit and then by value to be more like an actual card game.
            var sortedHand = humanPlayer.PlayerHand.OrderBy(card => card.Suit).ThenBy(card => card.Value);
            // A foreach loop that dynamically builds the card buttons as per the players hand.
            foreach (Card card in sortedHand)
            {
                // Creating, adding text to, sizing, naming, attaching functionality, and placing the button.
                Button button = new Button();
                button.Text = card.ToString();
                button.Size = new Size(75, 125); 
                button.Name = card.NameButton(); 
                // button.Click += (sender, e) => 
                HandFlowLayoutPanel.Controls.Add(button);
                // Adding the new button to the list of buttons for easy access and manipulation.
                CardButtons.Add(button);
            }
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
                // If the player wishes to only play against 1 AI Player.
                if (twoPlayerMode == true)
                {
                    for (int I = 0; I < 26; I++)
                    {
                        player.AddCard(gameDeck.Deal());
                    }
                }
                // Otherwise, the player wishes to play against 3 AI Players and it is a normal game.
                else
                {
                    for (int I = 0; I < 13; I++)
                    {
                        player.AddCard(gameDeck.Deal());
                    }
                }
                
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
                card = player.PlayCard(currentTrick, heartsBroken);
                // Commit to the card transaction.
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

