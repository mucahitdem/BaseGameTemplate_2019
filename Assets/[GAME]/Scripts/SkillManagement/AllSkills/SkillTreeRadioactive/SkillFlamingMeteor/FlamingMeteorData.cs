using System;

namespace Scripts.GameScripts.SkillManagement.AllSkills.SkillTreeRadioactive.SkillFlamingMeteor
{
    [Serializable]
    public class FlamingMeteorData
    {
        // ● Her 5 atışta bir radyoaktif meteor oluşturulur ve 5. merminin isabet ettiği düşmanın olduğu bölgeye düşer.
        // ● Meteor hasarı saldırı gücü hasarının %60 lık kısmı kadar hasar vererek büyük bir yanıcı alan oluşturur.Bu alana giren
        // düşmanlar yanmaya başlarlar.Alan belli bir süre sonra kaybolur.

        public int bulletAmountToTriggerRadioactiveMeteor;
        public float meteorAttackDamagePercentage;
    }
}