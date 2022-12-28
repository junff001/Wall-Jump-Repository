using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWall : MonoBehaviour
{
    [Header("[ Flip Variables ]")]
    [SerializeField] private float flipTime;
    [SerializeField] private float flipMoveDistance;
    [SerializeField] private Transform flipObjects;

    [Header("[ Timer Variables ]")]
    [SerializeField] private Transform timer;
    [SerializeField] private SpriteRenderer timerRenderer;
    [SerializeField] private List<Sprite> numberSprites;

    [Header("[ Components Variables ]")]
    [SerializeField] private BoxCollider2D wallCollider;

    private int index = 0;

    private void Start()
    {
        index = numberSprites.Count - 1;
        timerRenderer.sprite = numberSprites[index];
        StartCoroutine(RunTimer());
    }

    private IEnumerator RunTimer()
    {
        yield return new WaitForSeconds(1f);
        index--;
        timerRenderer.sprite = numberSprites[index];

        if (index > 0)
        {
            StartCoroutine(RunTimer());
        }
        else if (index <= 0)
        {
            StartCoroutine(OnFlip());
        }
    }

    private IEnumerator OnFlip()
    {
        float currentTime = 0;
        float startScaleX = flipObjects.localScale.x;
        float endcScaleX = startScaleX * -1f;

        float playerStartPosX = 0;
        float playerEndPosX = 0;

        wallCollider.isTrigger = true;

        if (Player.Instance.currentStickToWall == this.transform)
        {
            playerStartPosX = Player.Instance.transform.position.x;

            if (Player.Instance.currentDirection == PlayerDirection.Left)
            {
                // 오른쪽으로
                playerEndPosX = playerStartPosX + flipMoveDistance;
            }
            else if (Player.Instance.currentDirection == PlayerDirection.Right)
            {
                // 왼쪽으로
                playerEndPosX = playerStartPosX - flipMoveDistance;
            }
               
            Player.Instance.canJumping = false;
        }

        while (currentTime < flipTime)
        {
            currentTime += Time.deltaTime;

            if (currentTime > flipTime)
            {
                currentTime = flipTime;
            }

            float flipScaleX = Mathf.Lerp(startScaleX, endcScaleX, currentTime / flipTime);
            flipObjects.localScale = new Vector3(flipScaleX, flipObjects.localScale.y, flipObjects.localScale.z);

            if (Player.Instance.currentStickToWall == this.transform && !Player.Instance.isPostureCorrecting)
            {
                float playerFlipPosX = Mathf.Lerp(playerStartPosX, playerEndPosX, currentTime / flipTime);
                Player.Instance.transform.position = new Vector3(playerFlipPosX, Player.Instance.transform.position.y, Player.Instance.transform.position.z);
            }

            yield return null;
        }

        wallCollider.isTrigger = false;

        if (Player.Instance.currentStickToWall == this.transform && !Player.Instance.isPostureCorrecting)
        {
            Player.Instance.directionOfView.ReverseView();
            Player.Instance.canJumping = true;
        }

        index = numberSprites.Count - 1;
        timerRenderer.sprite = numberSprites[index];
        StartCoroutine(RunTimer());
    }
}
