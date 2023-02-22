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
        Player.Instance.currentDirection = EPlayerDirection.RIGHT;
    }

    /// <summary>
    /// �÷��̾ �������� �ٶ󺸰� �����, ���� ������ �������� �����մϴ�.
    /// </summary>
    public void LeftView() 
    {
        transform.localScale = new Vector3(-1f, transform.localScale.y, transform.localScale.z);
        Player.Instance.currentDirection = EPlayerDirection.LEFT;
    }

    /// <summary>
    /// ���� �ٶ󺸴� ������ �������� �ٶ󺸰� �����, ���� ������ �������� �������� �����մϴ�.
    /// </summary>
    public void ReverseView()
    {
        if (Player.Instance.currentDirection == EPlayerDirection.LEFT)
        {
            RightView();
        }
        else if (Player.Instance.currentDirection == EPlayerDirection.RIGHT)
        {
            LeftView();
        }
    }
}