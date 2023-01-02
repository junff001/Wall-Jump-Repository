using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThornColliderActiveEffect : MonoBehaviour
{
    [Header("[ Component Variables ]")]
    [SerializeField] private BoxCollider2D thornCollider;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(ThornColliderActive());
        }
    }

    private IEnumerator ThornColliderActive()
    {
        thornCollider.enabled = false;
        yield return new WaitUntil(() => !Player.Instance.isPostureCorrecting);
        thornCollider.enabled = true;
    }
}
