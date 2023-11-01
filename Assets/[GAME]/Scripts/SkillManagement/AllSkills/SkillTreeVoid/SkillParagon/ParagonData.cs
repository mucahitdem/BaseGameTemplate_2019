using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeVoid.SkillParagon
{
    [Serializable]
    public class ParagonData
    {
        // ● Şarjör tükendiği zaman görüş alanı içerisindeki düşmanlar üzerinde 
        // hiçlik patlaması oluşur ve hasar verir. --> böyle bir skill var 
        // ● Hiçlik hasarı saldırı hasarının %25 lik kısmına eşittir.

        public float attackDamagePercentage;
    }
}