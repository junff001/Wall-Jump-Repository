using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnCollider"))
        {
            if (collision.gameObject != GameManager.Instance.CurrentSpawnCollider || GameManager.Instance.CurrentSpawnCollider == null) 
            {
                GameManager.Instance.CurrentSpawnCollider = collision.gameObject;
                PoolManager.Instance.RandomSpawnStageTest(collision.transform.GetChild(0).position);
            }
        }
    }
}
