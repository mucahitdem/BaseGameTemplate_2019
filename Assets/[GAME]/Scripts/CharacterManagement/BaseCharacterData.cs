using System;
using _GAME_.Scripts.GameScripts._NewData;
using Scripts._NewData;
using UnityEngine;

namespace Scripts.GameScripts.CharacterManagement
{
    [Serializable]
    public class BaseCharacterData
    {
        public BaseCharacterManager baseCharacter;
        public CharacterData characterData;
        public Sprite charIcon;
        public string name;
    }
}