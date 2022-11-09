using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFilp : MonoBehaviour
{
    public void FilpX()
    {
        if (PlayerStatus.Direction == PlayerDirection.Left)
        {
            transform.localScale = new Vector3(1, transform.localScale.y, transform.localScale.z);
            PlayerStatus.Direction = PlayerDirection.Right;
        }
        else if (PlayerStatus.Direction == PlayerDirection.Right)
        {
            transform.localScale = new Vector3(-1, transform.localScale.y, transform.localScale.z);
            PlayerStatus.Direction = PlayerDirection.Left;
        }
    }
}