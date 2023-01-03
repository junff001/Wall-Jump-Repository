using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyWall : MonoBehaviour
{
    [Header("[ Bounces Variables ]")]
    [SerializeField] private float bouncesOffDegree;
    [SerializeField] private float bouncesTime;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Player.Instance.directionOfView.ReverseView();
            Player.Instance.physic.VelocityZero();

            if (Player.Instance.currnetState == PlayerState.BasicJump)
            {
                StartCoroutine(PlayerBouncesOff());
            }
            else if (Player.Instance.currnetState == PlayerState.AerialJump)
            {
                Player.Instance.currnetState = PlayerState.BasicJump;
                StartCoroutine(PlayerBouncesOff());
            }  
        }
    }

    private IEnumerator PlayerBouncesOff()
    {
        Player.Instance.isCurrentlyBouncedOffTheWall = true;
        float originTime = bouncesTime;

        while (originTime > 0)
        {
            originTime -= Time.deltaTime;

            if (Player.Instance.currentDirection == PlayerDirection.Right)
            {
                Vector2 direction = new Vector2(1, 1.75f);
                Player.Instance.physic.SetVelocity(direction * bouncesOffDegree);
            }
            else if (Player.Instance.currentDirection == PlayerDirection.Left)
            {
                Vector2 direction = new Vector2(-1, 1.75f);
                Player.Instance.physic.SetVelocity(direction * bouncesOffDegree);
            }

            yield return null;
        }

        Player.Instance.isCurrentlyBouncedOffTheWall = false;
    }
}
