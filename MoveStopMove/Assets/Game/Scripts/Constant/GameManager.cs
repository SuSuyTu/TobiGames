using System;
using System.Collections;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;
    public static GameManager Instance => instance;

    [Header("Bot Spawn Manager")]
    [SerializeField] protected int maxNumOfBotsInPlayMode;
    public int MaxNumOfBotsInPlayMode => maxNumOfBotsInPlayMode;
    [SerializeField] protected int maxNumOfBotsInScene;
    [SerializeField] protected float delaySpawnTime = 2f;
    [SerializeField] protected Transform holderOfBotIndicator;
    [SerializeField] protected Transform botHolder;
    protected BotCtrl currentBot;
    public int botCount;

    [Header("Camera")]
    [SerializeField] protected CinemachineVirtualCamera gamePlayCamera;
    [SerializeField] protected CinemachineVirtualCamera skinShopCamera;

    [Header("Gold")]
    public int goldPerStage;
    public int totalPlayerGold;

    private static GameState gameState;

    public virtual void SetState(GameState state)
    {
        gameState = state;

    }
    public bool IsState(GameState state) => gameState == state;

    protected virtual void Awake()
    {
        if (GameManager.instance != null) Debug.LogWarning("Only 1 GameManager allow to exist");
        GameManager.instance = this;

        //Input.multiTouchEnabled = false;
        botCount = maxNumOfBotsInPlayMode;

        Application.targetFrameRate = 60;

        Screen.sleepTimeout = SleepTimeout.NeverSleep;

        int maxScreenHeight = 1280;
        float ratio = 1.0f * Screen.currentResolution.width / Screen.currentResolution.height;
        if (Screen.currentResolution.height > maxScreenHeight)
        {
            Screen.SetResolution(Mathf.RoundToInt(ratio * maxScreenHeight), maxScreenHeight, true);
        }
    }

    protected virtual void Start()
    {
        SwitchState(GameState.MainMenu);
    }

    protected IEnumerator SpawnBots()
    {
        WaitForSeconds wait = new WaitForSeconds(delaySpawnTime);

        int spawnedBots = 0;

        while (spawnedBots < maxNumOfBotsInScene)
        {
            //Debug.Log(spawnedBots);
            SpawnBot();
            spawnedBots++;

            yield return wait;
        }
    }

    protected virtual void SpawnBot()
    {
        Transform newEnemy = BotSpawner.Instance.SpawnRandomPos("Bot", Quaternion.identity);
        //Debug.Log(1);

        BotCtrl currentBot = Cache<BotCtrl>.GetComponent(newEnemy.GetComponent<BoxCollider>());

        currentBot.isDead = false;
        currentBot.IsAttackable = true;
        //currentBot.SetUpIndicator();
        currentBot.GetRandomName();
        currentBot.CharacterAttackRange.EnemiesInRange.Clear();
        BotSkin botSkin = currentBot.CharacterSkin as BotSkin;
        botSkin.ChangeSkin();
    
        newEnemy.gameObject.SetActive(true);
        //currentBot.LoadCurrentWeapon();
    }

    protected virtual void DespawnIndicator()
    {
        foreach (Transform indicator in holderOfBotIndicator)
        {
            IndicatorSpawner.Instance.Despawn(indicator);
            //Destroy(transform.gameObject);
        }
    }

    protected virtual void DespawnBot()
    {
        foreach (Transform bot in botHolder)
        {
            BotSpawner.Instance.Despawn(bot);
            //Destroy(transform.gameObject);
        }
    }

    protected IEnumerator TutorialWait()
    {
        yield return new WaitForSecondsRealtime(3f);

        SwitchState(GameState.Gameplay);
    }

    public virtual void SwitchState(GameState newState)
    {
        switch (newState)
        {
            case GameState.MainMenu:
                //UIManager.Instance.FloatingJoystick.HandleRange = 0;
                PlayerSpawner.Instance.Prefabs[0].gameObject.SetActive(true);
                PlayerCtrl.Instance.PlayerStateManager.OnRespawn();
                //CameraManager.Instance.SetSkinShopCamera();
                
                UIManager.Instance.OpenMainMenuCanvas();
                SoundManager.Instance.PlayOnMainMenu();
                CharacterData.Instance.SetData();

                break;
            
            case GameState.Tutorial:
                PlayerCtrl.Instance.Animator.SetBool(Constants.AnimType.DANCE, false);
                SoundManager.Instance.PlayOnStart();
                CameraManager.Instance.SetGamePlayCamera();
                StartCoroutine(TutorialWait());
                break;

            case GameState.Gameplay:
            
                PlayerCtrl.Instance.IsAttackable = true;
                PlayerCtrl.Instance.isDead = false;
                PlayerCtrl.Instance.SetUpIndicator();
                PlayerCtrl.Instance.LoadCurrentWeapon();
                PlayerCtrl.Instance.PlayerAttackRange.TuneRangeBaseOnWeapon();


                StopAllCoroutines();
                StartCoroutine(SpawnBots());

                break;

            case GameState.Lose:
                StopAllCoroutines();
                DespawnIndicator();
                DespawnBot();

                CameraManager.Instance.SetSkinShopCamera();
                UIManager.Instance.SetRankText((botCount + 1).ToString());
                SoundManager.Instance.PLayWhenLose();
                UIManager.Instance.OpenLoseCanvas();

                break;

            case GameState.Victory:
                StopAllCoroutines();
                DespawnIndicator();
                DespawnBot();

                CameraManager.Instance.SetSkinShopCamera();
                UIManager.Instance.FloatingJoystick.gameObject.SetActive(false);
                SoundManager.Instance.PlayWhenWin();
                UIManager.Instance.OpenVictoryCanvas();

                break;
        }
    }

}
public enum GameState
{
    MainMenu = 0,
    Gameplay = 1,
    Lose = 2,
    Revive = 3,
    Setting = 4,
    Victory = 5,
    Tutorial = 6,
}