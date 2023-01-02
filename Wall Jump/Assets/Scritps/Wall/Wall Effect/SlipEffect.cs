using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipEffect : MonoBehaviour
{
    [Header("[ Slipping Variables ]")]
    [SerializeField] private float slipSpeed;
    [SerializeField] private float slippingWaitTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Slipping());
        }
    }

    private IEnumerator Slipping()
    {
        yield return new WaitUntil(() => !Player.Instance.isPostureCorrecting);
        yield return new WaitForSeconds(slippingWaitTime);

        while ((Player.Instance.currnetState == PlayerState.StickToWall || 
            Player.Instance.currnetState == PlayerState.PostureCorrection) && 
            Player.Instance.currentStickToWall == this.transform)
        {
            Player.Instance.transform.Translate(Vector2.down * Time.deltaTime * slipSpeed);
            yield return null;
        }
    }
}
