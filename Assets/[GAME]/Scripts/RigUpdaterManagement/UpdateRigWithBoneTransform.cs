using Scripts.AnimatorManagement.Animators;
using Scripts.BaseGameScripts.Animator_Control;
using Scripts.GameScripts;
using Scripts.GameScripts.RigUpdaterManagement;
using UnityEngine;

namespace Scripts.RigUpdaterManagement
{
    public class UpdateRigWithBoneTransform : BaseRigUpdater
    {
        private AnimatorStateManager _animatorStateManager;
        private Vector3 _currentAngle;

        [SerializeField]
        private Transform boneToUpdate;

        [SerializeField]
        private Transform gfx;

        [SerializeField]
        private float legTurnRot;

        [SerializeField]
        private float maxTurnRot;

        [SerializeField]
        private Vector3 offsetRot;

        [SerializeField]
        private Transform targetDir;

        [SerializeField]
        private float turnSpeed;

        public override Vector3 RigLookDir => targetDir.forward;

        private AnimatorStateManager AnimatorStateManager
        {
            get
            {
                if (!_animatorStateManager)
                    _animatorStateManager = ((DefaultAnimator) CharacterManager.Animator).AnimatorStateManager;
                return _animatorStateManager;
            }
        }

        public override void UpdateRig(Transform targetObj)
        {
            if (!targetObj)
            {
                gfx.localEulerAngles = Vector3.zero;
                AnimatorStateManager.SetFloat(Defs.ANIM_KEY_WALK_SPEED, 1f);
                return;
            }

            LockOnTarget(targetObj);
        }


        private void LockOnTarget(Transform target)
        {
            var angle = AngleBetweenChestAndForward();
            if (angle > legTurnRot && angle <= maxTurnRot)
            {
                var targetPos = TransformOfObj.position + TransformOfObj.forward;
                LookAtTarget(targetPos, gfx);
                AnimatorStateManager.SetFloat(Defs.ANIM_KEY_WALK_SPEED, 1f);
            }
            else if (angle > maxTurnRot)
            {
                //DebugHelper.LogRed("ANGLE : " + angle);

                var targetPos = TransformOfObj.position - TransformOfObj.forward;
                LookAtTarget(targetPos, gfx);
                AnimatorStateManager.SetFloat(Defs.ANIM_KEY_WALK_SPEED, -1f);
            }
            else
            {
                gfx.localEulerAngles = Vector3.zero;
                AnimatorStateManager.SetFloat(Defs.ANIM_KEY_WALK_SPEED, 1f);
            }

            LookAtTarget(target, boneToUpdate, offsetRot);
        }

        private void LookAtTarget(Transform target, Transform objToTurn, Vector3 offset = default)
        {
            var dir = target.position - objToTurn.position;
            var lookRotation = Quaternion.LookRotation(dir);
            var rotation = Quaternion.Lerp(objToTurn.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            objToTurn.rotation = Quaternion.Euler(new Vector3(0f, rotation.y, 0f) + offset);
            _currentAngle = objToTurn.forward;
        }

        private void LookAtTarget(Vector3 targetPos, Transform objToTurn, Vector3 offset = default)
        {
            var dir = targetPos - objToTurn.position;
            var lookRotation = Quaternion.LookRotation(dir);
            var rotation = Quaternion.Lerp(objToTurn.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            objToTurn.rotation = Quaternion.Euler(new Vector3(0f, rotation.y, 0f) + offset);
        }

        private float AngleBetweenChestAndForward()
        {
            var angle = Vector3.Angle(TransformOfObj.forward.normalized, _currentAngle.normalized);
            return angle;
        }
    }
}