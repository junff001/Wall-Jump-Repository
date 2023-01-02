using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPath : MonoBehaviour
{
    [Header("[ Component Varibales ]")]
    [SerializeField] private LineRenderer pathLine;
    
    [Header("[ Way Point Variables ]")]
    [SerializeField] private Transform startPoint;
    [SerializeField] private Transform endPoint;

    private void Start()
    {
        DrawLineRendererMovingPath();
    }

    private void OnDrawGizmos()
    {
        DrawLineRendererMovingPath();
    }

    private void DrawLineRendererMovingPath()
    {
        if (startPoint != null && endPoint != null)
        {
            pathLine.SetPosition(0, startPoint.localPosition);
            pathLine.SetPosition(1, endPoint.localPosition);
        }   
    }
}
