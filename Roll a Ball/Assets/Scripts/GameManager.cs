using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Timer timer;
    public PlayerManager playerManager;
    public EnemyManager enemyManager;
    public GameObject player;
    public Transform playerSpawn;
    public GameObject enemy;
    public Transform enemySpawn;
    public CameraController camController;
    public GameObject[] pickups;

    public Text m_MessageText;
    public Text m_PickupText;

    private float m_StartWait = 3.0f;
    private float m_EndWait = 3.0f;
    private bool enemyActive = false;

    // Use this for initialization
    void Start()
    {
        spawnPlayer();
        Debug.Log("false false " + (false && false));
        Debug.Log("false true " + (false && true));
        camController.player = playerManager.m_Instance;
        StartCoroutine(GameLoop());
    }

    // Update is called once per frame
    void Update()
    {
        if (timer.CurrentTime > 3 && !enemyActive)
        {
            enemyActive = true;
            spawnEnemy();
        }
    }

    IEnumerator GameLoop()
    {
        Debug.Log("Entering GameLoop");
        yield return StartCoroutine(GameStarting());
        yield return StartCoroutine(GamePlaying());
        yield return StartCoroutine(GameEnding());

        //Application.LoadLevel(Application.loadedLevel);
    }

    private IEnumerator GameStarting()
    {
        Debug.Log("Starting game");

        ResetPlayer();
        DisablePlayer();
        m_MessageText.text = string.Empty;
        m_PickupText.text = "Count: 0";

        yield return m_StartWait;
    }

    private IEnumerator GamePlaying()
    {
        Debug.Log("Game is running");
        EnablePlayerControl();

        while (!gameOver())
        {
            yield return null;
        }
    }

    private IEnumerator GameEnding()
    {
        Debug.Log("Game Ending");
        DisablePlayer();

        string message = EndMessage();
        m_MessageText.text = message;

        //Maybe put this in a coroutine after ending to show if it killed player?
        Destroy(enemyManager.m_Instance);
        
        yield return m_EndWait;
    }

    private bool gameOver()
    {
        bool status = ((countPickups() == 0) || !playerManager.m_Instance.activeSelf);
        Debug.Log("Player active: " + playerManager.m_Instance.activeSelf);
        Debug.Log("status: " + status);
        return status;
    }

    private int countPickups()
    {
        int numPickups = 0;
        foreach (GameObject pickup in pickups)
        {
            if (pickup.activeSelf)
            {
                numPickups++;
            }
        }
        string pickupCount = "Count: " + numPickups;
        m_PickupText.text = pickupCount;
        return numPickups;
    }

    private string EndMessage()
    {
        string message = "Game Over";

        if(countPickups() == 0)
        {
            message = "You Win!";
        }
        else if (!playerManager.m_Instance.activeSelf)
        {
            message = "You Lose!";
        }

        return message;
    }

    //The following can be extended to an array of managers for multiplayer
    private void DisablePlayer()
    {
        playerManager.Disable();
    }

    private void EnablePlayerControl()
    {
        playerManager.EnableControl();
    }

    private void ResetPlayer()
    {
        playerManager.Reset();
    }

    void spawnPlayer()
    {
        playerManager.m_Instance = Instantiate(player, playerSpawn) as GameObject;
        playerManager.m_spawnPoint = playerSpawn;
        playerManager.Setup();
    }

    void spawnEnemy()
    {
        Debug.Log("Spawn enemy called");
        enemyManager.target = playerManager.m_Instance.GetComponent<Rigidbody>();
        enemyManager.m_Instance = Instantiate(enemy, enemySpawn.position, enemySpawn.rotation) as GameObject;
        enemyManager.Setup();      
        
    }
}
