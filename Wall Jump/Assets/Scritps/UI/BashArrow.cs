using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BashArrow : MonoBehaviour
{
    void Update()
    {
        Vector3 direction = InputManager.Instance.swipeDistance.normalized;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }
}
