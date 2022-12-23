using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private PlayerPostureCorrection postureCorrection;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
            {
                PlayerStatus.CurrentState = PlayerState.OnGround;
                break;
            }
            case "WallHead":
            {
                if (PlayerStatus.CurrentState == PlayerState.BasicJump || PlayerStatus.CurrentState == PlayerState.AerialJump || PlayerStatus.CurrentState == PlayerState.BashJump)
                {
                    PlayerStatus.CurrentState = PlayerState.PostureCorrection;
                    player.SetParent(collision.transform.parent);

                    if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
                    {
                        Transform rightPoint = collision.transform.GetChild(1);
                        StartCoroutine(postureCorrection.MoveToSideOfWall(rightPoint));
                    }
                    else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
                    {
                        Transform leftPoint = collision.transform.GetChild(0);
                        StartCoroutine(postureCorrection.MoveToSideOfWall(leftPoint));
                    }
                }    
                break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "WallHead":
            {
                player.SetParent(null);
                break;
            }
        }
    }

    //[SerializeField] private Transform player;
    //[SerializeField] private PlayerStickToWall playerStickToWall;
    //[SerializeField] private CircleCollider2D deadBoundCol;
    //[SerializeField] private BoxCollider2D wallCol;
    //[SerializeField] private float moveHeight;

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        PlayerStatus.CurrentState = PlayerState.OnGround;
    //    }
    //    if (collision.gameObject.CompareTag("WallHead"))
    //    {
    //        if (PlayerStatus.CurrentState == PlayerState.BasicJump || PlayerStatus.CurrentState == PlayerState.AerialJump || PlayerStatus.CurrentState == PlayerState.BashJump)
    //        {
    //            playerStickToWall.PostureCorrection(collision);
    //        }
    //    }
    //    else if (collision.gameObject.CompareTag("FlipWallHead"))
    //    {
    //        transform.GetComponent<BoxCollider2D>().enabled = false;
    //        wallCol.enabled = false;
    //        deadBoundCol.enabled = false;

    //        if (PlayerStatus.CurrentState == PlayerState.BasicJump || PlayerStatus.CurrentState == PlayerState.AerialJump || PlayerStatus.CurrentState == PlayerState.BashJump)
    //        {
    //            playerStickToWall.PostureCorrection(collision);
    //        }

    //        if (!collision.transform.parent.GetComponent<FlipWall>().isFliping)
    //        {
    //            Debug.Log("플레이어는 플레이어");
    //            collision.transform.parent.GetComponent<FlipWall>().player = player;
    //        }
    //        else
    //        {
    //            Debug.Log("코루틴");
    //            StartCoroutine(FlipWallDelay(collision));
    //        }
    //    }
    //    else if (collision.gameObject.CompareTag("SpikeHead"))
    //    {
    //        transform.GetComponent<BoxCollider2D>().enabled = false;
    //        wallCol.enabled = false;

    //        if (PlayerStatus.CurrentState == PlayerState.BasicJump || PlayerStatus.CurrentState == PlayerState.AerialJump || PlayerStatus.CurrentState == PlayerState.BashJump)
    //        {
    //            playerStickToWall.PostureCorrection(collision);
    //        }

    //        if (!collision.transform.parent.GetComponent<FlilpSpikeWall>().isFliping)
    //        {
    //            Debug.Log("플레이어는 플레이어");
    //            collision.transform.parent.GetComponent<FlilpSpikeWall>().player = player;
    //        }
    //        else
    //        {
    //            Debug.Log("코루틴");
    //            StartCoroutine(FlipSpikeWallDelay(collision));
    //        }
    //    }
    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.CompareTag("Ground"))
    //    {
    //        GameManager.Instance.CameraFocusing();
    //    }
    //}

    //IEnumerator FlipWallDelay(Collider2D collider)
    //{
    //    yield return new WaitForSeconds(collider.transform.parent.GetComponent<FlipWall>().flipTime);
    //    collider.transform.parent.GetComponent<FlipWall>().player = player;
    //}

    //IEnumerator FlipSpikeWallDelay(Collider2D collider)
    //{
    //    yield return new WaitForSeconds(collider.transform.parent.GetComponent<FlilpSpikeWall>().flipTime);
    //    collider.transform.parent.GetComponent<FlilpSpikeWall>().player = player;
    //}
}
