using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

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
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        Vector2 direction = mousePos - transform.position;
        direction = direction.normalized;
        direction = new Vector3(direction.x, direction.y, 0);
        rigidbody.velocity = direction * bashDistance;
        Debug.Log(rigidbody.velocity);

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
