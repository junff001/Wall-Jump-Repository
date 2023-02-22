using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWall : MonoBehaviour
{
    [Header("[ Bounces Variables ]")]
    [SerializeField] private float bouncesOffDegree;
    [SerializeField] private float bouncesTime;
    [SerializeField] private float jumpDelay;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.directionOfView.ReverseView();
            Player.Instance.physic.VelocityZero();

            if (Player.Instance.currnetState == EPlayerState.BASIC_JUMP)
            {
                StartCoroutine(PlayerBouncesOff());
            }
            else if (Player.Instance.currnetState == EPlayerState.AERIAL_JUMP)
            {
                Player.Instance.currnetState = EPlayerState.BASIC_JUMP;
                StartCoroutine(PlayerBouncesOff());
            }
        }
    }

    private IEnumerator PlayerBouncesOff()
    {
        Player.Instance.canJumping = false;
        Player.Instance.isCurrentlyBouncedOffTheWall = true;
        float originTime = bouncesTime;

        while (originTime > 0)
        {
            originTime -= Time.deltaTime;

            if (originTime <= jumpDelay)
            {
                Player.Instance.canJumping = true;
            }

            if (Player.Instance.currentDirection == EPlayerDirection.RIGHT)
            {
                Vector2 direction = new Vector2(1, 1.75f);
                Player.Instance.physic.SetVelocity(direction * bouncesOffDegree);
            }
            else if (Player.Instance.currentDirection == EPlayerDirection.LEFT)
            {
                Vector2 direction = new Vector2(-1, 1.75f);
                Player.Instance.physic.SetVelocity(direction * bouncesOffDegree);
            }

            yield return null;
        }

        Player.Instance.isCurrentlyBouncedOffTheWall = false;
    }
}
