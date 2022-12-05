using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfiniteScrollingCloud : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Vector3 startPos;
    private Vector3 firstCloud;

    void Start()
    {
        startPos = transform.position;
        firstCloud = transform.GetChild(0).TransformPoint(transform.GetChild(0).position);
    }

    void Update()
    {
        InfiniteScrolling();
    }

    void Move()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);
    }

    void InfiniteScrolling()
    {
        Move();

        if (transform.GetChild(1).TransformPoint(transform.GetChild(1).position).x <= firstCloud.x)
        {
            startPos.y = transform.position.y;
            transform.position = startPos;
        }
    }
}
