using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostureCorrection : MonoBehaviour
{
    [SerializeField] private float moveToTheWallLerpTime;
    [SerializeField] private float moveRange;
    [SerializeField] private float moveHeight;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
            {

            }
            else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
            {

            }
        }
    }

    public IEnumerator MoveToSideOfWall(Collider2D collider)
    {
        float timer = 0f;

        Vector3 contactPoint = collider.transform.position;
        Vector3 sideOfWallPoint = collider.bounds.center + new Vector3(collider.bounds.extents.x + moveRange, moveHeight, 0);

        while (timer < moveToTheWallLerpTime)
        {
            timer += Time.deltaTime;

            if (timer > moveToTheWallLerpTime)
            {
                timer = moveToTheWallLerpTime;
            }

            collider.transform.localScale = new Vector3(1f, collider.transform.localScale.y, collider.transform.localScale.z);
            collider.transform.position = Vector3.Lerp(contactPoint, sideOfWallPoint, timer / moveToTheWallLerpTime);

            yield return null;
        }

        PlayerStatus.CurrentState = PlayerState.StickToWall;
    }
}
