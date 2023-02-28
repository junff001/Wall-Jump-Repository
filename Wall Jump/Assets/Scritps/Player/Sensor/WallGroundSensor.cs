using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WallGroundSensor : MonoBehaviour
{
    [Header("[ Components ]")]
    [SerializeField] private Transform player;
    [SerializeField] private PlayerDirectionOfView directionOfView;
    [SerializeField] private PlayerPostureCorrection postureCorrection;
    [SerializeField] private BoxCollider2D wallGroundCollider;

    [Header("[ Correction Values ]")]
    [SerializeField] private float playerCorrectionHeight;
    [SerializeField] private float wallCorrectionHeight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
            {
                Player.Instance.currentStickToWall = collision.transform;
                Transform correctionCriteria = collision.transform.GetChild(0);

                if (correctionCriteria.position.y < player.position.y + playerCorrectionHeight)
                {
                    if (Player.Instance.currnetState == EPlayerState.BASIC_JUMP || Player.Instance.currnetState == EPlayerState.AERIAL_JUMP || Player.Instance.currnetState == EPlayerState.BASH_JUMP)
                    {
                        Player.Instance.currnetState = EPlayerState.POSTURE_CORRECTION;
                        player.SetParent(collision.transform);

                        Transform leftPoint = collision.transform.GetChild(1);
                        Transform rightPoint = collision.transform.GetChild(2);

                        if (leftPoint.gameObject.activeSelf && rightPoint.gameObject.activeSelf)
                        {
                            // 양쪽 다 활성화 상태
                            if (Player.Instance.currentDirection == EPlayerDirection.LEFT)
                            {
                                StartCoroutine(postureCorrection.MoveToSideOfWall(rightPoint, directionOfView.ReverseView));
                            }
                            else if (Player.Instance.currentDirection == EPlayerDirection.RIGHT)
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
                    if (Player.Instance.currnetState != EPlayerState.ON_GROUND)
                    {
                        Player.Instance.currnetState = EPlayerState.SITCK_TO_WALL;
                        player.SetParent(collision.transform);
                    }
                }
                break;
            }
            case "Ground":
            {
                wallGroundCollider.enabled = false;
                Player.Instance.currnetState = EPlayerState.ON_GROUND;
                break;
            }     
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
            {
                Player.Instance.currentStickToWall = null;
                player.SetParent(null);
                break;
            }             
            case "Ground":
            {
                wallGroundCollider.enabled = true;
                break;
            }
        }
    }
}
