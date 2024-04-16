// Names: Jakob Olive, Troy Mouton
// Start Date: 2024-04-03
// File Desc: This file contains the game setup form as well as all data validation and storage that takes place within it.
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace HeartsCardGame
{
    public partial class GameSetupForm : Form
    {
        #region Setup
        public GameSetupForm()
        {
            InitializeComponent();
            SetDefault();
        }
        #endregion
        #region Variables
        // Properties to hold the setup values.
        public int score { get; private set; }
        public bool twoPlayerMode { get; private set; }
        public string name { get; private set; }
        public string theme { get; private set; }
        // Property to indicate whether setup was submitted.
        public bool SetupSubmitted { get; private set; }
        #endregion
        #region Functions
        /// <summary>
        /// Method to set all user entries to default.
        /// </summary>
        private void SetDefault()
        {
            // Reset the variables.
            theme = string.Empty;
            name = string.Empty;
            twoPlayerMode = false;
            SetupSubmitted = false;
            score = 0;
            // Removing input and selections within TextBoxes and ComboBox.
            MaxScoreTextBox.Text = string.Empty;
            NumOfPlayerComboBox.SelectedIndex = 0;
            PlayerNameTextBox.Text = string.Empty;
            // Setting the default RadioButton, LightRadioButton.
            LightThemeRadioButton.Checked = true;
            // Setting the focus to the first interactive element on the form.
            MaxScoreTextBox.Focus();
        }

        /// <summary>
        /// Method that is called when the user clicks the ResetButton, This method simply calls the
        /// SetDefault() method.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ResetButton_Click(object sender, EventArgs e)
        {
            SetDefault();
        }

        /// <summary>
        /// This method is called when the user attempts to confirm their selection on the setup. The method 
        /// will first validate that the user entered a number for MaxPointsTextBox as well as ensure that
        /// PlayerNameTextBox is not blank, ensuring data validation before anything is stored, This 
        /// method will also store the users theme selection and implement it into the creation of the main
        /// game page.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ConfirmSetupButton_Click(object sender, EventArgs e)
        {
            // Define an empty error string.
            string outputMessage = string.Empty;

            // Check if there is something in the MaxScoreTextBox.
            if (MaxScoreTextBox.Text.Trim().Length != 0)
            {
                // Checking if the input is a int.
                if (!int.TryParse(MaxScoreTextBox.Text, out int value))
                {
                    // Clearing the input and appending error code, as well as returning false.
                    MaxScoreTextBox.Text = string.Empty;
                    MaxScoreTextBox.Focus();
                    outputMessage += "Please Enter A Valid Number." + Environment.NewLine;
                }
                // Checking if the user entered a number higher than the number of cards in deck.
                else if (int.TryParse(MaxScoreTextBox.Text, out int number))
                {
                    if (number < 1 || number > 500)
                    {
                        // Clearing the input and appending error code, as well as returning false.
                        MaxScoreTextBox.Text = string.Empty;
                        MaxScoreTextBox.Focus();
                        outputMessage += "Please Enter A Number Within Range, Between 1 and 500." + Environment.NewLine;
                    }
                    // Input must be a valid number within range. set the score.
                    else
                    {
                        score = number;
                    }
                }
            }
            else
            {
                MaxScoreTextBox.Text = string.Empty;
                MaxScoreTextBox.Focus();
                outputMessage += "The Max Score Input Cannot Be Blank." + Environment.NewLine;
            }
            // Check if the user selected either player mode, 2 player or 4 player.
            if (NumOfPlayerComboBox.SelectedIndex == -1)
            {
                NumOfPlayerComboBox.Focus();
                outputMessage += "You Must Make A Selection Of Either 2 Or 4 Player Mode." + Environment.NewLine;
            }
            // Determine which option to player selected.
            if (NumOfPlayerComboBox.SelectedIndex == 0)
            {
                twoPlayerMode = true;
            }
            else if (NumOfPlayerComboBox.SelectedIndex  == 1)
            {
                twoPlayerMode = false; 
            }
            // Check if the user entered something in the PlayerNameTextBox.
            if (PlayerNameTextBox.Text.Trim().Length == 0)
            {
                PlayerNameTextBox.Focus();
                outputMessage += "The Player Name Cannot Be Blank." + Environment.NewLine;
            }
            // The user must have entered valid data, set the name.
            else
            {
                name = PlayerNameTextBox.Text;
            }
            // Series of if, else if statements that will check each radio button and set the theme accordingly
            if (LightThemeRadioButton.Checked)
            {
                theme = LightThemeRadioButton.Tag.ToString();
            }
            else if (DarkThemeRadioButton.Checked)
            {
                theme = DarkThemeRadioButton.Tag.ToString();
            }
            else if (CardsThemeRadioButton.Checked)
            {
                theme = CardsThemeRadioButton.Tag.ToString();
            }
            else if (GUIThemeRadioButton.Checked)
            {
                theme = GUIThemeRadioButton.Tag.ToString();
            }
            // Check if there is a theme selected.
            if(theme.Length == 0)
            {
                outputMessage += "You Must Select A Theme You Wish To Play." + Environment.NewLine;
            }
            // Check if the error message is not empty, if so throw Exception.
            if (!string.IsNullOrEmpty(outputMessage))
            {
                MessageBox.Show(outputMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            // Else, the data must be valid.
            else
            {
                // Set SetupSubmitted to true.
                SetupSubmitted = true;
                DialogResult = DialogResult.OK;
                // Close this form.
                Close();
            }
        }
        #endregion
    }
}
