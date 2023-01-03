using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceAnimation : MonoBehaviour
{
    [Header("[ Animation Variables ]")]
    [SerializeField] private float punchTarget;
    [SerializeField] private float duration;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            OnAnimation();
        }
    }

    private void OnAnimation()
    {
        Vector3 punch = new Vector3(punchTarget, 0, 0);
        transform.DOPunchScale(punch, duration);
    }
}
