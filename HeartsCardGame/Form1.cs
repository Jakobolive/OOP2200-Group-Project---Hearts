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

namespace HeartsCardGame
{
    public partial class HeartsGame : Form
    {
        public HeartsGame()
        {
           InitializeComponent();
           // ApplyTheme();
           SetDefaults();
        }
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

       
        ///// <summary>
        ///// This function will apply the style theme that the user selects based off their selection.
        ///// </summary>
        //private void ApplyTheme()
        //{
        //    string selectedTheme = Properties.Settings.Default.SelectedTheme;

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
        //    }
        //}

        //
