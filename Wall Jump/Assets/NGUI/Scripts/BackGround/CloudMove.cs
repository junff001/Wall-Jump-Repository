using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CloudMove : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private BoxCollider2D collider;
    private float colliderWidth;

    void Start()
    {
        colliderWidth = collider.size.x;
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("CloudZone"))
        {

        }
    }
}
