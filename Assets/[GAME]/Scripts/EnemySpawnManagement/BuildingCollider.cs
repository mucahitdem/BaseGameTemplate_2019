using Scripts.BaseGameScripts.ComponentManagement;
using UnityEngine;

namespace Scripts.GameScripts.EnemySpawnManagement
{
    public class BuildingCollider : BaseComponent
    {
        private BoxCollider _boxCol;

        public BoxCollider BoxCol
        {
            get
            {
                if (!_boxCol)
                    _boxCol = GetComponent<BoxCollider>();

                return _boxCol;
            }
        }
    }
}