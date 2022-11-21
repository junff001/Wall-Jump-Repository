using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerBashJump : State
{
    [SerializeField] private GameObject arrowPivot;
    [SerializeField] private GameObject arrow;
    [SerializeField] private float fallGravity;
    [SerializeField] private float bashDistance;
    [SerializeField] private Rigidbody2D rigidbody;
   

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
        // 슬로우 모션
        TimeManager.Instance.SlowMotion();
        StartCoroutine(TimeManager.Instance.SlowTimer());
        TimeManager.Instance.TrunBackTime();

        while (!InputManager.Instance.isRelease)
        {
            yield return null;
        }

        if (InputManager.Instance.isSwipe)
        {
            rigidbody.velocity = InputManager.Instance.swipeDistance.normalized * bashDistance;
        }

        

        //Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        //mousePos.z = 0;
        //Vector2 direction = mousePos - transform.position;
        //direction = direction.normalized;
        //direction = new Vector3(direction.x, direction.y, 0);
        //rigidbody.velocity = direction * bashDistance;
        //Debug.Log(rigidbody.velocity);

        if (rigidbody.velocity.x > 0)
        {
            Debug.Log("오른쪽");
            rigidbody.transform.localScale = new Vector3(1, rigidbody.transform.localScale.y, rigidbody.transform.localScale.z);
            PlayerStatus.CurrentDirection = PlayerDirection.Right;
            
        }
        else if (rigidbody.velocity.x < 0)
        {
            Debug.Log("왼쪽");
            rigidbody.transform.localScale = new Vector3(-1, rigidbody.transform.localScale.y, rigidbody.transform.localScale.z);
            PlayerStatus.CurrentDirection = PlayerDirection.Left;
        }
    }
}
