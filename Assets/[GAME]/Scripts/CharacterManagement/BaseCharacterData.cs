using System;
using Scripts.GameScripts.CharacterManagement;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.CharacterManagement
{
    [Serializable]
    public class BaseCharacterData
    {
        public string name;
        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite charIcon;
        
        public BaseCharacterManager baseCharacter;
    }
}