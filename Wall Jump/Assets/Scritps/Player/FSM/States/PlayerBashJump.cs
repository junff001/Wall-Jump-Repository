using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBashJump : State
{
    [SerializeField] private GameObject arrowPivot;
    [SerializeField] private GameObject arrow;
    [SerializeField] private float fallGravity;
    [SerializeField] private float bashDistance;
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Transform player;
   

    public override void Enter(PlayerFSM fsm)
    {
        StartCoroutine(BashJump());
    }

    public override void Execute(PlayerFSM fsm)
    {
        switch (PlayerStatus.CurrentState)
        {
            case PlayerState.OnGround:
                fsm.ChangeState(PlayerState.OnGround);
                break;
            case PlayerState.StickToWall:
                fsm.ChangeState(PlayerState.StickToWall);
                break;
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        
    }

    IEnumerator BashJump()
    {
        TimeManager.Instance.SlowMotion();

        while (Input.GetMouseButton(0) && PlayerStatus.Bashable)
        {
            if (InputManager.Instance.swipeDistance.magnitude > 1)
            {
                arrowPivot.SetActive(true);
                arrowPivot.transform.position = player.position;
            }

           

            yield return null;
        }

        arrowPivot.SetActive(false);
    
        TimeManager.Instance.TrunBackTime();

        if (InputManager.Instance.isSwipe)
        {
            
        }

        if (rigidbody.velocity.x > 0)
        {
            Debug.Log("¿À¸¥ÂÊ");
            rigidbody.transform.localScale = new Vector3(1, rigidbody.transform.localScale.y, rigidbody.transform.localScale.z);
            PlayerStatus.CurrentDirection = PlayerDirection.Right;

        }
        else if (rigidbody.velocity.x < 0)
        {
            Debug.Log("¿ÞÂÊ");
            rigidbody.transform.localScale = new Vector3(-1, rigidbody.transform.localScale.y, rigidbody.transform.localScale.z);
            PlayerStatus.CurrentDirection = PlayerDirection.Left;
        }  
    }
}
