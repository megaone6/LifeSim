using System;

namespace LifeSim.LSModel
{
    /// <summary>
    /// Betegséget reprezentáló osztály.
    /// </summary>
    public class Sickness
    {
        /// <summary>
        /// Betegség neve.
        /// </summary>
        public String Name { get; set; }

        /// <summary>
        /// Betegség körülbelüli hatása az egészségre.
        /// </summary>
        public int ApproximateEffectOnHealth { get; set; }

        /// <summary>
        /// Kell-e a gyógyításához orvos.
        /// </summary>
        public bool NeedsMedicalAttention { get; set; }

        /// <summary>
        /// Mekkora eséllyel gyógyítható.
        /// </summary>
        public int ChanceToHeal { get; set; }

        /// <summary>
        /// Sickness osztály példányosítása. (nem kell orvosi beavatkozás)
        /// </summary>
        /// <param name="Name">Név.</param>
        /// <param name="ApproximateEffectOnHealth">Egészségre való hatás.</param>
        public Sickness(String Name, int ApproximateEffectOnHealth)
        {
            this.Name = Name;
            this.ApproximateEffectOnHealth = ApproximateEffectOnHealth;
            NeedsMedicalAttention = false;
        }

        /// <summary>
        /// Sickness osztály példányosítása. (kell orvosi beavatkozás)
        /// </summary>
        /// <param name="Name">Név.</param>
        /// <param name="ApproximateEffectOnHealth">Egészségre való hatás.</param>
        /// <param name="ChanceToHeal">Gyógyítás esélye.</param>
        public Sickness(String Name, int ApproximateEffectOnHealth, int ChanceToHeal)
        {
            this.Name = Name;
            this.ApproximateEffectOnHealth = ApproximateEffectOnHealth;
            NeedsMedicalAttention = true;
            this.ChanceToHeal = ChanceToHeal;
        }
    }
}
