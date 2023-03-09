using Scripts.BaseGameScripts.Helper;
using UnityEngine;

namespace Scripts.GameScripts
{
    public class GameManager : SingletonMono<GameManager>
    {
        public Camera MainCam => cam;


        [SerializeField]
        private Camera cam;


        protected override void OnAwake()
        {
            
        }
    }
}