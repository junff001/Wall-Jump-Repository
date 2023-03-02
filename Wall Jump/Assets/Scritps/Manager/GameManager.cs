using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;
using static UnityEditor.Experimental.GraphView.GraphView;

public class GameManager : MonoSingleton<GameManager>
{
    public Transform respawnTrm;
    public Transform playerTrm;
    public Transform cameraTrm;
    public GameObject spriteTrm;
    public Animator animator;
    public PlayerPhysic physic;
    public BoxCollider2D deadBoundCollider;
    public CinemachineVirtualCamera virtualCamera;
    private CinemachineFramingTransposer framingTransposer;
    private readonly int isOnGround = Animator.StringToHash("isOnGround");

    void Start()
    {
        //framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
    }
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

    public void PlayerRespawn()
    {
        if (playerTrm.localScale.x == 1)
        {
            Player.Instance.currentDirection = PlayerDirection.Right;
        }
        else if (playerTrm.localScale.x == -1)
        {
            Player.Instance.currentDirection = PlayerDirection.Left;
        }

        InputManager.Instance.isStart = false;
        deadBoundCollider.enabled = false;
        Player.Instance.currnetState = PlayerState.OnGround;
        playerTrm.position = respawnTrm.position;
        //cameraTrm.position = playerTrm.position;

        physic.SetGravityScale(1f);
        spriteTrm.SetActive(true);

        //framingTransposer.m_TrackedObjectOffset.y = -6f;
    }

    public void CameraFocusing()
    {
        //framingTransposer.m_TrackedObjectOffset.y = 0f;
        deadBoundCollider.enabled = true;
    }
}
