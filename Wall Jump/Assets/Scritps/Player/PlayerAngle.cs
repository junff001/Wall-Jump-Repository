using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAngle : MonoBehaviour
{
    public void SetAngle(Vector3 degree)
    {
        transform.eulerAngles = degree;
    }

    public void AngleReset()
    {
        transform.eulerAngles = Vector3.zero;
    }
}
