using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeRadioactive.SkillFireEnchantment
{
    [Serializable]
    public class FireEnchantmentData
    {
        public float attackDamagePercentage = 15f;

        public float firingBulletProbability = 50f;
        // ● Mermiler %50 ihtimal ile her saniye düşmanların radyasyon ile yanmasına sebep olur.
        // ● Yanma hasarı saldırı gücünün %15 i kadardır.(Tekrar edilebilir bir etkidir)

        public float timeRate = 1f;
    }
}