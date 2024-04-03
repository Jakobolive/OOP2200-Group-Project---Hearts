// Names: Jakob Olive, Troy Mouton
// Start Date: 2024-04-03
// File Desc: This
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
        public GameSetupForm()
        {
            InitializeComponent();
            SetDefault();
        }

        /// <summary>
        /// Method to set all user entries to default.
        /// </summary>
        private void SetDefault()
        {
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
                    if (number < 0 || number > 500)
                    {
                        // Clearing the input and appending error code, as well as returning false.
                        MaxScoreTextBox.Text = string.Empty;
                        MaxScoreTextBox.Focus();
                        outputMessage += "Please Enter A Number Within Range, Between 1 and 500." + Environment.NewLine;
                    }
                }
            }
            // Check if the user selected either player mode, 2 player or 4 player.
            if (NumOfPlayerComboBox.SelectedIndex != -1)
            {
                NumOfPlayerComboBox.Focus();
                outputMessage += "You Must Make A Selection Of Either 2 Or 4 Player Mode." + Environment.NewLine;
            }
            // Check if the user entered something in the PlayerNameTextBox.
            if (PlayerNameTextBox.Text.Trim().Length == 0)
            {
                PlayerNameTextBox.Focus();
                outputMessage += "The Player Name Cannot Be Blank." + Environment.NewLine;
            }
            // Check if the error message is not empty, if so throw Exception.
            if (!string.IsNullOrEmpty(outputMessage))
            {
                throw new Exception(outputMessage);
            }
            // Take data and store data here ...

            // Save selected theme preference (e.g., to application settings)
            //    Properties.Settings.Default.SelectedTheme = cmbThemes.SelectedItem.ToString();
            //    Properties.Settings.Default.Save();
            //    this.Close();
        }
    }
}
