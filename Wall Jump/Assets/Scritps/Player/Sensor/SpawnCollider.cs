using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCollider : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("SpawnCollider"))
        {
            Debug.Log("컬라이더 확인");
            GameObject nextStage = Instantiate(GameManager.Instance.stagePrefab);
            nextStage.transform.parent = GameManager.Instance.stageParent;
            Transform jointTrm = collision.transform.GetChild(0);
            nextStage.transform.position = jointTrm.position;
        }
    }
}
