using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class UpElevateWall : MonoBehaviour
{
    [Header("[ Elevate Variables ]")]
    [SerializeField] private float elevateSpeed;

    [Header("[ Animation Variables ]")]
    [SerializeField] private Transform arrowChildGroup1;
    [SerializeField] private List<SpriteRenderer> childGroup1InIcons;
    [SerializeField] private Transform arrowChildGroup2;
    [SerializeField] private List<SpriteRenderer> childGroup2InIcons;
    [SerializeField] private Transform arrowParentGroup;
    private Vector2 startPoint;
    private Vector2 groupEndPosition;
    private Vector2 iconStartPosition;
    private Vector2 iconEndPosition;
    
    private void Start()
    {
        startPoint = arrowParentGroup.position;
        groupEndPosition = arrowChildGroup1.position;

        iconEndPosition = childGroup1InIcons[0].transform.position;
        iconStartPosition = childGroup1InIcons[childGroup1InIcons.Count - 1].transform.position;

        StartCoroutine(OnAnimation());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Elevating());
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (Player.Instance.currnetState == PlayerState.StickToWall || Player.Instance.currnetState == PlayerState.PostureCorrection)
            {
                if (!Player.Instance.isPostureCorrecting)
                {
                    StopCoroutine(Elevating());
                    Player.Instance.physic.SetGravityScale(1f);
                }
            }
        }
    }

    private IEnumerator Elevating()
    {
        Player.Instance.physic.GravityScaleZero();
        Player.Instance.physic.VelocityZero();
        yield return new WaitUntil(() => !Player.Instance.isPostureCorrecting);

        while ((Player.Instance.currnetState == PlayerState.StickToWall ||
            Player.Instance.currnetState == PlayerState.PostureCorrection) &&
            Player.Instance.currentStickToWall == this.transform)
        {
            Player.Instance.transform.Translate(Vector2.up * Time.deltaTime * elevateSpeed);
            yield return null;
        }
    }

    private IEnumerator OnAnimation()
    {
        while (true)
        {
            #region 위로 올라가기
            arrowParentGroup.Translate(Vector2.up * elevateSpeed * Time.deltaTime);
            #endregion

            for (int i = 0; i < childGroup1InIcons.Count; i++)
            {
                if (childGroup1InIcons[i].transform.position.y >= iconEndPosition.y)
                {
                    childGroup1InIcons[i].enabled = false;
                }
            }

            #region 무한 스크롤
            if (arrowChildGroup2.position.y >= groupEndPosition.y)
            {
                for (int i = 0; i < childGroup2InIcons.Count; i++)
                {
                    childGroup2InIcons[i].enabled = false;
                }
                arrowParentGroup.position = startPoint;

                for (int i = 0; i < childGroup1InIcons.Count; i++)
                {
                    childGroup1InIcons[i].enabled = true;
                }
            }
            #endregion 

            for (int i = 0; i < childGroup2InIcons.Count; i++)
            {
                if (childGroup2InIcons[i].transform.position.y >= iconStartPosition.y)
                {
                    childGroup2InIcons[i].enabled = true;
                }
            }

            yield return null;
        }
    }
}
