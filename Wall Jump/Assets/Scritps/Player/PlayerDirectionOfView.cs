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
        PlayerStatus.CurrentDirection = PlayerDirection.Right;
    }

    /// <summary>
    /// �÷��̾ �������� �ٶ󺸰� �����, ���� ������ �������� �����մϴ�.
    /// </summary>
    public void LeftView() 
    {
        transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        PlayerStatus.CurrentDirection = PlayerDirection.Left;
    }

    /// <summary>
    /// ���� �ٶ󺸴� ������ �������� �ٶ󺸰� �����, ���� ������ �������� �������� �����մϴ�.
    /// </summary>
    public void ReverseView()
    {
        if (PlayerStatus.CurrentDirection == PlayerDirection.Left)
        {
            RightView();
        }
        else if (PlayerStatus.CurrentDirection == PlayerDirection.Right)
        {
            LeftView();
        }
    }
}