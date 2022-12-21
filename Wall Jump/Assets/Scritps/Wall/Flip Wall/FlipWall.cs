using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlipWall : MonoBehaviour
{
    public float flipTime;
    [SerializeField] private Transform parent;
    [SerializeField] private Transform timer;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> numberSprites;
    private int index = 0;

    public bool isFliping { get; set; } = false;
    public Transform player { get; set; }

    void Start()
    {
        index = numberSprites.Count - 1;
        spriteRenderer.sprite = numberSprites[index];
        StartCoroutine(ChangeSprite());
    }

    IEnumerator ChangeSprite()
    {
        yield return new WaitForSeconds(1f);
        index--;
        spriteRenderer.sprite = numberSprites[index];

        if (index > 0)
        {
            StartCoroutine(ChangeSprite());
        }
        else if (index <= 0)
        {
           StartCoroutine(OnFlip());
        }
    }

    IEnumerator OnFlip()
    {
        float time = 0;
        float startScaleX = parent.localScale.x;
        float playerStartPosX = 0;
        float playerStartScaleX = 0;

        if (player != null)
        {
           playerStartPosX = player.position.x;
           playerStartScaleX = player.localScale.x; 
        }
       
        isFliping = true;

        if (PlayerStatus.IsPostureCorrection)
        {
            while (time < flipTime)
            {
                time += Time.deltaTime;

                if (time > flipTime)
                {
                    time = flipTime;
                }

                parent.localScale = new Vector3(Mathf.Lerp(startScaleX, startScaleX * -1f, time / flipTime), parent.localScale.y, parent.localScale.z);

                
                yield return null;
            }
        }
        else
        {
            while (time < flipTime)
            {
                time += Time.deltaTime;

                if (time > flipTime)
                {
                    time = flipTime;
                }

                parent.localScale = new Vector3(Mathf.Lerp(startScaleX, startScaleX * -1f, time / flipTime), parent.localScale.y, parent.localScale.z);

                if (player != null)
                {
                    if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
                    {
                        player.position = new Vector3(Mathf.Lerp(playerStartPosX, playerStartPosX + 1.2f, time / flipTime), player.position.y, player.position.z);
                    }
                    else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
                    {
                        player.position = new Vector3(Mathf.Lerp(playerStartPosX, playerStartPosX - 1.2f, time / flipTime), player.position.y, player.position.z);
                    }
                }

                yield return null;
            }

            if (player != null)
            {
                Debug.Log("»Æ¿Œ");
                if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
                {
                    PlayerStatus.CurrentDirection = PlayerDirection.Right;
                }
                else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
                {
                    PlayerStatus.CurrentDirection = PlayerDirection.Left;
                }

                player.localScale = new Vector3(player.localScale.x * -1f, player.localScale.y, player.localScale.z);
            }
        }

        isFliping = false;
        timer.localScale = new Vector3(timer.localScale.x * -1f, timer.localScale.y, timer.localScale.z);

        index = numberSprites.Count - 1;
        spriteRenderer.sprite = numberSprites[index];
        StartCoroutine(ChangeSprite());
    }
}
