using UnityEngine;

public abstract class TransitionCondition : MonoBehaviour
{
    public abstract void Condition(PlayerFSM fsm);
}
