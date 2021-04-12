using LifeSim.Model;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace LifeSim.View
{
    /// <summary>
    /// Achievement ablak típusa.
    /// </summary>
    public partial class AchievementsWindow : Form
    {
        #region Fields

        LifeSimModel lsmodel; // LifeSim játékmodell
        private Dictionary<string, string> achievements;
        private List<int> completedAchievements;

        #endregion

        #region Constructor

        /// <summary>
        /// Achievement ablak példányosítása.
        /// </summary>
        /// <param name="lsmodel">LifeSimModel a példányosításhoz.</param>
        public AchievementsWindow(LifeSimModel lsmodel)
        {
            InitializeComponent();
            this.lsmodel = lsmodel;
        }

        #endregion

        #region Form event handlers

        /// <summary>
        /// Achievement ablak megjelenésének eseménykezelője.
        /// </summary>
        private void AchievementsWindow_Shown(object sender, System.EventArgs e)
        {
            achievements = lsmodel.Achievements;
            completedAchievements = lsmodel.CompletedAchievements;

            for (int i = 0; i < achievements.Count; i++) // végigmegyünk az achievementek listáján, és mindegyiknek létrehozunk egy Labelt
            {
                Label label = new Label();
                label.Name = "achLabel" + i.ToString();
                label.Text = achievements.Keys.ElementAt(i) + ": " + achievements.Values.ElementAt(i);
                label.Size = new Size(500, 20);

                if (completedAchievements.Contains(i)) // ha már megvan az achievement, akkor a hozzá tartozó szöveget zöldre színezzük
                    label.ForeColor = Color.Green;

                else // különben vörösre
                    label.ForeColor = Color.Red;

                achievementsPanel.Controls.Add(label);
            }
        }

        #endregion
    }
}
