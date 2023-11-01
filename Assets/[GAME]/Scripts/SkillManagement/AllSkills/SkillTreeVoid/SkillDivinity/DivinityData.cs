using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeVoid.SkillDivinity
{
    [Serializable]
    public class DivinityData
    {
        // ● Hiçlik patlaması ile öldürülen her 150 düşmanda bir adet can kazanılır.
        // ● Bu işlem en fazla 3 kere tekrarlanabilir.3 kere tekrarlandıktan sonra bir daha tekrarlanmaz.
        public int gainHealthAfterKilledEnemyAmount = 150;
        public int maxRepeatAmount = 3;
    }
}