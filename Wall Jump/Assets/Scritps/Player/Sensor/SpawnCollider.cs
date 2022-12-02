using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnCollider"))
        {
            Stage stage = collision.GetComponent<Stage>();

            if (!stage.isEntered)
            {
                stage.isEntered = true;
                PoolManager.Instance.RandomSpawnStageTest(collision.transform.GetChild(0).position);
            }
        }
    }
}
