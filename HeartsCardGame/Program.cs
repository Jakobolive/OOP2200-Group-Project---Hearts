using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HeartsCardGame
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        //[STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new HeartsGame());
        //}
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // Create an instance of GameSetupForm
            GameSetupForm gameSetupForm = new GameSetupForm();

            // Show the GameSetupForm
            Application.Run(gameSetupForm);

            // After the GameSetupForm is closed, check if setup was submitted
            if (gameSetupForm.SetupSubmitted)
            {
                // Create an instance of MainForm and pass the setup values
                HeartsGame mainForm = new HeartsGame(gameSetupForm.score, gameSetupForm.twoPlayerMode, gameSetupForm.name, gameSetupForm.theme);

                // Show the MainForm
                Application.Run(mainForm);
            }
        }
    }
}
