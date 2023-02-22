using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
    public void FixingCamera()
    {

    }

    public void UnfixingCamera()
    {

    }

    public void ChangeStateToDeath()
    {
        Player.Instance.currnetState = EPlayerState.DEATH;
    }
}
