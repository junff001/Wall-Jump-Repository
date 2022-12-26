using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlipWall : MonoBehaviour
{
    [Header("[ Flip Variables ]")]
    [SerializeField] private float flipTime;

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
        float startScaleX = transform.localScale.x;
        float endcScaleX = startScaleX * -1f;

        while (currentTime < flipTime)
        {
            currentTime += Time.deltaTime;

            if (currentTime > flipTime)
            {
                currentTime = flipTime;
            }

            float flipScaleX = Mathf.Lerp(startScaleX, endcScaleX, currentTime / flipTime);
            transform.localScale = new Vector3(flipScaleX, transform.localScale.y, transform.localScale.z);

            yield return null;
        }

        float originTimerScaleX = timer.localScale.x * -1f;
        timer.localScale = new Vector3(originTimerScaleX, timer.localScale.y, timer.localScale.z);
        index = numberSprites.Count - 1;
        timerRenderer.sprite = numberSprites[index];
        StartCoroutine(RunTimer());
    }

    

    //IEnumerator OnFlip()
    //{
    //    float time = 0;
    //    float startScaleX = transform.localScale.x;
    //    float playerStartPosX = 0;
    //    float playerStartScaleX = 0;

    //    if (player != null)
    //    {
    //       playerStartPosX = player.position.x;
    //       playerStartScaleX = player.localScale.x; 
    //    }
       
    //    isFliping = true;


    //    if (PlayerStatus.IsPostureCorrection)
    //    {
    //        while (time < flipTime)
    //        {
    //            time += Time.deltaTime;

    //            if (time > flipTime)
    //            {
    //                time = flipTime;
    //            }

    //            parent.localScale = new Vector3(Mathf.Lerp(startScaleX, startScaleX * -1f, time / flipTime), parent.localScale.y, parent.localScale.z);

                
    //            yield return null;
    //        }
    //    }
    //    else
    //    {
    //        while (time < flipTime)
    //        {
    //            time += Time.deltaTime;

    //            if (time > flipTime)
    //            {
    //                time = flipTime;
    //            }

    //            parent.localScale = new Vector3(Mathf.Lerp(startScaleX, startScaleX * -1f, time / flipTime), parent.localScale.y, parent.localScale.z);

    //            if (player != null)
    //            {
    //                if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
    //                {
    //                    player.position = new Vector3(Mathf.Lerp(playerStartPosX, playerStartPosX + 1.2f, time / flipTime), player.position.y, player.position.z);
    //                }
    //                else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
    //                {
    //                    player.position = new Vector3(Mathf.Lerp(playerStartPosX, playerStartPosX - 1.2f, time / flipTime), player.position.y, player.position.z);
    //                }
    //            }

    //            yield return null;
    //        }

    //        if (player != null)
    //        {

    //            if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
    //            {
    //                PlayerStatus.CurrentDirection = PlayerDirection.Right;
    //            }
    //            else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
    //            {
    //                PlayerStatus.CurrentDirection = PlayerDirection.Left;
    //            }

    //            player.localScale = new Vector3(player.localScale.x * -1f, player.localScale.y, player.localScale.z);
    //        }
    //    }

    //    isFliping = false;
    //    timer.localScale = new Vector3(timer.localScale.x * -1f, timer.localScale.y, timer.localScale.z);

    //    index = numberSprites.Count - 1;
    //    timerRenderer.sprite = numberSprites[index];
    //    StartCoroutine(RunTimer());
    //}
}
