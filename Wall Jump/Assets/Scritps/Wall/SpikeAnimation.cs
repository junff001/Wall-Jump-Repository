using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

enum SpikeDirectionOfView
{
    Left,
    Right
}

public class SpikeAnimation : MonoBehaviour
{
    [SerializeField] private SpikeDirectionOfView directionOfView;
    [SerializeField] private float outPosX;
    [SerializeField] private float inPosX;
    [SerializeField] private float speed;
    [SerializeField] private float waitForTime;
    private float timer;

    void Start()
    {
        timer = waitForTime;
    }

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
        else
        {
            if (directionOfView == SpikeDirectionOfView.Left)
            {
                MoveIn(Vector2.right);

                if (transform.localPosition.x >= inPosX)
                {
                    transform.localPosition = new Vector3(outPosX, transform.localPosition.y, transform.localPosition.z);
                }
            }
            else if (directionOfView == SpikeDirectionOfView.Right)
            {
                MoveIn(Vector2.left);

                if (transform.localPosition.x <= inPosX)
                {
                    transform.localPosition = new Vector3(outPosX, transform.localPosition.y, transform.localPosition.z);
                }
            }
        } 
    }

    void MoveIn(Vector2 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
}
