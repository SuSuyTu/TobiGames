using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class UIGameplay : UIBase
{
    [SerializeField] protected GameObject tutorial;
    [SerializeField] protected GameObject PauseUI;
    [SerializeField] protected TextMeshProUGUI aliveText;
    [SerializeField] protected TextMeshProUGUI timerText;
    [SerializeField] protected TextMeshProUGUI readyText;
    [SerializeField] protected float timeDelay;

    private bool timerOn;
    private float timer;

    // Update is called once per frame
    protected virtual void OnEnable()
    {
        timer = timeDelay;
        tutorial.SetActive(true);
        timerOn = true;
    }
    void FixedUpdate()
    {
        if (timerOn)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimer(timer);
            }
            else
            {
                timerOn = false;
                timerText.text = "Go!";

                Invoke(nameof(EnterGame), 0.5f);
            }
        }

        aliveText.SetText("Alive: " + (GameManager.Instance.botCount + 1).ToString());
        if (GameManager.Instance.botCount == 0)
        {
            GameManager.Instance.SwitchState(GameState.Victory);
        }
    }

    protected virtual void UpdateTimer(float currentTime)
    {
        currentTime += 1;
        float seconds = Mathf.FloorToInt(currentTime %  60);

        timerText.text = seconds.ToString();
    }

    protected virtual void EnterGame()
    {
        tutorial.SetActive(false);
    }

    public virtual void PauseGame()
    {
        Time.timeScale = 0;
    }

    public virtual void ResumeGame()
    {
        Time.timeScale = 1;
    }
}
