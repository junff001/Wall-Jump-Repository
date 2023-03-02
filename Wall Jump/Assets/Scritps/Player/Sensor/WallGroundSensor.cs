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
    [SerializeField] private BoxCollider2D wallGroundCollider;

    [Header("[ Correction Value Variables ]")]
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
                    if (Player.Instance.currnetState == PlayerState.BasicJump || Player.Instance.currnetState == PlayerState.AerialJump || Player.Instance.currnetState == PlayerState.BashJump)
                    {
                        Player.Instance.currnetState = PlayerState.PostureCorrection;
                        player.SetParent(collision.transform);

                        Transform leftPoint = collision.transform.GetChild(1);
                        Transform rightPoint = collision.transform.GetChild(2);

                        if (leftPoint.gameObject.activeSelf && rightPoint.gameObject.activeSelf)
                        {
                            // ���� �� Ȱ��ȭ ����
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
                            // ���ʸ� Ȱ��ȭ ����
                            StartCoroutine(postureCorrection.MoveToSideOfWall(leftPoint, directionOfView.LeftView));
                        }
                        else if (!leftPoint.gameObject.activeSelf && rightPoint.gameObject.activeSelf)
                        {
                            // �����ʸ� Ȱ��ȭ ����
                            StartCoroutine(postureCorrection.MoveToSideOfWall(rightPoint, directionOfView.RightView));
                        }
                    }
                }
                else if (correctionCriteria.position.y >= player.position.y + playerCorrectionHeight)
                {
                    if (Player.Instance.currnetState != PlayerState.OnGround)
                    {
                        Player.Instance.currnetState = PlayerState.StickToWall;
                        player.SetParent(collision.transform);
                    }
                }
                break;
            }
            case "Ground":
            {
                wallGroundCollider.enabled = false;
                Player.Instance.currnetState = PlayerState.OnGround;
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
