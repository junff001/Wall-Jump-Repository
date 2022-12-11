using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoSingleton<InputManager>
{
    public Vector2 startTouchPosition { get; set; } = Vector2.zero;
    public Vector2 endTouchPosition { get; set; } = Vector2.zero;
    public Vector2 swipeDistance { get; set; } = Vector2.zero;

    public bool isSwipe { get; set; } = false;
    public float swipeRange = 0f;
    public float quickSwipeTime = 0f;
    public bool isStart { get; set; } = true;

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
        // 에디터 테스트
        //if (Input.GetMouseButtonDown(0))
        //{
        //    startTouchPosition = Input.mousePosition;
        //    endTouchPosition = Input.mousePosition;
        //}
        //if (Input.GetMouseButton(0))
        //{
        //    endTouchPosition = Input.mousePosition;
        //    swipeDistance = endTouchPosition - startTouchPosition;

        //    if (Mathf.Abs(swipeDistance.x) >= swipeRange || Mathf.Abs(swipeDistance.y) >= swipeRange)
        //    {
        //        isSwipe = true;
        //    }
        //    else
        //    {
        //        isSwipe = false;
        //    }
        //}

        // 모바일 테스트
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            startTouchPosition = Input.GetTouch(0).position;
            endTouchPosition = Input.GetTouch(0).position;

            float currentTime = 0;

            currentTime += Time.deltaTime;

            if (currentTime >= quickSwipeTime)
            {
                currentTime = quickSwipeTime;
            }
        }
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            endTouchPosition = Input.GetTouch(0).position;
            swipeDistance = endTouchPosition - startTouchPosition;

            if (Mathf.Abs(swipeDistance.x) >= swipeRange || Mathf.Abs(swipeDistance.y) >= swipeRange)
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
