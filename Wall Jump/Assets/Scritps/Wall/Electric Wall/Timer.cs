using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private GameObject electricObj;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private List<Sprite> numberSprites;
    private int index = 0;

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
            StartCoroutine(OnElectric());
        }
    }

    IEnumerator OnElectric()
    {
        electricObj.SetActive(true);
        yield return new WaitForSeconds(1f);
        electricObj.SetActive(false);
        index = numberSprites.Count - 1;
        spriteRenderer.sprite = numberSprites[index];
        StartCoroutine(ChangeSprite());
    }
}
