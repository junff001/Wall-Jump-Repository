using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class GameManager : MonoSingleton<GameManager>
{
    [SerializeField] private float computationHeight;
    [SerializeField] private UILabel scoreLabel;
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
    private float nextHeight = 0f;
    private int score = 0;
    private float startHeight;

    void Start()
    {
        framingTransposer = virtualCamera.GetCinemachineComponent<CinemachineFramingTransposer>();
        startHeight = playerTrm.position.y;
        scoreLabel.text = score.ToString();
    }

    private void Update()
    {
        ScoreConversion();
    }
    //[SerializeField] private Camera mainCam;
    //// Galaxy S10e ±âÁØ
    //private float defaultResolutionRatio = 9 / 19;
    //[SerializeField] private Grid grid;

    //private void Start()
    //{
    //    float displayResolutionRatio =  (float)Screen.width / (float)Screen.height;
    //    Camera.main.orthographicSize = Camera.main.orthographicSize * displayResolutionRatio;
    //    grid.transform.localScale = new Vector3(grid.transform.localScale.x * displayResolutionRatio, grid.transform.localScale.y * displayResolutionRatio, grid.transform.localScale.z);
    //}

    void ScoreConversion()
    {
        if (playerTrm.position.y > nextHeight)
        {
            score++;
            scoreLabel.text = score.ToString();
            nextHeight = playerTrm.position.y + computationHeight;
        }
    }

    public void PlayerRespawn()
    {
        if (playerTrm.localScale.x == 1)
        {
            PlayerStatus.CurrentDirection = PlayerDirection.Right;
        }
        else if (playerTrm.localScale.x == -1)
        {
            PlayerStatus.CurrentDirection = PlayerDirection.Left;
        }

        InputManager.Instance.isStart = false;
        deadBoundCollider.enabled = false;
        PlayerStatus.CurrentState = PlayerState.OnGround;
        playerTrm.position = respawnTrm.position;
        cameraTrm.position = playerTrm.position;

        physic.SetGravityScale(1f);
        spriteTrm.SetActive(true);
        nextHeight = startHeight + computationHeight;
        score = 0;
        scoreLabel.text = score.ToString();

        framingTransposer.m_TrackedObjectOffset.y = -6f;
    }

    public void CameraFocusing()
    {
        framingTransposer.m_TrackedObjectOffset.y = 0f;
        deadBoundCollider.enabled = true;
    }
}
