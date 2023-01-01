using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDirectionOfView : MonoBehaviour
{
    /// <summary>
    /// �÷��̾ ���������� �ٶ󺸰� �����, ���� ������ ���������� �����մϴ�.
    /// </summary>
    public void RightView()
    {
        transform.localScale = new Vector3(1f, transform.localScale.y, transform.localScale.z);
        Player.Instance.currentDirection = PlayerDirection.Right;
    }

    /// <summary>
    /// �÷��̾ �������� �ٶ󺸰� �����, ���� ������ �������� �����մϴ�.
    /// </summary>
    public void LeftView() 
    {
        transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        Player.Instance.currentDirection = PlayerDirection.Left;
    }

    /// <summary>
    /// ���� �ٶ󺸴� ������ �������� �ٶ󺸰� �����, ���� ������ �������� �������� �����մϴ�.
    /// </summary>
    public void ReverseView()
    {
        Debug.Log("������");
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