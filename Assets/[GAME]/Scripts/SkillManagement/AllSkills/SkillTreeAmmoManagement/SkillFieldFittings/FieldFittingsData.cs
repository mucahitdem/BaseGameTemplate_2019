using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeAmmoManagement.SkillFieldFittings
{
    [Serializable]
    public class FieldFittingsData
    {
        public int ammoCountIncreaseAmount;

        // ● + %10 Mermi Doldurma Hızı (Reload Speed)
        // ● Şarjör Kapasitesinde + 2 mermi artış (Ammo Capacity)
        public float reloadSpeedIncreasePercentage;
    }
}