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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
#endregion
namespace HeartsCardGame
{
    public partial class HeartsGame : Form
    {
        #region Variables
        private SemaphoreSlim semaphore = new SemaphoreSlim(0);
        private int trickCount = 0;
        private int handCount = 0;
        private int currentIndex = 0;
        private Deck gameDeck = new Deck();
        private HumanPlayer user = new HumanPlayer("You");
        private List<Player> players;
        private List<Button> CardButtons = new List<Button>();
        private List<Button> trickList = new List<Button>();
        private List<Card> currentTrick = new List<Card>();
        private int winningPoints;
        private string leadingSuit;
        private bool twoPlayerMode = false;
        private bool heartsBroken = false;
        #endregion
        #region Initialize 
        public HeartsGame()
        {
           InitializeComponent();
           // ApplyTheme();
           GameSetup();
        }
        #endregion
        #region Code Functions
        /// <summary>
        /// This is a basic method that will set the card game area back to its default state.
        /// </summary>
        private void SetDefaults()
        {
            DeleteTrick(trickList);
            DeleteTrick(CardButtons);
            trickCount = 0;
            handCount = 0;
            currentIndex = 0;
            GameSetup();
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
                user,
                new AIPlayer("AI Player 1"),
                new AIPlayer("AI Player 2"),
                new AIPlayer("AI Player 3")
            };
            // Update the GUI with the names.
            Player1Label.Text = players[0].PlayerName + ":";
            Player2Label.Text = players[1].PlayerName + ":";
            // If it is not two player mode, we can add the third and fourth player.
            if (!twoPlayerMode) 
            {
                Player3Label.Text = players[2].PlayerName + ":";
                Player4Label.Text = players[3].PlayerName + ":";
            }
            DealCards();
            DisplayHand(user);
            // First, find the player to start with.
            int startIndex = FindLead(players);
            currentIndex = startIndex;

        }

