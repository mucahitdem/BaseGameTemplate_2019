using DG.Tweening;
using Scripts.BaseGameScripts.Pool;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class CoinController : MonoBehaviour
    {
        
        [SerializeField] TextMeshProUGUI diamondNumText;

        [Header("Diamond Variables")]
        [SerializeField] Image diamondImage;
        [SerializeField] GameObject diamond;
        [HideInInspector] public int diamondNum;
        Vector2 _anchoredDiamondPos;
    
        [Header("References")]
        [SerializeField] Camera cam;

        private void Start()
        {
            DiamondFirstSet();
        }

        private void DiamondFirstSet()
        {
            diamondNum = PlayerPrefs.GetInt("Diamond", 0);
            diamondNumText.text = diamondNum.ToString();
            _anchoredDiamondPos = diamondImage.GetComponent<RectTransform>().anchoredPosition;
        }

        public void DiamondCollectAnim(Vector3 diamondPos)
        {
            Vector2 screenPos = cam.WorldToScreenPoint(diamondPos);
            GameObject clone = gameObject; //GlobalReferences.Instance.poolManager.poolObject.objToPool.PullObjFromPool();

            clone.transform.localScale = Vector3.one * .5f; 

            RectTransform rectClone = clone.GetComponent<RectTransform>();
            rectClone.anchoredPosition = screenPos;
 
            clone.transform.parent = transform;

            rectClone.DOAnchorPos(_anchoredDiamondPos, .5f)
                .OnComplete(() => 
                { 
                    clone.SetActive(false);
                    UpdateDiamondText();
                });
        }
        void UpdateDiamondText()
        {
            diamondNum++;
            PlayerPrefs.SetInt("Diamond", diamondNum);
            diamondNumText.text = PlayerPrefs.GetInt("Diamond").ToString();
        }
    }
}