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
}
