using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIManager : NewMonoBehaviour
{
    private static UIManager instance;
    public static UIManager Instance => instance;
    [Header("Canvas")]
    [SerializeField] protected GameObject gamePlayCanvas;
    [SerializeField] protected GameObject gameEndCanvas;


    [SerializeField] protected GameObject levelCompleted;
    [SerializeField] protected GameObject levelFailed;
    protected override void Awake()
    {
        base.Awake();
        if (UIManager.instance == null)
            UIManager.instance = this;
    }
    protected override void Start()
    {
        base.Start();

        gamePlayCanvas.SetActive(true);
        gameEndCanvas.SetActive(false);
    }

    protected virtual void Update() 
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            OnLevelCompleted();
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            OnLevelFailed();
        }
    }

    public  void OnClick_PauseButton()
    {
        // StopAllCoroutines();
        Time.timeScale = 0f;
    }
    public virtual void OnClick_PlayButton()
    {
        Time.timeScale = 1f;
    }

    public virtual void OnClick_RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public virtual void OnLevelCompleted()
    {
        gamePlayCanvas.SetActive(false);
        gameEndCanvas.SetActive(true);

        levelFailed.SetActive(false);
        levelCompleted.SetActive(true);
    }

    public virtual void OnLevelFailed()
    {
        gamePlayCanvas.SetActive(false);
        gameEndCanvas.SetActive(true);

        levelCompleted.SetActive(false);
        levelFailed.SetActive(true);
    }

    public virtual void OnClick_NextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
