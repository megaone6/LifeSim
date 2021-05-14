using LifeSim.LSModel;
using System;
using System.Windows.Forms;
using LifeSim.Persistence;

namespace LifeSim.LSView
{
    /// <summary>
    /// Játékkezdő ablak típusa.
    /// </summary>
    public partial class GameStart : Form
    {
        #region Fields

        private LifeSimModel model; // játékmodell
        private IPersistence dataAccess; // adatelérés
        private bool exit; // kilépés vagy folytatás

        #endregion

        #region Constructor

        /// <summary>
        /// Játékkezdő ablak példányosítása.
        /// </summary>
        public GameStart()
        {
            InitializeComponent();

            dataAccess = new TextFilePersistence(); //adatelérés példányosítása
            exit = true;
        }

        #endregion

        #region Control event handlers

        /// <summary>
        /// Random ember gomb eseménykezelője.
        /// </summary>
        private void randomButton_Click(object sender, EventArgs e)
        {
            exit = false;
            model = new LifeSimModel(dataAccess); // modellnek értékadás a perzisztenciával

            // játékablak létrehozása a modellel, játékablak láthatóvá tétele
            var window = new MainGameWindow(model);
            window.Show();

            this.Close(); //játékkezdő ablak bezárása
        }

        /// <summary>
        /// Testreszabás gomb eseménykezelője.
        /// </summary>
        private void inputButton_Click(object sender, EventArgs e)
        {
            // megfelelő Controlok láthatóvá, láthatatlanná tétele
            inputName.Visible = true;
            acceptNameButton.Visible = true;
            maleRadioButton.Visible = true;
            femaleRadioButton.Visible = true;
            inputButton.Visible = false;
            randomButton.Visible = false;
            this.Text = "Ember testreszabása";
        }

        /// <summary>
        /// Név megadása gomb eseménykezelője.
        /// </summary>
        private void acceptNameButton_Click(object sender, EventArgs e)
        {
            if (maleRadioButton.Checked) // ha a férfi RadioButtont választottuk, akkor férfi játékossal hozzuk létre a modellt
                model = new LifeSimModel(inputName.Text, true, dataAccess);

            else if (femaleRadioButton.Checked) // ha a női RadioButtont választottuk, nővel hozzuk létre
                model = new LifeSimModel(inputName.Text, false, dataAccess);

            else // ha nem választottunk semmit, ezt jelzi a program
            {
                MessageBox.Show("Válassz egy nemet!");
                return;
            }

            String[] foolproof = inputName.Text.Split(' '); // név beírása

            if (foolproof.Length != 2) // ha nem 2 szóból áll az input, ezt jelzi a program
            {
                MessageBox.Show("2 szó megadása szükségses: vezeték- és keresztnév!");
                return;
            }
             
            if(foolproof[0].Trim() == "" || foolproof[1].Trim() == "") // ha a vezeték- vagy keresztnév üres, ezt jelzi a program
            {
                MessageBox.Show("Nem adtál meg vezeték- vagy keresztnevet!");
                return;
            }

            exit = false;

            // játékablak létrehozása a modellel, játékablak láthatóvá tétele
            var window = new MainGameWindow(model);
            window.Show();

            this.Close();//játékkezdő ablak bezárása
        }

        #endregion

        private void GameStart_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (exit)
                Application.Exit();
        }
    }
}
