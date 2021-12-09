using DG.Tweening;
using Mechanics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Forward Movement")]
    [SerializeField] float speed;

    [Header("User Control")]
    [HideInInspector] public bool userActive;

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
        else if (other.CompareTag("EndGame"))
        {
            GameManager.instance.EndGame(2);
        }
    }
}
