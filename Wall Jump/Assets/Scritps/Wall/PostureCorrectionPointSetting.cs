using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostureCorrectionPointSetting : MonoBehaviour
{
    [Header("[ Components ]")]
    [SerializeField] private BoxCollider2D boxCollider;

    [Header("[ Factors ]")]
    [SerializeField] private float horizontalFactor;
    [SerializeField] private float verticalFactor;

    [Header("[ Points ]")]
    public Transform leftPoint;
    public Transform rightPoint;

    void Start()
    {
        leftPoint.position = boxCollider.bounds.center + new Vector3(-(boxCollider.bounds.extents.x + horizontalFactor), verticalFactor, 0);
        rightPoint.position = boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x + horizontalFactor, verticalFactor, 0);
    }
}
