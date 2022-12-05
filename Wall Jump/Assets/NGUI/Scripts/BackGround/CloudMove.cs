using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CloudMove : MonoBehaviour
{
    [Header("[ Speed ]")]
    [SerializeField] private float moveSpeed;

    [Header("[ Move Points ]")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    void Update()
    {
        RepeatedMovement();
    }

    void RepeatedMovement()
    {
        transform.Translate(Vector2.left * moveSpeed * Time.deltaTime);

        if (transform.position.x <= endPoint.position.x)
        {
            transform.position = startPoint.position;
        }
    }
}
