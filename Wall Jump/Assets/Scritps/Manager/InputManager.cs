using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public bool isSwipe { get; set; } = false;

    public Vector2 startTouchPosition { get; set; } = Vector2.zero;
    public Vector2 endTouchPosition { get; set; } = Vector2.zero;
    public Vector2 swipeDistance { get; set; } = Vector2.zero;

    public float swipeRange = 0f;

    float a;

    private void Start()
    {
        a = Camera.main.orthographicSize;
        Camera.main.orthographicSize = Camera.main.orthographicSize * 0.5625f / (Screen.width / (float)Screen.height);
    }

    void Update()
    {
        Camera.main.orthographicSize = a * 0.5625f / (Screen.width / (float)Screen.height);

        Swipe();
    }

    void Swipe()
    {
        if (PlayerStatus.CurrentState == PlayerState.BashJump)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                endTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
            if (Input.GetMouseButton(0))
            {
                endTouchPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
            //{
            //    startTouchPosition = Input.GetTouch(0).position;
            //    endTouchPosition = Input.GetTouch(0).position;
            //}
            //if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
            //{
            //    endTouchPosition = Input.GetTouch(0).position;
            //}

            swipeDistance = endTouchPosition - startTouchPosition;

            if (swipeDistance.x > swipeRange
                || swipeDistance.x < -swipeRange
                || swipeDistance.y > swipeRange
                || swipeDistance.y < -swipeRange)
            {
                isSwipe = true;
            }
            else
            {
                isSwipe = false;
            }
        }
    }
}
