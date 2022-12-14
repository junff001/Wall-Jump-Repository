using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FlipWall : MonoBehaviour
{
    public float flipTime;
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
        float startScaleX = transform.localScale.x;
        float playerStartPosX = 0;
        float playerStartScaleX = 0;

        if (player != null)
        {
           playerStartPosX = player.position.x;
           playerStartScaleX = player.localScale.x; 
        }
       

        isFliping = true;
        Debug.Log("플립 함");
        while (time < flipTime)
        {
            time += Time.deltaTime;
            
            if (time > flipTime)
            {
                time = flipTime;
            }

            transform.localScale = new Vector3(Mathf.Lerp(startScaleX, startScaleX * -1f, time / flipTime), transform.localScale.y, transform.localScale.z);

            if (player != null && !PlayerStatus.IsPostureCorrection)
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

        if (player != null && !PlayerStatus.IsPostureCorrection)
        {
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
        

        isFliping = false;

        
        //transform.DOScaleX(transform.localScale.x * -1f, flipTime);

        //if (player != null)
        //{
        //    if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
        //    {
        //        player.DOMoveX(player.position.x + 1.2f, flipTime);
        //        player.DOScaleX(player.localScale.x * -1f, flipTime);
        //        PlayerStatus.CurrentDirection = PlayerDirection.Right;
        //    }
        //    else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
        //    {
        //        player.DOMoveX(player.position.x - 1.2f, flipTime);
        //        player.DOScaleX(player.localScale.x * -1f, flipTime);
        //        PlayerStatus.CurrentDirection = PlayerDirection.Left;
        //    }
        //}

        index = numberSprites.Count - 1;
        spriteRenderer.sprite = numberSprites[index];
        Debug.Log("플립 안함");
        StartCoroutine(ChangeSprite());
    }
}
