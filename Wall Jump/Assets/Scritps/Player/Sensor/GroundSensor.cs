using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private PlayerStickToWall playerStickToWall;
    [SerializeField] private float moveHeight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerStatus.CurrentState = PlayerState.OnGround;
        }
        if (collision.gameObject.CompareTag("WallHead"))
        {
            if (PlayerStatus.CurrentState == PlayerState.BasicJump || PlayerStatus.CurrentState == PlayerState.AerialJump)
            {
                playerStickToWall.PostureCorrection(collision);
            }
        }
        else if (collision.gameObject.CompareTag("FlipWallHead"))
        {
            if (PlayerStatus.CurrentState == PlayerState.BasicJump || PlayerStatus.CurrentState == PlayerState.AerialJump)
            {
                playerStickToWall.PostureCorrection(collision);
            }

            if (!collision.transform.parent.GetComponent<FlipWall>().isFliping)
            {
                collision.transform.parent.GetComponent<FlipWall>().player = player;
            }
            else
            {
                StartCoroutine(Delay(collision));
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            GameManager.Instance.CameraFocusing();
        }
    }

    IEnumerator Delay(Collider2D collider)
    {
        yield return new WaitForSeconds(collider.transform.parent.GetComponent<FlipWall>().flipTime);
        collider.transform.parent.GetComponent<FlipWall>().player = player;
    }
}
