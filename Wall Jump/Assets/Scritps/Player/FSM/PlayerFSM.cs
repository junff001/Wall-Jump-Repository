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

    // �ش� Ű �� �����ϰ�, ���� Ű �� ���� Ű�� �ƴ϶��
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
