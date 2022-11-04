using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFilp : MonoBehaviour
{
    public void FilpX()
    {
        transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
