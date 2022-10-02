using UnityEngine;
using Core.Utilities;

public class GameManager : Singleton<GameManager>
{
    [Header("Time")]
    public bool inGame;
    public bool gameStarted;
    public bool introductionPlayed;
    public bool playerZapped;
    public float timerValue;
    public GameEvent timerEvent;
    public int roomNumber;

    [Header("Zapp")]
    public float zappCooldown;

    [Header("Main Elements")]
    public Player player;
    public ArenaManager arenaManager;
    public CamManager camManager;
    public EnemyManager enemyManager;
    public uiManager uiManager;

    [Header("Visuals")]
    [SerializeField] float transitionInstensity;
    [SerializeField] float shaderValue;
    [SerializeField] AnimationCurve playerZapCurve;

    [Header("Menu")]
    public bool inMenu;

    private void Start()
    {
        Application.targetFrameRate = 60;


        if (!Application.isEditor) inGame = false;

        if (inGame) StartGame();
        else uiManager.DisplayGame(false);
    }


    public void StartGame()
    {
        Debug.Log("STAAART THE GAME");
        if(!introductionPlayed)
        {
            uiManager.PlayIntro();
            return;
        }

        inGame = true;
        inMenu = false;
        gameStarted = true;

        uiManager.DisplayGame(true);
        TenSeconds();
    }

    private void Update()
    {
        if (!inMenu && !gameStarted) StartGame(); // Prevent being in game and no gameplay event
        if (!inGame) return;


        timerValue -= Time.deltaTime;

        uiManager.SetZap(timerValue, 10f);

        if (timerValue <= 0f) 
        {

            if (Input.GetKeyDown(KeyCode.Space)) UseZappAbility();

            if(playerZapped)
            {
                if (timerValue < -1f) player.Damage(Mathf.Abs(timerValue * 0.1f)); // TAKE DAMAGE
                Shader.SetGlobalFloat("_corruption", Mathf.Abs(timerValue));
            }

        }

        shaderValue = playerZapCurve.Evaluate(10 - timerValue);
        if (shaderValue < 0.01f) shaderValue = 0f;
        Shader.SetGlobalFloat("_intensity", shaderValue * transitionInstensity);
    }


    public void UseZappAbility()
    {
        Invoke("TenSecondsInitiatedByPlayer", 0.1f);
    }

    public void TenSecondsInitiatedByPlayer()
    {
        if (!playerZapped) uiManager.PlayHackDialog();
        TenSeconds(true);
    }

    public void TenSeconds(bool commendedByPlayer = false) // Every ten sec
    {
        if(commendedByPlayer) playerZapped = true;
        inGame = true;
        timerValue = 10f;
        Shader.SetGlobalFloat("_corruption", 0f);

        Arena newArena = arenaManager.GetNewArena();
        newArena.Activate();
        player.transform.position = newArena.GetPlayerSpawn().position + Vector3.up*0.1f;

        player.combat.GetNewWeapon();
        enemyManager.InitNewArena(newArena);
        roomNumber++;
        uiManager.SetRoomNumber(roomNumber);

        timerEvent.Raise();
    }

    public void Restart()
    {
        roomNumber = 0;
        uiManager.SetRoomNumber(roomNumber);

        uiManager.DisplayGame(false);
        player.Respawn();
    }

    public void LoadLevel()
    {
        Debug.Log("Load level");
        //SceneLoader.LoadScene(levelList.list[0].sceneName);
    }

    public void OnEscape()
    {
        Debug.Log("Pressed Escape");
    }

    private void OnApplicationQuit()
    {
        Shader.SetGlobalFloat("_intensity", 0f);
    }
}
