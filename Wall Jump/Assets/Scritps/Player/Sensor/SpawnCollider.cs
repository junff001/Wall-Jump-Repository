using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnCollider"))
        {
            GameObject nextStage = Instantiate(GameManager.Instance.stagePrefab);
            nextStage.transform.parent = GameManager.Instance.stageParent;
            Transform jointTrm = collision.transform.GetChild(0);
            nextStage.transform.position = jointTrm.position;
        }
    }
}
