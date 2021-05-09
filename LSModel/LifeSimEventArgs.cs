using System;

namespace LifeSim.LSModel
{
    /// <summary>
    /// LifeSim eseményargumentum típusa.
    /// </summary>
    public class LifeSimEventArgs
    {
        /// <summary>
        /// Személy lekérdezése.
        /// </summary>
        public Person Person { get; }

        /// <summary>
        /// Halál lekérdezése.
        /// </summary>
        public bool Death { get; }

        /// <summary>
        /// Egyetem költségeinek lekérdezése.
        /// </summary>
        public int UniversityCost { get; }

        /// <summary>
        /// Visszafizetési idő lekérdezése.
        /// </summary>
        public int YearsToPayBack { get; }

        /// <summary>
        /// Személy sorszámának (People lista, lásd Model) lekérdezése.
        /// </summary>
        public int PersonIndex { get; }

        /// <summary>
        /// Betegség lekérdezése.
        /// </summary>
        public Sickness Sickness { get; }

        /// <summary>
        /// Elkapott betegségek lekérdezése.
        /// </summary>
        public String Sicknesses { get; }

        /// <summary>
        /// Meggyógyított betegségek lekérdezése.
        /// </summary>
        public String SicknessesHealed { get; }

        /// <summary>
        /// Az elért teljesítmény neve.
        /// </summary>
        public String AchievementName { get; }

        /// <summary>
        /// LifeSim eseményargumentum példányosításai.
        /// </summary>

        /// <param name="Person">Személy.</param>
        public LifeSimEventArgs(Person Person)
        {
            this.Person = Person;
        }

        /// <param name="Person">Személy.</param>
        /// <param name="PersonIndex">Személy indexe.</param>
        public LifeSimEventArgs(Person Person, int PersonIndex)
        {
            this.Person = Person;
            this.PersonIndex = PersonIndex;
        }

        /// <param name="Death">Halott-e.</param>
        public LifeSimEventArgs(bool Death)
        {
            this.Death = Death;
        }

        /// <param name="UniversityCost">Egyetem költsége.</param>
        public LifeSimEventArgs(int UniversityCost)
        {
            this.UniversityCost = UniversityCost;
        }

        /// <param name="UniversityCost">Egyetem költsége.</param>
        /// <param name="YearsToPayBack">Visszafizetési idő.</param>
        public LifeSimEventArgs(int UniversityCost, int YearsToPayBack)
        {
            this.UniversityCost = UniversityCost;
            this.YearsToPayBack = YearsToPayBack;
        }

        /// <param name="Sickness">Betegség.</param>
        public LifeSimEventArgs(Sickness Sickness)
        {
            this.Sickness = Sickness;
        }

        /// <param name="Sicknesses">Elkapott betegségek.</param>
        /// <param name="SicknessesHealed">Gyógyított betegségek.</param>
        public LifeSimEventArgs(String Sicknesses, String SicknessesHealed)
        {
            this.Sicknesses = Sicknesses;
            this.SicknessesHealed = SicknessesHealed;
        }

        /// <param name="AchievementName">Elért achievement.</param>
        public LifeSimEventArgs(String AchievementName)
        {
            this.AchievementName = AchievementName;
        }
    }
}
