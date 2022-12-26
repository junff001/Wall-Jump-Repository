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
                    if (!PlayerStatus.IsTouchedSideWall)
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
}
