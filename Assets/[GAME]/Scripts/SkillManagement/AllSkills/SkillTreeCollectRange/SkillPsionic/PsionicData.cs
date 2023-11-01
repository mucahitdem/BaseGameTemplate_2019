using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeCollectRange.SkillPsionic
{
    [Serializable]
    public class PsionicData
    {
        // ● + %20 collectible toplama alanında genişleme gerçekleşir.
        // ● %10 ihtimal ile her deneyim puanı toplanması durumunda 1 adet mermi doldurma ihtimali kazanılır.
        public float collectRangeIncreasePercentage;
        public int onXpCollectedFillAmmoCount;
        public float onXpCollectedFillAmmoProbability;
    }
}