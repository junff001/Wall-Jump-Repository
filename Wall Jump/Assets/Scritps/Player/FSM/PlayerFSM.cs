using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    [SerializeField] private PlayerStateDictionary stateDictionary = new PlayerStateDictionary();
    private State currentState;

    void Start()
    {
        currentState = stateDictionary[PlayerState.Idle];
        currentState.Enter(this);
    }

    void Update()
    {
        if (currentState != null)
        {
            currentState.Execute(this);
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
    }
}
