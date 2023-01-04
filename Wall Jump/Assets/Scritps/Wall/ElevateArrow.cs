using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevateArrow : MonoBehaviour
{
    [SerializeField] private Transform endPoint;
    [SerializeField] private Transform restartPoint;
    [SerializeField] private float elevateSpeed;

    private void Start()
    {
        StartCoroutine(OnAnimation());
    }

    private IEnumerator OnAnimation()
    {
        while (true)
        {
            transform.position = Vector2.MoveTowards(transform.position, endPoint.position, Time.deltaTime * elevateSpeed);
            
            if (transform.position.y >= endPoint.position.y)
            {
                transform.position = restartPoint.position;
            }

            yield return null;
        }
    }
}
