using Scripts.GameScripts.CharacterManagement;
using UnityEngine;

namespace Scripts.GameScripts.PlayerManagement
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Game/Player/Player Data", order = 0)]
    public class PlayerManagerDataSo : BaseCharacterDataSo
    {
        public PlayerManagerData playerManagerData;
    }
}