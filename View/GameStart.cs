using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace LifeSim.View
{
    public partial class GameStart : Form
    {
        public GameStart()
        {
            InitializeComponent();
        }

        private void randomButton_Click(object sender, EventArgs e)
        {
            var window = new MainGameWindow();
            window.Show();
            this.Close();
        }

        private void inputButton_Click(object sender, EventArgs e)
        {

        }
    }
}
