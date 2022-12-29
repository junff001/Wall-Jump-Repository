using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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
                Player.Instance.currnetState = PlayerState.OnGround;
                break;
            }     
            case "Wall":
            {
                Player.Instance.currentStickToWall = collision.transform;
                Transform correctionCriteria = collision.transform.GetChild(0);

                if (correctionCriteria.position.y < player.position.y + playerCorrectionHeight)
                {
                    if (Player.Instance.currnetState == PlayerState.BasicJump || Player.Instance.currnetState == PlayerState.AerialJump || Player.Instance.currnetState == PlayerState.BashJump)
                    {
                        Player.Instance.currnetState = PlayerState.PostureCorrection;
                        player.SetParent(collision.transform.parent);

                        Transform leftPoint = collision.transform.GetChild(1);
                        Transform rightPoint = collision.transform.GetChild(2);

                        if (leftPoint.gameObject.activeSelf && rightPoint.gameObject.activeSelf)
                        {
                            // 양쪽 다 활성화 상태
                            if (Player.Instance.currentDirection == PlayerDirection.Left)
                            {
                                StartCoroutine(postureCorrection.MoveToSideOfWall(rightPoint, directionOfView.ReverseView));
                            }
                            else if (Player.Instance.currentDirection == PlayerDirection.Right)
                            {
                                StartCoroutine(postureCorrection.MoveToSideOfWall(leftPoint, directionOfView.ReverseView));
                            }
                        }
                        else if (leftPoint.gameObject.activeSelf && !rightPoint.gameObject.activeSelf)
                        {
                            // 왼쪽만 활성화 상태
                            StartCoroutine(postureCorrection.MoveToSideOfWall(leftPoint, directionOfView.LeftView));
                        }
                        else if (!leftPoint.gameObject.activeSelf && rightPoint.gameObject.activeSelf)
                        {
                            // 오른쪽만 활성화 상태
                            StartCoroutine(postureCorrection.MoveToSideOfWall(rightPoint, directionOfView.RightView));
                        }
                    }
                }
                else if (correctionCriteria.position.y >= player.position.y + playerCorrectionHeight)
                {
                    Player.Instance.currnetState = PlayerState.StickToWall;
                    player.SetParent(collision.transform);
                }
            }
            break;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            if (!Player.Instance.isPostureCorrecting)
            {
                Player.Instance.currentStickToWall = null;
                player.SetParent(null);
            }
        }
    }
}
