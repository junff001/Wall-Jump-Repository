using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPhysic : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rigidbody;

    public void SetVelocity(Vector3 value)
    {
        rigidbody.velocity = value;
    }

    public void SetGravityScale(float value)
    {
        rigidbody.gravityScale = value;
    }

    public void VelocityZero()
    {
        rigidbody.velocity = Vector3.zero;
    }

    public void GravityScaleZero()
    {
        rigidbody.gravityScale = 0f;
    }
}
