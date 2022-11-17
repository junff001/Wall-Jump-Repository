using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class State : MonoBehaviour
{
    /// <summary>
    /// 해당 상태가 시작될 때 단 한 번만 호출되는 함수
    /// </summary>
    public abstract void Enter(PlayerFSM fsm);

    /// <summary>
    /// 해당 상태가 매 프레임 갱신될 때마다 호출되는 함수
    /// </summary>
    public abstract void Execute(PlayerFSM fsm);

    /// <summary>
    /// 해당 상태가 종료될 때 단 한 번만 호출되는 함수
    /// </summary>
    public abstract void Exit(PlayerFSM fsm);
}
