using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerReset : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform resetPosition;

    public void PlayerPositionReset()
    {
        Debug.Log("�׽�Ʈ ����");
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        player.position = resetPosition.position;
        PlayerStatus.CurrentDirection = PlayerDirection.Right;
    }
}
