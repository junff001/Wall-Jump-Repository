using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sensor : MonoBehaviour
{
    [Header("[ Components ]")]
    [SerializeField] private Transform player;
    [SerializeField] private PlayerPostureCorrection postureCorrection;

    [Header("[ Correction Values  ]")]
    [SerializeField] private float correctionHeight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ground":
            {
                PlayerStatus.CurrentState = PlayerState.OnGround;
                break;
            }     
            case "Wall":
            {
                PlayerStatus.CurrentState = PlayerState.StickToWall;
                player.SetParent(collision.transform);
                break;
            }
            case "WallHead":
            {
                if (collision.transform.position.y < player.position.y + correctionHeight)
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
                }
                else if (collision.transform.position.y >= player.position.y + correctionHeight)
                {
                    PlayerStatus.CurrentState = PlayerState.StickToWall;
                    player.SetParent(collision.transform);
                }
                break;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall") || 
            collision.gameObject.CompareTag("WallHead"))
        {
            player.SetParent(null);
        }
    }
}
