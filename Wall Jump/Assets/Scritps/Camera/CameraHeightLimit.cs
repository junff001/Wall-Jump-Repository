using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHeightLimit : MonoBehaviour
{
    [Header("[ Component Variables ]")]
    [SerializeField] private Transform player;
    [SerializeField] private ProCamera2D proCamera2D;

    private float previousHeight;

    private void Start()
    {
        InitializePreviousHeight();
        StartCoroutine(HeightChecking());
    }

    private IEnumerator HeightChecking()
    {
        while (true)
        {
            if (previousHeight < player.position.y)
            {
                InitializePreviousHeight();

                if (!proCamera2D.FollowVertical)
                {
                    proCamera2D.FollowVertical = true;
                }
            }
            else if (previousHeight >= player.position.y)
            {
                if (proCamera2D.FollowVertical)
                {
                    proCamera2D.FollowVertical = false;
                }
            }

            yield return null;
        }
    }

    public void InitializePreviousHeight()
    {
        previousHeight = player.position.y;
    }
}
