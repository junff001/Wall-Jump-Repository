using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public abstract class State : MonoBehaviour
{
    /// <summary>
    /// �ش� ���°� ���۵� �� �� �� ���� ȣ��Ǵ� �Լ�
    /// </summary>
    public abstract void Enter(PlayerFSM fsm);

    /// <summary>
    /// �ش� ���°� �� ������ ���ŵ� ������ ȣ��Ǵ� �Լ�
    /// </summary>
    public abstract void Execute(PlayerFSM fsm);

    /// <summary>
    /// �ش� ���°� ����� �� �� �� ���� ȣ��Ǵ� �Լ�
    /// </summary>
    public abstract void Exit(PlayerFSM fsm);
}
