using UnityEngine;

namespace Scripts.GameScripts.BulletManagement.BaseBulletMovementManagement.AllBulletMovement
{
    public class BulletMoveForward : BaseBulletMovement
    {
        public override void MoveToDir(Vector3 moveToDir)
        {
            if (!CanMove)
                return;
            var position = TransformOfObj.position;
            position += moveToDir * (Time.deltaTime * currentSpeed);
            TransformOfObj.position = position;
            //TransformOfObj.LookAt(position + moveToDir);
        }

        public override void UpdateRotation(Vector3 pointToLook)
        {
            TransformOfObj.LookAt(TransformOfObj.position + pointToLook);
        }
    }
}