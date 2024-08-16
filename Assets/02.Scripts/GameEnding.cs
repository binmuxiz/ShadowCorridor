
using System;
using TMPro;
using UnityEngine;

public class GameEnding: MonoBehaviour
{
    public static GameEnding Instance;

    public GameObject gameCanvas;
    public GameObject exitCanvas;

    public PlayTimeManager playTimeManager;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        exitCanvas.SetActive(false);
    }

    public void EndLevel()
    {
        gameCanvas.SetActive(false);
        exitCanvas.SetActive(true);
        
        playTimeManager.ShowCompletionTime();
        
        // 오디오 
        GlobalAudioManager.Instance.Stop(GlobalAudioName.GameBackground);
        GlobalAudioManager.Instance.Play(GlobalAudioName.GameClear);
    }   
}
