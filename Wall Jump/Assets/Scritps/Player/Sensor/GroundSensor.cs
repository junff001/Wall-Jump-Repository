using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private PlayerStickToWall playerStickToWall;
    [SerializeField] private BoxCollider2D wallCol;
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
            transform.GetComponent<BoxCollider2D>().enabled = false;
            wallCol.enabled = false;

            if (PlayerStatus.CurrentState == PlayerState.BasicJump || PlayerStatus.CurrentState == PlayerState.AerialJump)
            {
                playerStickToWall.PostureCorrection(collision);
            }

            if (!collision.transform.parent.GetComponent<FlipWall>().isFliping)
            {
                Debug.Log("플레이어는 플레이어");
                collision.transform.parent.GetComponent<FlipWall>().player = player;
            }
            else
            {
                Debug.Log("코루틴");
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
