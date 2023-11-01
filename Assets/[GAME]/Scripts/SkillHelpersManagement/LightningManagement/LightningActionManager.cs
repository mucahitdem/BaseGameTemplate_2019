using System;
using UnityEngine;

namespace Scripts.GameScripts.SkillHelpersManagement.LightningManagement
{
    public static class LightningActionManager
    {
        public static Action<Vector3, int> onLightningRicocheted;
        public static Action<Vector3> onLightningFlashed; // exploded
    }
}