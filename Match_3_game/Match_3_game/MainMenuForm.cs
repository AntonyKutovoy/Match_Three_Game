using System;
using System.Drawing;
using System.Windows.Forms;

namespace Match_3_game
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            var gameForm = new GameForm();
            gameForm.FormClosed +=  (s, e) => { this.Show(); };
            gameForm.Show();
            Hide();
        }
    }
}
