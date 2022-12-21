using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static DG.Tweening.DOTweenModuleUtils;

public class CollisionEvent : MonoBehaviour
{
    [Header("[ Components ]")]
    [SerializeField] private BoxCollider2D boxCollider;
    [SerializeField] private CircleCollider2D deadBoundCol;
    [SerializeField] private PlayerPhysic physic;

    [Header("[ Move To The Wall Related Variables ]")]
    [SerializeField] private float correctionHorizontal;
    [SerializeField] private float correctionVertical;
    [SerializeField] private float moveToTheWallLerpTime;
    
    [Header("[ Posture Correction Points ]")]
    [SerializeField] private Transform leftPostureCorrectionPoint;
    [SerializeField] private Transform rightPostureCorrectionPoint;

    private void Start()
    {
        leftPostureCorrectionPoint.position = boxCollider.bounds.center + new Vector3(-(boxCollider.bounds.extents.x + correctionHorizontal), correctionVertical, 0);
        rightPostureCorrectionPoint.position = boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x + correctionHorizontal, correctionVertical, 0);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("GroundSensor"))
        {
            if (PlayerStatus.CurrentState == PlayerState.BasicJump || PlayerStatus.CurrentState == PlayerState.AerialJump || PlayerStatus.CurrentState == PlayerState.BashJump)
            {
                Transform player = collision.transform.parent.parent;
                player.SetParent(transform);

                if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
                {
                    physic.GravityScaleZero();
                    StartCoroutine(MoveToSideOfWall(player, rightPostureCorrectionPoint));
                }
                else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
                {
                    physic.GravityScaleZero();
                    StartCoroutine(MoveToSideOfWall(player, leftPostureCorrectionPoint));
                }
            }
        }
    }

    private IEnumerator MoveToSideOfWall(Transform player, Transform postureCorrectionPoint)
    {
        deadBoundCol.enabled = false;
        PlayerStatus.IsPostureCorrection = true;
        float timer = 0f;
        Vector3 contactPoint = player.position;
        while (timer < moveToTheWallLerpTime)
        {
            timer += Time.deltaTime;

            if (timer > moveToTheWallLerpTime)
            {
                timer = moveToTheWallLerpTime;
            }

            player.position = Vector3.Lerp(contactPoint, postureCorrectionPoint.position, timer / moveToTheWallLerpTime);

            yield return null;
        }

        deadBoundCol.enabled = true;
        PlayerStatus.CurrentState = PlayerState.StickToWall;
        PlayerStatus.IsPostureCorrection = false;

        Debug.Log("고쳐잡기 종료");
    }
}
