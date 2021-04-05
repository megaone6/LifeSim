using System;
using System.Collections.Generic;

namespace LifeSim.Model
{
    /// <summary>
    /// Munkákat reprezentáló osztály.
    /// </summary>
    public class Job
    {
        /// <summary>
        /// Munka szintjeit tartalmazó szótár (kulcs: szint neve, érték: szinthez tartozó fizetés).
        /// </summary>
        public Dictionary<String,int> JobLevels { get; set; }

        /// <summary>
        /// Munkához szükséges egyetemi végzettség.
        /// </summary>
        public University DegreeNeeded { get; set; }

        /// <summary>
        /// Munka maximum szintje.
        /// </summary>
        public int MaxJobLevel { get; set; }

        /// <summary>
        /// Job osztály példányosítása.
        /// </summary>
        /// <param name="JobLevels">Munka szintjei.</param>
        /// <param name="DegreeNeeded">Szükséges végzettség.</param>
        /// <param name="MaxJobLevel">Maximum szint.</param>
        public Job(Dictionary<String,int> JobLevels, University DegreeNeeded, int MaxJobLevel)
        {
            this.JobLevels = JobLevels;
            this.DegreeNeeded = DegreeNeeded;
            this.MaxJobLevel = MaxJobLevel;
        }
    }
}
