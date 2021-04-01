using System;

namespace LifeSim.Model
{
    public class Sickness
    {
        public String Name { get; set; }

        public int ApproximateEffectOnHealth { get; set; }

        public bool NeedsMedicalAttention { get; set; }

        public int ChanceToHeal { get; set; }

        public Sickness(String Name, int ApproximateEffectOnHealth)
        {
            this.Name = Name;
            this.ApproximateEffectOnHealth = ApproximateEffectOnHealth;
            NeedsMedicalAttention = false;
        }

        public Sickness(String Name, int ApproximateEffectOnHealth, int ChanceToHeal)
        {
            this.Name = Name;
            this.ApproximateEffectOnHealth = ApproximateEffectOnHealth;
            NeedsMedicalAttention = true;
            this.ChanceToHeal = ChanceToHeal;
        }
    }
}
