using Scripts.BaseGameScripts.ComponentManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME_.Scripts.GameScripts.DefendAreaManagement
{
    public class DefendAreaCapturePositionManager : BaseComponent
    {
        private int _index;

        [SerializeField]
        private Transform createParent;

        [SerializeField]
        //[ReadOnly]
        private PosAndIsFullFlag[] posAndIsFullFlag;

        [Button]
        private void CreatePosInCirc(int count, int radius)
        {
            var angleStep = 360f / count;
            posAndIsFullFlag = new PosAndIsFullFlag[count];
            for (var i = 0; i < count; i++)
            {
                var angle = i * angleStep;
                var x = radius * Mathf.Cos(Mathf.Deg2Rad * angle);
                var z = radius * Mathf.Sin(Mathf.Deg2Rad * angle);

                var pos = transform.position + new Vector3(x, 0, z);

                var createdPos = new GameObject("Pos");
                createdPos.transform.SetParent(createParent);
                createdPos.transform.position = pos;
                createdPos.transform.LookAt(createParent.position);
                posAndIsFullFlag[i].targetPos = createdPos.transform;
            }
        }

        public Transform CurrentPos()
        {
            var pos = posAndIsFullFlag[_index].targetPos;
            _index++;
            if (_index >= posAndIsFullFlag.Length)
                _index = 0;
            return pos;
        }
    }
}