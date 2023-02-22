using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlipEffect : MonoBehaviour
{
    [Header("[ Slipping Variables ]")]
    [SerializeField] private float slipSpeed;
    [SerializeField] private float slippingWaitTime;

    Coroutine slipCoroutine;
    private readonly int isJumping = Animator.StringToHash("isJumping");
    private readonly int isStickToWall = Animator.StringToHash("isStickToWall");

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (!Player.Instance.isCurrentlySlippingTheWall)
            {
                StartCoroutine(Slipping());
            }
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {      
            if (Player.Instance.currnetState == EPlayerState.SITCK_TO_WALL || Player.Instance.currnetState == EPlayerState.POSTURE_CORRECTION)
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
        Player.Instance.isCurrentlySlippingTheWall = true;
        Player.Instance.physic.GravityScaleZero();
        Player.Instance.physic.VelocityZero();
        yield return new WaitUntil(() => !Player.Instance.isPostureCorrecting);
        yield return new WaitForSeconds(slippingWaitTime);
        

        while ((Player.Instance.currnetState == EPlayerState.SITCK_TO_WALL || 
            Player.Instance.currnetState == EPlayerState.POSTURE_CORRECTION) && 
            Player.Instance.currentStickToWall == this.transform)
        {
            Player.Instance.transform.Translate(Vector2.down * Time.deltaTime * slipSpeed);
            yield return null;
        }

        Player.Instance.isCurrentlySlippingTheWall = false;
    }
}
