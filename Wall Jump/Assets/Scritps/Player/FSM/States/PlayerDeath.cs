using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : State
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform camera;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private PlayerPhysic physic;
    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float blinkingDelay;

    private PlayerFSM fsm;
    private readonly int isDead = Animator.StringToHash("isDead");

    public override void Enter(PlayerFSM fsm)
    {
        this.fsm = fsm;
        physic.VelocityZero();
        physic.GravityScaleZero();

        StartCoroutine(Blinking());
    }

    public override void Execute(PlayerFSM fsm)
    {
        switch (Player.Instance.currnetState)
        {
            case PlayerState.OnGround:
                fsm.ChangeState(PlayerState.OnGround);
                break;
        }
    }

    public override void Exit(PlayerFSM fsm)
    {
        animator.SetBool(isDead, false);
    }

    IEnumerator Blinking()
    {
        animator.speed = 0;
        yield return new WaitForSeconds(blinkingDelay * 3);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(blinkingDelay);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(blinkingDelay);
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(blinkingDelay);
        spriteRenderer.enabled = true;
        yield return new WaitForSeconds(blinkingDelay * 3);
        animator.speed = 1;

        animator.SetBool(isDead, true);
    }
}
