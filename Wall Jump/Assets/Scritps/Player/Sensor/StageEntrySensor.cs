using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageEntrySensor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("StageEntry"))
        {
            List<Transform> children = new List<Transform>();

            for (int i = 0; i < collision.transform.childCount; i++)
            {
                children.Add(collision.transform.GetChild(i));
            }

            GameManager.Instance.walls = children;
            Debug.Log(GameManager.Instance.walls[1].name);
        }
    }
}
