using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonMove : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float stopTime;

    private int i;
    private float timer;

    void Start()
    {
        transform.position = points[0].localPosition;
        timer = stopTime;
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, points[i].localPosition) < 0.02f)
        {
            timer -= Time.deltaTime;

            if (timer <= 0)
            {
                timer = stopTime;
                i++;
                if (i == points.Count)
                {
                    i = 0;
                }
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, points[i].localPosition, moveSpeed * Time.deltaTime);
    }
}
