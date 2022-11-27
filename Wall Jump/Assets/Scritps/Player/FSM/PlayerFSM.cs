using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    [SerializeField] private PlayerStateDictionary stateDictionary = new PlayerStateDictionary();
    [SerializeField] private Rigidbody2D rigidbody;
    [SerializeField] private float fallMultiplier;
    [SerializeField] private float lowJumpMultiplier;
    private State currentState;

    void Start()
    {
        currentState = stateDictionary[PlayerState.OnGround];
        currentState.Enter(this);
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.Execute(this);
        } 
    }

    void FixedUpdate()
    {
        if (rigidbody.velocity.y < 0)
        {
            rigidbody.gravityScale = fallMultiplier;
        }
        else if (rigidbody.velocity.y > 0)
        {
            rigidbody.gravityScale = lowJumpMultiplier;
        }
    }

    // 해당 키 가 존재하고, 현재 키 와 같은 키가 아니라면
    public void ChangeState(PlayerState newState)
    {
        if (currentState != stateDictionary[newState])
        {
            if (currentState != null)
            {
                currentState.Exit(this);
            }

            currentState = stateDictionary[newState];
            currentState.Enter(this);
        }

       // Debug.Log(currentState.name);
    }

    public void TransitionToJump()
    {
        IPressTheScreenToTransition transition = currentState.GetComponent<IPressTheScreenToTransition>();

        if (transition != null)
        {
            transition.Transition();
        }

    }
}
