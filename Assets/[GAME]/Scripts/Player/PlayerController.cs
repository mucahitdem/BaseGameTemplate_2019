using DG.Tweening;
using Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Swipe Components")]
    [SerializeField] float lerpMult;
    [SerializeField] float clampMax;
    [SerializeField] float dampVal;
    [SerializeField] bool posSwipe;

    [Header("Forward Movement")]
    [SerializeField] float speed;

    [Header("User Control")]
    [HideInInspector] public bool userActive;

    void Start()
    {
        SwipeMecLast.instance.VariableAdjust(transform , lerpMult , clampMax , dampVal , posSwipe);
    }

    void Update()
    {
        if (!userActive) return;

        transform.position += transform.forward * Time.deltaTime * speed;
        SwipeMecLast.instance.Swipe();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Diamond"))
        {
            UIManager.instance.DiamondCollectAnim(other.transform.position);
        }
    }
}
