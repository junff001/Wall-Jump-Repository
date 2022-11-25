using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    [SerializeField] private PlayerStickToWall playerStickToWall;
    List<ContactPoint2D> contactPoints = new List<ContactPoint2D>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            PlayerStatus.CurrentState = PlayerState.OnGround;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            Vector2 contactPoint = contactPoints[collision.GetContacts(contactPoints)].point;
            StartCoroutine(playerStickToWall.MoveToTheWall(contactPoint));
        }
    }
}
