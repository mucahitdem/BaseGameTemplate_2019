using Scripts.BaseGameScripts.ComponentManagement;
using Scripts.CharacterManagement;
using UnityEngine;

namespace Scripts.GameScripts.RigUpdaterManagement
{
    public abstract class BaseRigUpdater : BaseComponent
    {
        protected BaseCharacterManager CharacterManager;
        public virtual bool IsLookingTarget => false;
        public virtual Vector3 RigLookDir => default;

        public override void Insert(BaseComponent baseComponent)
        {
            base.Insert(baseComponent);
            CharacterManager = (BaseCharacterManager) baseComponent;
        }

        public abstract void UpdateRig(Transform targetObj);
    }
}