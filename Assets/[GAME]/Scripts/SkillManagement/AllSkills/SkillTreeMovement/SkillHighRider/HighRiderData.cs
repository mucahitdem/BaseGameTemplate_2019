using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeMovement.SkillHighRider
{
    [Serializable]
    public class HighRiderData
    {
        public float bulletSpeedIncreasePercentage;
        // ● + %10 Mermi hasar ve hareket hızında artış
        // ● Hareket hızı her 10 saniyede bir %10 artar.Bu etki maksimum 4 kere stack edilebilir.Düşman tarafından hasar hasar almak bu etkiyi sıfırlar.

        public float movementSpeedIncreasePercentage;
    }
}