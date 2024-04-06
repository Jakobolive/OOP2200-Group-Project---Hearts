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
        private List<Button> CardButtons = new List<Button>();
        private List<Button> trickList = new List<Button>();
        private List<Card> currentTrick;
        private int winningPoints;
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
        #region Code Functions
        /// <summary>
        /// This is a basic method that will set the card game area back to its default state.
        /// </summary>
        private void SetDefaults()
        {
            // do later ig.
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

        /// <summary>
        /// This function will build the deck, create the players as well as deal them cards, This function
        /// will also handle initially displaying the users cards before the user decides to start the game.
        /// </summary>
        private void GameSetup()
        {
            gameDeck.BuildDeck();
            // Player creation.
            players = new List<Player>
            {
                new HumanPlayer("You"),
                new AIPlayer("AI Player 1"),
                new AIPlayer("AI Player 2"),
                new AIPlayer("AI Player 3")
            };
            // Update the GUI with the names.
            Player1Label.Text = players[0].PlayerName + ":";
            Player2Label.Text = players[1].PlayerName + ":";
            Player3Label.Text = players[2].PlayerName + ":";
            Player4Label.Text = players[3].PlayerName + ":";
            DealCards();
            DisplayHand((HumanPlayer)players[0]);
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
        /// This function will create the card buttons and add them to the trick flow panel. 
        /// </summary>
        /// <param name="trick"></param>
        /// <returns></returns>
        private List <Button> ShowTrick(List <Card> trick)
        {
            foreach (Card card in trick)
            {
                // Creating, adding text to, sizing, naming, attaching functionality, and placing the button.
                Button button = new Button();
                button.Text = card.ToString();
                button.Size = new Size(75, 125);
                button.Name = card.NameButton();
                button.Enabled = false;
                TrickFlowLayoutPanel.Controls.Add(button);
                // Adding the button to a list so it can be deleted later.
                trickList.Add(button);

            }
            return trickList;
        }

        /// <summary>
        /// This function will dynamically delete the buttons that were used to display the trick.
        /// </summary>
        /// <param name="trickCards"></param>
        private void DeleteTrick(List <Button> trickCards)
        {
            // A foreach loop that will iterate through the buttons in the list and remove them from the parent container and dispose of them.
            foreach (Button button in trickCards)
            {
                button.Parent.Controls.Remove(button);
                button.Dispose();
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
        /// This method gets called when a new round begins, it is intended to search for the player that has 
        /// the two of clubs in their hand, and return the player.
        /// </summary>
        /// <param name="player"></param>
        /// <returns>Index to start the game for loop.</returns>
        private int FindLead(List <Player> players)
        {
            // For loop that will iterate through the players in the list and find the specific card.
            for (int index = 0; index < players.Count; index++)
            {
                Player player = players[index];
                // Create a card variable that can only be set if the two of clubs is found.
                Card twoOfClubs = player.PlayerHand.Find(card => card.Value == 2 && card.Suit == "Clubs");
                // If the two of clubs is found, we will return the player.
                if (twoOfClubs != null)
                {
                    return index;
                }
            }
            // Else, return -1, the code should never make it here.
            return -1;
        }

        /// <summary>
        /// This method will call other methods as well as manage its own theory to manage the gameplay and report winners.
        /// </summary>
        private void CommenceGameplay()
        {
            // First, find the player to start with.
            int startIndex = FindLead(players);
            int currentIndex = startIndex;
            // Boolean that will hold true only once a winner is found and the game is over.
            bool winnerFound = false;
            while (!winnerFound)
            {
                // Iterate over the list starting from the currentIndex provided
                for (int index = 0; index < players.Count; index++)
                {
                    PlayTrick();
                    // Increment currentIndex with modular arithmetic to loop back to the starting location
                    currentIndex = (currentIndex + 1) % players.Count;
                }
                // End of match
                foreach (Player player in players)
                {
                    if (player.PlayerPoints >= 100)
                        // Do winner stuff here.
                        winnerFound = true;
                }
            }
        }

        /// <summary>
        /// This function is called when the user attempts to play a card, this function will then check if that card is
        /// fit to be played (a valid card as per the rules) and set the trick accordingly. If the card is found to not be 
        /// valid, (suit not broken yet) it will simply return to the last player and allow them to make another selection.
        /// </summary>
        private void PlayTrick()
        {
            // Initialize the card in hand.
            Card card;
            // Foreach loop that ensures every player in the game plays a card.
            foreach (Player player in players)
            {
                card = PlayCard(player);
                // Commit to the card transaction.
                player.RemoveCard(card);
                currentTrick.Add(card);
                // If the card is the first of the currentTrick, set the leading suit.
                if (leadingSuit == null)
                    leadingSuit = card.Suit;
                // Check if the selected card is a heart, if it is, the hearts are now broken.
                if (card.Suit == "Hearts")
                {
                    heartsBroken = true;
                }
                // Show or update the current trick on the screen for UI interaction.
                ShowTrick(currentTrick);
            }
            DetermineTrickWinner();
        }

        /// <summary>
        /// This method is used for each player to access the PlayCard() functions from either the AI Player
        /// or the HumanPlayer class, As they differ quite a bit,(overloaded and overridden functions) they
        /// need to be called differently.
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        private Card PlayCard(Player player)
        {
            // If the player is of the Human Player class, cast them to a HumanPlayer and call the PlayCard() Method.
            if (player is HumanPlayer)
            {
                HumanPlayer humanPlayer = (HumanPlayer)player;
                return humanPlayer.PlayCard(CardButtons, currentTrick, heartsBroken);
            }
            // Otherwise, they must be an AI Player, no extra conversion is needed.
            else
            {
                return player.PlayCard(currentTrick, heartsBroken);
            }
        }

        /// <summary>
        /// This function will find the winner given the current trick and the cards submitted to the trick.
        /// This function will also distribute the points accordingly as well as display a message to the 
        /// bottom of the playing field.
        /// </summary>
        private void DetermineTrickWinner()
        {
            // Setting the variable for the leading suit and the temp winning card as well as the points.
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
            foreach (Card card in currentTrick)
            {
                card.PointValue += winningPoints;
            }
            // Trick point distribution.
            winningPlayer = players.Find(player => player.PlayerHand.Contains(winningCard));
            winningPlayer.PlayerPoints = winningPlayer.PlayerPoints + winningPoints;
            // Set a message to announce the winner of the trick.
            MessageLabel.Text = winningPlayer.PlayerName + " Wins The Trick With A Total Of " + winningPoints + " Points!";
            leadingSuit = null;
        }
        #endregion
    }
}

