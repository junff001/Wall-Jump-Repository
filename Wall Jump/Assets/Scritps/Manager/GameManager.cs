using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GameManager : MonoSingleton<GameManager>
{
    //[SerializeField] private Camera mainCam;
    //// Galaxy S10e ±‚¡ÿ
    //private float defaultResolutionRatio = 9 / 19;
    //[SerializeField] private Grid grid;

    //private void Start()
    //{
    //    float displayResolutionRatio =  (float)Screen.width / (float)Screen.height;
    //    Camera.main.orthographicSize = Camera.main.orthographicSize * displayResolutionRatio;
    //    grid.transform.localScale = new Vector3(grid.transform.localScale.x * displayResolutionRatio, grid.transform.localScale.y * displayResolutionRatio, grid.transform.localScale.z);
    //}
    public GameObject CurrentSpawnCollider { get; set; } = null;


    public List<Transform> walls { get; set; } = new List<Transform>();
    public Transform CurrentStickToWall { get; set; } = null;
    public float wallProperDistance { get; set; } = 1f;
}
