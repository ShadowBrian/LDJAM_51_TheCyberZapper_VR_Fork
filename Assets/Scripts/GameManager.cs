using UnityEngine;
using Core.Utilities;

public class GameManager : Singleton<GameManager>
{
    [Header("Time")]
    public bool inGame;
    public float timerValue;
    public GameEvent timerEvent;

    [Header("Main Elements")]
    public Player player;
    public ArenaManager arenaManager;
    public CamManager camManager;
    public EnemyManager enemyManager;
    public uiManager uiManager;

    [Header("Visuals")]
    [SerializeField] float transitionInstensity;
    [SerializeField] float shaderValue;
    [SerializeField] AnimationCurve shaderCurve;

    [Header("Menu")]
    public bool inMenu;
    public UnityEngine.GameObject canvas, pauseCanvas;

    private void Start()
    {
        Application.targetFrameRate = 60;
        TenSeconds();
    }

    private void Update()
    {
        if (!inGame) return;


        timerValue -= Time.deltaTime;
        if (timerValue <= 0f) TenSeconds();

        shaderValue = shaderCurve.Evaluate(timerValue);
        if (shaderValue < 0.01f) shaderValue = 0f;
        Shader.SetGlobalFloat("_intensity", shaderValue * transitionInstensity);
    }

    public void TenSeconds() // Every ten sec
    {
        timerValue = 10f;

        Arena newArena = arenaManager.GetNewArena();
        player.transform.position = newArena.GetPlayerSpawn().position + Vector3.up*0.1f;

        enemyManager.InitNewArena(newArena);

        timerEvent.Raise();
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
