using LifeSim.Model;
using System.Windows.Forms;

namespace LifeSim.View
{
    public partial class LicenseQuestionsWindow : Form
    {
        #region Fields

        LicenseQuestionsModel lqmodel; // LicenseQuestions játékmodell
        LifeSimModel lsmodel; // LifeSim játékmodell

        #endregion

        #region Constructor

        /// <summary>
        /// Jogosítvány ablak példányosítása.
        /// </summary>
        /// /// <param name="lsmodel">Játékmodell a példányosításhoz.</param>
        public LicenseQuestionsWindow(LifeSimModel lsmodel)
        {
            InitializeComponent();
            this.lsmodel = lsmodel;
        }

        #endregion

        private void LicenseQuestionsWindow_Shown(object sender, System.EventArgs e)
        {
            lqmodel = new LicenseQuestionsModel();
            questionLabel.Text = lqmodel.Question;
        }

        private void aButton_Click(object sender, System.EventArgs e)
        {
            checkAnswer(0);
        }

        private void bButton_Click(object sender, System.EventArgs e)
        {
            checkAnswer(1);
        }

        private void cButton_Click(object sender, System.EventArgs e)
        {
            checkAnswer(2);
        }

        private void checkAnswer(int num)
        {
            if (lqmodel.Answer == num)
            {
                MessageBox.Show("Helyes válasz! Gratulálok a jogosítványhoz!", "Gratulálok!", MessageBoxButtons.OK);
                lsmodel.examTaken(true);
            }
            else
            {
                MessageBox.Show("Helytelen válasz! Legközelebb jobban készülj fel!", "Sajnálom!", MessageBoxButtons.OK);
                lsmodel.examTaken(false);
            }
            this.Close();
        }
    }
}
