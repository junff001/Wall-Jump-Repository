using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipEffect : MonoBehaviour
{
    [Header("[ Slipping Variables ]")]
    [SerializeField] private float slipSpeed;
    [SerializeField] private float slippingWaitTime;

    private readonly int isJumping = Animator.StringToHash("isJumping");
    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("미끄러지기 시작");
            Player.Instance.physic.GravityScaleZero();
            StartCoroutine(Slipping());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Player.Instance.currnetState == PlayerState.StickToWall || Player.Instance.currnetState == PlayerState.PostureCorrection)
            {
                if (!Player.Instance.isPostureCorrecting)
                {
                    StopCoroutine(Slipping());
                    Player.Instance.physic.SetGravityScale(1f);
                }
            }
        }
    }

    private IEnumerator Slipping()
    {
        Player.Instance.physic.GravityScaleZero();
        Player.Instance.physic.VelocityZero();
        yield return new WaitUntil(() => !Player.Instance.isPostureCorrecting);
        yield return new WaitForSeconds(slippingWaitTime);
        Player.Instance.isCurrentlySlippingTheWall = true;

        while ((Player.Instance.currnetState == PlayerState.StickToWall || 
            Player.Instance.currnetState == PlayerState.PostureCorrection) && 
            Player.Instance.currentStickToWall == this.transform)
        {
            Player.Instance.transform.Translate(Vector2.down * Time.deltaTime * slipSpeed);
            yield return null;
        }

        Player.Instance.isCurrentlySlippingTheWall = false;
    }
}
