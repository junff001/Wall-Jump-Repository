using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFilp : MonoBehaviour
{
    public void FilpX()
    {
        if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            PlayerStatus.CurrentDirection = PlayerDirection.Right;
        }
        else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            PlayerStatus.CurrentDirection = PlayerDirection.Left;
        }
    }
}