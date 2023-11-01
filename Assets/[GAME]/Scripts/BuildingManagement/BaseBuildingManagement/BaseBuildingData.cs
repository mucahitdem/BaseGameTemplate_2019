using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Scripts.BuildingManagement.BaseBuildingManagement
{
    [Serializable]
    public class BaseBuildingData
    {
        public string buildingName;
        
        [PreviewField(ObjectFieldAlignment.Left)]
        public Sprite buildingIcon;
        
        [TextArea(10, 20)]
        public string buildingDescription = "DESCRIPTION";
    }
}