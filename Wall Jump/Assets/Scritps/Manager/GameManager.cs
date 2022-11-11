using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GameManager : MonoSingleton<GameManager>
{
    // Galaxy S10e ±‚¡ÿ
    private float defaultResolutionRatio = 9 / 19;
    [SerializeField] private Tilemap stageTilemap;

    private void Start()
    {
        float displayResolutionRatio =  (float)Screen.width / (float)Screen.height;
        Camera.main.orthographicSize = Camera.main.orthographicSize * displayResolutionRatio;
        stageTilemap.transform.localScale = new Vector3(stageTilemap.transform.localScale.x * displayResolutionRatio, stageTilemap.transform.localScale.y * displayResolutionRatio, stageTilemap.transform.localScale.z);
    }
}
