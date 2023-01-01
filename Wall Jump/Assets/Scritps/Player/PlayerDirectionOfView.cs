using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionOfView : MonoBehaviour
{
    /// <summary>
    /// 플레이어를 오른쪽으로 바라보게 만들고, 현재 방향을 오른쪽으로 설정합니다.
    /// </summary>
    public void RightView()
    {
        transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        Player.Instance.currentDirection = PlayerDirection.Right;
    }

    /// <summary>
    /// 플레이어를 왼쪽으로 바라보게 만들고, 현재 방향을 왼쪽으로 설정합니다.
    /// </summary>
    public void LeftView() 
    {
        transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        Player.Instance.currentDirection = PlayerDirection.Left;
    }

    /// <summary>
    /// 현재 바라보는 방향의 역방향을 바라보게 만들고, 현재 방향의 역방향을 방향으로 설정합니다.
    /// </summary>
    public void ReverseView()
    {
        Debug.Log("리버스");
        if (Player.Instance.currentDirection == PlayerDirection.Left)
        {
            RightView();
        }
        else if (Player.Instance.currentDirection == PlayerDirection.Right)
        {
            LeftView();
        }
    }

    public void SynchronizationView()
    {
        if (Player.Instance.currentDirection == PlayerDirection.Left)
        {
            LeftView();
        }
        else if (Player.Instance.currentDirection == PlayerDirection.Right)
        {
            RightView();
        }
    }
}