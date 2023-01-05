using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

enum ThornDirectionOfView
{
    Left,
    Right,
    Up,
    Down
}

public class ThornAnimation : MonoBehaviour
{
    [Header("[ Direction Of View Variables ]")]
    [SerializeField] private ThornDirectionOfView directionOfView;

    [Header("[ Position Variables ]")]
    [SerializeField] private float outDegree;
    private Vector2 startPosition;
    private Vector2 endPosition;

    [Header("[ Speed Variables ]")]
    [SerializeField] private float speed;

    private void Start()
    {
        switch (directionOfView)
        {
            case ThornDirectionOfView.Left:
            {
                startPosition = transform.position;
                endPosition = startPosition + new Vector2(-outDegree, 0);
                StartCoroutine(RepeatedMovement(Vector2.left, endPosition));
                break; 
            }   
            case ThornDirectionOfView.Right:
            {
                startPosition = transform.position;
                endPosition = startPosition + new Vector2(outDegree, 0);
                StartCoroutine(RepeatedMovement(Vector2.right, endPosition));
                break;
            }
            case ThornDirectionOfView.Up:
            {
                startPosition = transform.position;
                endPosition = startPosition + new Vector2(0, outDegree);
                StartCoroutine(RepeatedMovement(Vector2.up, endPosition));
                break;
            }
            case ThornDirectionOfView.Down:
            {
                startPosition = transform.position;
                endPosition = startPosition + new Vector2(0, -outDegree);
                StartCoroutine(RepeatedMovement(Vector2.down, endPosition));
                break;
            }
        }
    }

    private IEnumerator RepeatedMovement(Vector2 direction, Vector2 target)
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, Time.deltaTime * speed);

            if (transform.position == (Vector3)target)
            {
                transform.position = startPosition;
            }

            yield return null;
        }
    }
}
