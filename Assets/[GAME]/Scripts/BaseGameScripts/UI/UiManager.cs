using System.Collections.Generic;
using UnityEngine;

namespace Scripts.UI
{
    public class UiManager : MonoBehaviour
    {
        [SerializeField]
        private List<UiItem> screens = new List<UiItem>();

        [SerializeField]
        private List<UiItem> uiItems = new List<UiItem>();

        public void ShowScreen(string uiItemId)
        {
            ShowOneHideRest(screens, uiItemId);
        }
        
        public void ShowOneHideRest(List<UiItem> itemGroup, string uiItemId)
        {
            for (int i = 0; i < itemGroup.Count; i++)
            {
                UiItem currentUi = itemGroup[i];

                currentUi.Go.SetActive(uiItemId == currentUi.id);
            }
        }

        public void ShowUi(string uiId)
        {
            for (int i = 0; i < uiItems.Count; i++)
            {
                UiItem currentUi = screens[i];

                if (uiId == currentUi.id)
                    currentUi.Go.SetActive(true);
            }
        }

        public void ShowMultipleUis(params string[] ids) // not recommend to use because it is too slow
        {
            for (int i = 0; i < uiItems.Count; i++)
            {
                UiItem currentUi = screens[i];

                for (int j = 0; j < ids.Length; j++)
                {
                    string itemId = ids[j];

                    if (itemId == currentUi.id)
                    {
                        currentUi.Go.SetActive(true);
                    }
                }
            }
        }
    }
}