using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using TreeEditor;
using UnityEngine;

public class CameraFixation : MonoBehaviour
{
    [Header("[ Component Variables ]")]
    [SerializeField] private ProCamera2D proCamera;
    [SerializeField] private Transform player;

    [Header("[ Movement Variables ]")]
    [SerializeField] private float moveSpeed;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.parent = proCamera.transform;
            proCamera.FollowHorizontal = false;
            StartCoroutine(OnFixation());
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            transform.parent = null;
            proCamera.FollowHorizontal = true;
        }
    }

    private IEnumerator OnFixation()
    {
        while (true)
        {
            proCamera.transform.Translate(Vector3.left * Time.deltaTime * moveSpeed);
            yield return null;
        }
    }
}
