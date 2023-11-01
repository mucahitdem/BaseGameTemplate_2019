using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAmmoManagement.SkillSoulStealClip
{
    [Serializable]
    public class SoulStealClipData
    {
        // Her düşman yok edildiği zaman mermi doldurma hızında % 5 lik artış
        // gerçekleşir.Bu etki mermi doldurma işlemi tekrar yapıldıktan sonra
        // sıfırlanır.
        public float bulletReloadSpeedIncreasePercentageOnEnemyDied;
    }
}