using LifeSim.Model;
using LifeSim.Properties;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace LifeSim.View
{
    /// <summary>
    /// Minesweeper játékablak típusa.
    /// </summary>
    public partial class MinesweeperWindow : Form
    {
        #region Fields

        bool newGame; // elkezdtük-e már a játékot
        MinesweeperModel msmodel; // Minesweeper játékmodell
        LifeSimModel lsmodel; // LifeSim játékmodell

        #endregion

        #region Constructor

        /// <summary>
        /// Játékablak példányosítása.
        /// </summary>
        /// <param name="model">Játékmodell a példányosításhoz.</param>
        public MinesweeperWindow(LifeSimModel lsmodel)
        {
            InitializeComponent();
            this.lsmodel = lsmodel;
        }

        #endregion

        #region Model event handlers

        /// <summary>
        /// Játék elvesztésének eseménykezelője.
        /// </summary>
        private void Model_GameOverEvent(object sender, EventArgs e)
        {
            MessageBox.Show("A bevetés sikertelen volt."); // jelezzük a küldetés sikertelenségét
            lsmodel.endOfMission(false); // meghívjuk a LifeSimModel ehhez tartozó függvényét
            this.Close(); // bezárjuk a MineSweeper ablakot
        }

        /// <summary>
        /// Játék megnyerésének eseménykezelője.
        /// </summary>
        private void Model_GameWonEvent(object sender, EventArgs e)
        {
            MessageBox.Show("A bevetés sikeres volt."); // jelezzük a küldetés sikerességét
            lsmodel.endOfMission(true); // meghívjuk a LifeSimModel ehhez tartozó függvényét
            this.Close(); // bezárjuk a MineSweeper ablakot
        }

        #endregion

        #region Form event handlers

        /// <summary>
        /// Játékablak megjelenésének eseménykezelője.
        /// </summary>
        private void MinesweeperWindow_Shown(object sender, EventArgs e)
        {
            msmodel = new MinesweeperModel(); // MinesweeperModel létrehozása

            // eseménykezelők társítása
            msmodel.GameOverEvent += new EventHandler<EventArgs>(Model_GameOverEvent);
            msmodel.GameWonEvent += new EventHandler<EventArgs>(Model_GameWonEvent);

            // gombok létrehozása az aknamezők számára
            for (int i = 0; i <= 64; i++)
            {
                Button btn = new Button();
                btn.Name = "btn" + i.ToString();
                btn.Size = new Size(40, 40);
                btn.UseVisualStyleBackColor = true;
                btn.BackColor = Color.Gray;

                btn.MouseDown += btn_MouseDown;
                minefieldPanel.Controls.Add(btn);
            }

            newGame = true;
        }


        #endregion

        #region Button event handlers

        /// <summary>
        /// Gomb lenyomásának eseménykezelője.
        /// </summary>
        private void btn_MouseDown(object sender, MouseEventArgs e)
        {
            // gomb számának lekérdezése
            Button btn = (Button)sender;
            int number = Int32.Parse(btn.Name.Replace("btn", ""));

            if (e.Button == MouseButtons.Left) // ha a bal egérgombbal kattintunk a gombra
            {
                if (newGame) // ha még nem kezdtük el a játékot, akkor elkezdi felfedni a mezőt (itt még nem lehet elronatni)
                {
                    msmodel.newGame(number);
                    panelRefresh();
                    newGame = false;
                }
                else // különben ugyanúgy elkezdi felfedni a mezőt, de itt már el lehet rontani
                {
                    msmodel.recon(number);
                    if (!msmodel.gameOver)
                        panelRefresh();
                }
            }

            if (e.Button == MouseButtons.Right) // ha a jobb egérgombbal kattintunk a gombra
            {
                if (!newGame) // ha már elkezdtük a játékot, akkor meghívjuk a mező bejelölése eseményt a modellben
                {
                    msmodel.mark(number);
                    if (!msmodel.gameOver)
                        panelRefresh();
                }
            }
        }

        #endregion

        #region Private methods

        private void panelRefresh()
        {
            for (int i = 0; i < 64; i++) // végigmegyünk az összes gombon
            {
                if (msmodel.MineField[i / 8, i % 8].Revealed && !msmodel.MineField[i / 8, i % 8].Mine) // ha a gombhoz tartozó rész fel van fedve és nem tartalmaz aknát
                {
                    minefieldPanel.Controls[i].BackColor = Color.White; // fehér színűre állítjuk a gombot

                    if (msmodel.MineField[i / 8, i % 8].MinesInProximity != 0) // ha van akna a szomszédban, akkor kiírjuk a gombra, hogy mennyi
                        minefieldPanel.Controls[i].Text = msmodel.MineField[i / 8, i % 8].MinesInProximity.ToString();
                }
                else if (msmodel.MineField[i / 8, i % 8].Revealed && msmodel.MineField[i / 8, i % 8].Mine) // ha fel van fedve és van ott akna, akkor piros lesz a gomb
                {
                    minefieldPanel.Controls[i].BackColor = Color.Red;
                }
                else if (msmodel.MineField[i / 8, i % 8].Marked) // ha megjelölünk egy gombot, ahhoz hozzárendeljük a zászló ikont
                {
                    minefieldPanel.Controls[i].BackgroundImage = Resources.flagImage;
                    minefieldPanel.Controls[i].BackgroundImageLayout = ImageLayout.Center;
                }
                else if (!msmodel.MineField[i / 8, i % 8].Marked) // ha megjelölünk egy gombot, ahhoz hozzárendeljük a zászló ikont
                {
                    minefieldPanel.Controls[i].BackgroundImage = base.BackgroundImage;
                }
                else // különben szürke marad
                {
                    minefieldPanel.Controls[i].BackColor = Color.Gray;
                }
            }
        }

        #endregion
    }
}
