using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBashJump : State
{
    [SerializeField] private GameObject arrowPivot;
    [SerializeField] private GameObject arrow;
    [SerializeField] private float bashTime;
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
        rigidbody.velocity = Vector2.zero;
        rigidbody.gravityScale = 0;

        arrowPivot.transform.position = UICamera.mainCamera.ViewportToWorldPoint(Camera.main.WorldToViewportPoint(UIManager.Instance.currentBashObjectPosition));

        arrowPivot.SetActive(true);

        while (!InputManager.Instance.isRelease)
        {
            yield return null;
        }

        arrowPivot.SetActive(false);
        rigidbody.gravityScale = 1;
        Vector2 direction = Input.mousePosition.normalized;
        rigidbody.velocity = direction * bashDistance;
        Debug.Log(direction);

        float currentBashTime = bashTime;

        //while (currentBashTime > 0)
        //{
        //    currentBashTime -= Time.deltaTime;
        //    rigidbody.transform.position = Vector2.MoveTowards(rigidbody.transform.position, bashPos, bashTime);
        //}
    }
}
