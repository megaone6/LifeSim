using LifeSim.LSModel;
using System.Windows.Forms;

namespace LifeSim.LSView
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

        #region Event handlers

        /// <summary>
        /// Jogosítvány ablak megjelenésének eseménykezelője.
        /// </summary>
        private void LicenseQuestionsWindow_Shown(object sender, System.EventArgs e)
        {
            lqmodel = new LicenseQuestionsModel();
            questionLabel.Text = lqmodel.Question;
        }

        /// <summary>
        /// 'a' gomb lenyomásának eseménykezelője.
        /// </summary>
        private void aButton_Click(object sender, System.EventArgs e)
        {
            checkAnswer(0);
        }

        /// <summary>
        /// 'b' gomb lenyomásának eseménykezelője.
        /// </summary>
        private void bButton_Click(object sender, System.EventArgs e)
        {
            checkAnswer(1);
        }

        /// <summary>
        /// 'c' gomb lenyomásának eseménykezelője.
        /// </summary>
        private void cButton_Click(object sender, System.EventArgs e)
        {
            checkAnswer(2);
        }

        #endregion

        #region Private methods

        /// <summary>
        /// Válasz leellenőrzésére szolgáló függvény.
        /// </summary>
        /// <param name="num">A válasz sorszáma.</param>
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

        #endregion
    }
}
