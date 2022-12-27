using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallGroundSensor : MonoBehaviour
{
    [Header("[ Components Variables ]")]
    [SerializeField] private Transform player;
    [SerializeField] private PlayerDirectionOfView directionOfView;
    [SerializeField] private PlayerPostureCorrection postureCorrection;

    [Header("[ Correction Value Variables ]")]
    [SerializeField] private float playerCorrectionHeight;
    [SerializeField] private float wallCorrectionHeight;

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
                Transform correctionCriteria = collision.transform.GetChild(0);

                if (correctionCriteria.position.y < player.position.y + playerCorrectionHeight)
                {
                    if (PlayerStatus.CurrentState == PlayerState.BasicJump || PlayerStatus.CurrentState == PlayerState.AerialJump || PlayerStatus.CurrentState == PlayerState.BashJump)
                    {
                        PlayerStatus.CurrentState = PlayerState.PostureCorrection;
                        player.SetParent(collision.transform.parent);

                        Transform leftPoint = collision.transform.GetChild(1);
                        Transform rightPoint = collision.transform.GetChild(2);

                        if (leftPoint.gameObject.activeSelf && rightPoint.gameObject.activeSelf)
                        {
                            // 양쪽 다 활성화 상태
                            if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
                            {
                                StartCoroutine(postureCorrection.MoveToSideOfWall(rightPoint));
                            }
                            else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
                            {
                                StartCoroutine(postureCorrection.MoveToSideOfWall(leftPoint));
                            }

                            directionOfView.ReverseView();
                        }   
                        else if (leftPoint.gameObject.activeSelf && !rightPoint.gameObject.activeSelf)
                        {
                            // 왼쪽만 활성화 상태
                            StartCoroutine(postureCorrection.MoveToSideOfWall(leftPoint));
                            directionOfView.LeftView();
                        }
                        else if (!leftPoint.gameObject.activeSelf && rightPoint.gameObject.activeSelf)
                        {
                            // 오른쪽만 활성화 상태
                            StartCoroutine(postureCorrection.MoveToSideOfWall(rightPoint));
                            directionOfView.RightView();
                        }
                    }
                }
                else if (correctionCriteria.position.y >= player.position.y + playerCorrectionHeight)
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
        if (collision.gameObject.CompareTag("Wall"))
        {
            player.SetParent(null);
        }
    }
}
