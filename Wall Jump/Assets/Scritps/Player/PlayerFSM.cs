using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFSM : MonoBehaviour
{
    [SerializeField] private PlayerStateDictionary stateDictionary = new PlayerStateDictionary();
    private State currentState;

    void Start()
    {
        //currentState = stateDictionary[PlayerState.Idle];
        //currentState.Enter();
    }

    void Update()
    {
        //if (currentState != null)
        //{
        //    currentState.Execute();
        //}
    }

    public void ChangeState(PlayerState newState)
    {
        //if (stateDictionary.ContainsKey(newState))
        //{
        //    if (currentState != null)
        //    {
        //        currentState.Exit();
        //    }

        //    currentState = stateDictionary[newState];
        //    currentState.Enter();
        //}
    }
}