        /// <summary>
        /// This method will first sort the players cards provided by suit and value and then enter a foreach loop
        /// to create the buttons on the page. The loop creates the buttons, manipulated properties of the button, as 
        /// well as adds it to a list of buttons for later use.
        /// </summary>
        private void DisplayHand(HumanPlayer humanPlayer)
        {
            // Execute this method on the UI thread.
            if (InvokeRequired)
            {
                Invoke(new Action(() => DisplayHand(humanPlayer)));
                return;
            }
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
                button.Click += (sender, e) => SelectCard(button);
                button.Enabled = false;
                HandFlowLayoutPanel.Controls.Add(button);
                // Adding the new button to the list of buttons for easy access and manipulation.
                CardButtons.Add(button);
            }
        }

        private void DeleteCardFromHand(List<Button> cardButtons, Card cardToDelete)
        {
            // Execute this method on the UI thread.
            if (InvokeRequired)
            {
                Invoke(new Action(() => DeleteCardFromHand(cardButtons, cardToDelete)));
                return;
            }
            // A foreach loop that will iterate through the buttons in the list and remove them from the parent container and dispose of them.
            foreach (Button button in cardButtons)
            {
                if (button.Name == cardToDelete.NameButton())
                {
                    if (button.Parent != null)
                    {
                        button.Parent.Controls.Remove(button);
                        button.Dispose();
                    }
                }
            }
        }

        /// <summary>
        /// This function will create the card buttons and add them to the trick flow panel. 
        /// </summary>
        /// <param name="trick"></param>
        /// <returns></returns>
        private void ShowTrick(List <Card> trick)
        {
            // Execute this method on the UI thread.
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowTrick(trick)));
                return;
            }
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
        }

        /// <summary>
        /// This function will dynamically delete the buttons that were used to display the trick.
        /// </summary>
        /// <param name="trickCards"></param>
        private void DeleteTrick(List <Button> trickCards)
        {
            // Execute this method on the UI thread.
            if (InvokeRequired)
            {
                Invoke(new Action(() => DeleteTrick(trickCards)));
                return;
            }
            // A foreach loop that will iterate through the buttons in the list and remove them from the parent container and dispose of them.
            foreach (Button button in trickCards)
            {
                if (button.Parent != null)
                {
                    button.Parent.Controls.Remove(button);
                    button.Dispose();
                }
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
                    Console.WriteLine("Lead Has Been Found");
                    return index;
                }
            }
            // Else, return -1, the code should never make it here.
            return -1;
        }

        /// <summary>
        /// This method will call other methods as well as manage its own theory to manage the gameplay and report winners.
        /// </summary>
        private async void CommenceGameplay()
        {
            // Boolean that will hold true only once a winner is found and the game is over.
            bool winnerFound = false;
            Console.WriteLine("Entering While Loop");
            await Task.Run(async () =>
            {
                while (!winnerFound)
                {
                    await PlayTrick();
                    // End of match
                    foreach (Player player in players)
                    {
                        if (player.PlayerPoints >= 100)
                        {
                            // Do winner stuff here.
                            winnerFound = true;
                            break;
                        }
                    }
                }
            });
        }

        /// <summary>
        /// This function is called when the user attempts to play a card, this function will then check if that card is
        /// fit to be played (a valid card as per the rules) and set the trick accordingly. If the card is found to not be 
        /// valid, (suit not broken yet) it will simply return to the last player and allow them to make another selection.
        /// </summary>
        private async Task PlayTrick()
        {
            // Initialize the card in hand.
            Card card;
            // Foreach loop that ensures every player in the game plays a card.
            for (int index = 0; index < players.Count; index++)
            {
                // Await the card from the play card function.
                Console.WriteLine("Playing Trick Number: " + (index+1).ToString());
                card = await PlayCard(players[currentIndex]);
                
                //players[currentIndex].RemoveCard(card);
                currentTrick.Add(card);
                DeleteTrick(trickList);
                // Show or update the current trick on the screen for UI interaction.
                ShowTrick(currentTrick);
                // If the card is the first of the currentTrick, set the leading suit.
                if (leadingSuit == null)
                {
                    leadingSuit = card.Suit;
                }
                // Check if the selected card is a heart, if it is, the hearts are now broken.
                if (card.Suit == "Hearts")
                {
                    heartsBroken = true;
                }
                currentIndex = (currentIndex + 1) % players.Count;
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
        private async Task<Card> PlayCard(Player player)
        {
            // If the players name matches the users name, it must be the user.
            if (player.PlayerName == user.PlayerName)
            {
                Console.WriteLine("Human Player Turn");
                user.PlayCard(this ,CardButtons, currentTrick, heartsBroken);
                await WaitForPlayerInput();
                return user.CardInPlay;
            }
            // Otherwise, it must be the AI.
            else
            {
                // Call a short delay so we can actually see the GUI do things.
                Console.WriteLine("AI Player Turn");
                await Task.Delay(5000); // 5000 milliseconds = 5 seconds
                return player.PlayCard(currentTrick, heartsBroken);
            }
        }

        /// <summary>
        /// This is a task that allows the application to wait until the user makes a selection, it uses a Semaphore lock that is released
        /// later on once the user makes a selection.
        /// </summary>
        /// <returns></returns>
        private async Task WaitForPlayerInput()
        {
            // Wait until the cardInPlay is set
            await semaphore.WaitAsync(); 
        }

        /// <summary>
        /// This function releases the Semaphore lock that is waited on in the above function and sets the users card to the
        /// card provided.
        /// </summary>
        /// <param name="button"></param>
        private void SelectCard(Button button)
        {
            foreach (Card card in user.PlayerHand)
            {
                if (button.Name == card.NameButton())
                {
                    // Set the card and release the semaphore to unblock the WaitForPlayerInput method
                    user.CardInPlay = card;
                    semaphore.Release();
                }
            }
        }

        /// <summary>
        /// This function will find the winner given the current trick and the cards submitted to the trick.
        /// This function will also distribute the points accordingly as well as display a message to the 
        /// bottom of the playing field.
        /// </summary>
        private void DetermineTrickWinner()
        {
            // Incrementing the trick count.
            trickCount++;
            // Setting the variable for the leading suit and the temp winning card as well as the points.
            string winningSuit = leadingSuit;
            Card winningCard = currentTrick[0];
            // Resetting the winning points variable to 0.
            winningPoints = 0;
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
            // Foreach loop that iterates through the cards in the trick and adds the corresponding point value to the winner.
            foreach (Card card in currentTrick)
            {
                winningPoints += card.PointValue;
            }
            // Trick point distribution.
            winningPlayer = players.Find(player => player.PlayerHand.Contains(winningCard));
            winningPlayer.PlayerPoints += winningPoints;
            // Getting the winners index in the list and setting it to Current index.
            currentIndex = players.FindIndex(player => player.PlayerHand.Contains(winningCard));
            // Update UI on the UI thread
            this.Invoke((MethodInvoker)delegate
            {
                // Set a message to announce the winner of the trick.
                MessageLabel.Text = winningPlayer.PlayerName + " Won The Trick With A Total Of " + winningPoints + " Points!";
            });
            // Foreach loop that loops through all players attempting to delete a card from their hand, that is in the trick.
            foreach (Player player in players)
            {
                // Iterate through each card in the list of cards to search for
                foreach (Card cardInQuestion in currentTrick)
                {
                    // Find the card within the player's hand that matches the card in the list
                    Card cardToDelete = player.PlayerHand.Find(card => card.Suit == cardInQuestion.Suit && card.Value == cardInQuestion.Value);
                    if (cardToDelete != null)
                    {
                        // Calling the remove card button, also removing the button if the player is the user.
                        player.RemoveCard(cardToDelete);
                        if (player.PlayerName == user.PlayerName)
                        {
                            DeleteCardFromHand(CardButtons, cardToDelete);
                        }
                    }
                }
            }
            // Checking if players have run out of cards, the game is not over yet, so more must be dealt.
            foreach (Player player in players)
            {
                if (player.PlayerHand.Count == 0)
                {
                    // Incrementing the hand count.
                    handCount++;
                    // Rebuild the deck and deal cards again.
                    gameDeck.BuildDeck();
                    DealCards();
                    FindLead(players);
                    // Display new hand for user.
                    DisplayHand(user);
                    break; // Exit loop after handling one player's empty hand.
                }
            }
            // Resetting variables used within this function.
            currentTrick.Clear();
            leadingSuit = null;
            // Invoking so we can access the controls.
            this.Invoke((MethodInvoker)delegate
            {
                // Updating the leaderboards.
                Score1TextBox.Text = players[0].PlayerPoints.ToString();
                Score2TextBox.Text = players[1].PlayerPoints.ToString();
                // If it is not two player mode, update the other players stats as well.
                if(!twoPlayerMode)
                {
                    Score3TextBox.Text = players[2].PlayerPoints.ToString();
                    Score4TextBox.Text = players[3].PlayerPoints.ToString();
                }
                TrickNumTextBox.Text = trickCount.ToString();
                HandNumTextBox.Text = handCount.ToString();
            });
        }
        #endregion
        #region Button Functions

        private void StartGameButton_Click(object sender, EventArgs e)
        {
            CommenceGameplay();
        }


        private void ResetGameButton_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }


        private void RulesButton_Click(object sender, EventArgs e)
        {

        }


        private void ExitButton_Click(object sender, EventArgs e)
        {

        }
        

        private void StartGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CommenceGameplay();
        }


        private void ResetGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetDefaults();
        }


        private void RulesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
        #endregion
    }
}

