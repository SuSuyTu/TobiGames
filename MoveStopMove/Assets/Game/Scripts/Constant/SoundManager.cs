using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static SoundManager instance;
    public static SoundManager Instance => instance;

    //GamePlay
    [SerializeField] private AudioSource gameplaySource;
    [SerializeField] private AudioSource mainMenuSource;
    [SerializeField] private AudioSource dieSource;
    [SerializeField] private AudioSource loseSource;
    [SerializeField] private AudioSource winSource;
    [SerializeField] private AudioSource attackSource;

    //UI
    [SerializeField] private AudioSource btn_ClickSource;

    protected virtual void Awake()
    {
        if (SoundManager.instance != null && SoundManager.instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        SoundManager.instance = this;
        DontDestroyOnLoad(gameObject); 
    }

    public void PlayOnMainMenu()
    {
        mainMenuSource.Play();
    }
    public void PlayOnStart()
    {
        mainMenuSource.Stop();
        gameplaySource.Play();
    }
    // public void StopBackgroundMusic()
    // {
    //     gameplaySource.Stop();
    // }
    public void PlayWhenAttack()
    {
        attackSource.Play();
    }
    public void PLayWhenHit()
    {
        dieSource.Play();
    }
    public void PLayWhenLose()
    {
        gameplaySource.Stop();
        loseSource.Play();
    }
    public void PlayWhenWin()
    {
        gameplaySource.Stop();
        winSource.Play();
    }
    public void PlayWhenClick()
    {
        btn_ClickSource.Play();
    }
}
