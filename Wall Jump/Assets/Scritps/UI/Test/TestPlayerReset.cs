using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class TestPlayerReset : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform resetPosition;

    public void PlayerPositionReset()
    {
        player.GetComponent<Rigidbody2D>().gravityScale = 1;
        player.position = resetPosition.position;
        player.localScale = new Vector3(1, player.localScale.y, player.localScale.z);
        Player.Instance.currentDirection = PlayerDirection.Right;
    }
}
