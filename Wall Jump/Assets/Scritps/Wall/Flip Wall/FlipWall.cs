using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWall : MonoBehaviour
{
    [Header("[ Components Variables ]")]
    [SerializeField] private BoxCollider2D wallCollider;

    [Header("[ Flip Variables ]")]
    [SerializeField] private float flipTime;
    [SerializeField] private float flipMoveDistance;
    [SerializeField] private float minHeightForCorrection;
    [SerializeField] private Transform flipObjects;

    [Header("[ Timer Variables ]")]
    [SerializeField] private Transform timer;
    [SerializeField] private SpriteRenderer timerRenderer;
    [SerializeField] private List<Sprite> numberSprites;
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

        Vector2 playerStartPos = Vector2.zero;
        Vector2 playerEndPos = Vector2.zero;

        if (Player.Instance.currentStickToWall == this.transform)
        {
            playerStartPos = Player.Instance.transform.position;

            if (Player.Instance.currentDirection == PlayerDirection.Left)
            {
                // 오른쪽으로
                if (Player.Instance.transform.position.y >= transform.position.y + minHeightForCorrection)
                {
                    playerEndPos = new Vector2(transform.position.x + flipMoveDistance, transform.position.y);
                }
                else
                {
                    playerEndPos = new Vector2(transform.position.x + flipMoveDistance, Player.Instance.transform.position.y);
                }
                
            }
            else if (Player.Instance.currentDirection == PlayerDirection.Right)
            {
                // 왼쪽으로
                if (Player.Instance.transform.position.y >= transform.position.y + minHeightForCorrection)
                {
                    playerEndPos = new Vector2(transform.position.x - flipMoveDistance, transform.position.y);
                }
                else
                {
                    playerEndPos = new Vector2(transform.position.x - flipMoveDistance, Player.Instance.transform.position.y);
                }
            }
               
            Player.Instance.canJumping = false;
        }

        if (Player.Instance.currentStickToWall == this.transform)
        {
            Player.Instance.IsTheWallCurrentlyFlipping = true;
            wallCollider.isTrigger = true;

            while (currentTime < flipTime)
            {
                currentTime += Time.deltaTime;

                if (currentTime > flipTime)
                {
                    currentTime = flipTime;
                }

                float flipScaleX = Mathf.Lerp(startScaleX, endcScaleX, currentTime / flipTime);
                flipObjects.localScale = new Vector3(flipScaleX, flipObjects.localScale.y, flipObjects.localScale.z);

                Vector2 playerFlipPos = Vector2.Lerp(playerStartPos, playerEndPos, currentTime / flipTime);

                Player.Instance.transform.position = playerFlipPos;

                yield return null;
            }
       
            Player.Instance.directionOfView.ReverseView();
            Player.Instance.canJumping = true;
            wallCollider.isTrigger = false;
            Player.Instance.IsTheWallCurrentlyFlipping = false;
        }
        else
        {
            while (currentTime < flipTime)
            {
                currentTime += Time.deltaTime;

                if (currentTime > flipTime)
                {
                    currentTime = flipTime;
                }

                float flipScaleX = Mathf.Lerp(startScaleX, endcScaleX, currentTime / flipTime);
                flipObjects.localScale = new Vector3(flipScaleX, flipObjects.localScale.y, flipObjects.localScale.z);

                yield return null;
            }
        }

        index = numberSprites.Count - 1;
        timerRenderer.sprite = numberSprites[index];
        StartCoroutine(RunTimer());
    }
}
